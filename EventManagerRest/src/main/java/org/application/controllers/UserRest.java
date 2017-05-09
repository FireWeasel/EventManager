package org.application.controllers;

import java.security.Principal;

import org.application.entities.Camp;
import org.application.entities.Reservation;
import org.application.entities.Ticket;
import org.application.entities.User;
import org.application.service.AuthenticationService;
import org.application.service.CampService;
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
    public User getUser(@PathVariable("userId") Long id) {
        return userService.getUser(id);
    }

    @RequestMapping(value = "/users/{userId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User updateUser(@RequestBody User user, @PathVariable("userId") Long id) {
    	User fromDb = userService.getUser(id);
    	fromDb.setUsername(user.getUsername());
    	fromDb.setEmail(user.getEmail());
    	BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();
    	fromDb.setPassword(encoder.encode(user.getPassword()));
        return userService.createUser(fromDb);
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.DELETE)
    public void deleteUser(@PathVariable("userId") Long id) {
        userService.delete(id);
    }
    
	@RequestMapping(value = "/users/reservations/create/{campId}", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public User createReservation(Principal principal, @PathVariable("campId") long campId) {
		Reservation reservation = new Reservation();
		User user = userService.getUser(authenticationService.getCurrentlyLoggedInUser(principal).getId());
		Camp camp = campService.getCamp(campId);
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
    public User createTicket(Principal principal, @RequestBody Ticket ticket) {
		User user = authenticationService.getCurrentlyLoggedInUser(principal);
		ticket.setOwner(user);
		user.setTicket(ticket);
		ticketService.createTicket(ticket);
		return userService.createUser(user);
    }
	
	@RequestMapping(value = "/users/current", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public User getCurrentUser(Principal principal) {
		return authenticationService.getCurrentlyLoggedInUser(principal);
    }
}
