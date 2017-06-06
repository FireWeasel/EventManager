package org.application.controllers;

import java.security.Principal;

import org.application.entities.Camp;
import org.application.entities.PaymentLog;
import org.application.entities.Reservation;
import org.application.entities.Ticket;
import org.application.entities.User;
import org.application.handlers.NoTicketException;
import org.application.handlers.NotFoundException;
import org.application.service.AuthenticationService;
import org.application.service.CampService;
import org.application.service.PaymentLogService;
import org.application.service.ReservationService;
import org.application.service.TicketService;
import org.application.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UserRest {
	
	@Autowired
    private UserService userService;
	@Autowired
	private ReservationService reservationService;
	@Autowired
	private TicketService ticketService;
	@Autowired
	private CampService campService;
	@Autowired
	private AuthenticationService authenticationService;
	@Autowired
	private PaymentLogService paymentLogService;

    @RequestMapping(value = "/users/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User createUser(@RequestBody User user) {
    	BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();
    	user.setPassword(encoder.encode(user.getPassword()));
        return userService.createUser(user);
    }
    
    @RequestMapping(value = "/users", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public User getUser(@PathVariable("userId") Long id) throws Exception {
    	User user = userService.getUser(id);
    	if (user == null) {
    		throw new NotFoundException();
    	}
        return user;
    }

    @RequestMapping(value = "/users/{userId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User updateUser(@RequestBody User user, @PathVariable("userId") Long id) throws Exception {
    	User fromDb = userService.getUser(id);
    	if (fromDb == null) {
    		throw new NotFoundException();
    	}
    	fromDb.setUsername(user.getUsername());
    	fromDb.setEmail(user.getEmail());
    	BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();
    	fromDb.setPassword(encoder.encode(user.getPassword()));
    	// fromDb.setUserRole(user.getUserRole()); // in case of changing role
        return userService.createUser(fromDb);
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.DELETE)
    public void deleteUser(@PathVariable("userId") Long id) throws Exception {
    	User user = userService.getUser(id);
    	if (user == null) {
    		throw new NotFoundException();
    	}
        userService.delete(id);
    }
    
	@RequestMapping(value = "/users/reservations/create", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public User createReservation(Principal principal) throws Exception {		
		User user = userService.getUser(authenticationService.getCurrentlyLoggedInUser(principal).getId());
		Camp camp = campService.getNextFree();
		if (user == null || camp == null) {
    		throw new NotFoundException();
    	}
		if (user.getTicket() == null) {
			throw new NoTicketException();
		}
		Reservation reservation = new Reservation();
        reservation.addReservedBy(user);
        reservation.setCamp(camp);
        reservationService.createReservation(reservation);
        camp.setReservation(reservation);
		user.setReservation(reservation);
		campService.createCamp(camp);
		return userService.createUser(user);
    }
	
	@RequestMapping(value = "/users/tickets/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User createTicket(Principal principal, @RequestBody Ticket ticket) throws Exception {
		User user = authenticationService.getCurrentlyLoggedInUser(principal);
		if (user == null) {
    		throw new NotFoundException();
    	}
		ticket.setOwner(user);
		user.setTicket(ticket);
		ticketService.createTicket(ticket);
		return userService.createUser(user);
    }
	
	@RequestMapping(value = "/users/current", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public User getCurrentUser(Principal principal) throws Exception {
		User user = authenticationService.getCurrentlyLoggedInUser(principal);
		if (user == null) {
    		throw new NotFoundException();
    	}
		return user;
    }
	
	@RequestMapping(value = "/users/tickets/deposit", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
	@ResponseBody
	public User depositBalance(@RequestBody Ticket ticket, Principal principal) {
		User user = authenticationService.getCurrentlyLoggedInUser(principal);
		Ticket ticketFromDb = user.getTicket();
		ticketFromDb.setBalance(ticketFromDb.getBalance() + ticket.getBalance());
		paymentLogService.create(new PaymentLog(ticket.getBalance(), ticketFromDb));
		ticketService.createTicket(ticketFromDb);
		return user;
	}
}
