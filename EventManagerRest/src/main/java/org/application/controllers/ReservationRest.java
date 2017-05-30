package org.application.controllers;

import java.security.Principal;
import java.util.List;

import org.application.entities.PaymentLog;
import org.application.entities.Reservation;
import org.application.entities.User;
import org.application.entities.UserRole;
import org.application.handlers.AlreadyHasReservationException;
import org.application.handlers.AlreadyPaidException;
import org.application.handlers.NotFoundException;
import org.application.service.AuthenticationService;
import org.application.service.PaymentLogService;
import org.application.service.ReservationService;
import org.application.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ReservationRest {
	
	@Autowired
	private ReservationService reservationService;
	@Autowired
	private UserService userService;
	@Autowired
	private PaymentLogService paymentLogService;
	@Autowired
	private AuthenticationService authenticationService;
    
    @RequestMapping(value = "/reservations", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Reservation> getAllReservations() {
    	return reservationService.getAllReservations();
    }
    
    @RequestMapping(value = "/reservations/{reservationId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Reservation getReservation(@PathVariable("reservationId") Long reservationId) throws Exception {
    	Reservation reservation = reservationService.getReservation(reservationId);
    	if (reservation == null) {
			throw new NotFoundException();
		}
        return reservation;
    }
    
    @RequestMapping(value = "/reservations/{reservationId}/add/{email:.+}", method = RequestMethod.PUT, produces = "application/json")
    @ResponseBody
    public Reservation addUserToReservation(@PathVariable("reservationId") Long reservationId, @PathVariable("email") String email) throws Exception {
        Reservation reservation = reservationService.getReservation(reservationId);
        User user = userService.getUserByEmail(email);
        if (reservation == null || user == null) {
			throw new NotFoundException();
		}
    	if (user.getReservation() != null) {
    		throw new AlreadyHasReservationException();
    	}
    	if (user.getUserRole() == UserRole.EMPLOYEE) {
    		throw new NotFoundException();
    	}
        reservation.addReservedBy(user);
        user.setReservation(reservation);
        userService.createUser(user);
        return reservationService.createReservation(reservation);
    }
    
    @RequestMapping(value = "/reservations/{reservationId}/users", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public List<User> getReservationUsers(@PathVariable("reservationId") Long id) {
        return reservationService.getReservation(id).getReservedBy();
    }
    
    @RequestMapping(value = "/reservations/{reservationId}", method = RequestMethod.DELETE)
    public void deleteReservation(@PathVariable("reservationId") Long reservationId) throws Exception {
    	Reservation reservation = reservationService.getReservation(reservationId);
    	if (reservation == null) {
    		throw new NotFoundException();
    	}
    	reservationService.deleteReservation(reservationId);
    }
    
    @RequestMapping(value = "/reservations/{reservationId}/payment", method = RequestMethod.PUT)
    @ResponseBody
    public Reservation reservationPayment(@PathVariable("reservationId") Long id, Principal principal) throws Exception {
    	Reservation fromDB = reservationService.getReservation(id);
    	if (fromDB == null) {
    		throw new NotFoundException();
    	}
    	if (fromDB.getPaid()) {
    		throw new AlreadyPaidException();
    	}
    	fromDB.setPaid(true);
    	paymentLogService.create(new PaymentLog((30+(fromDB.getReservedBy().size()-1)*20), 
    								authenticationService.getCurrentlyLoggedInUser(principal).getTicket()));
    	return reservationService.createReservation(fromDB);
    }
}
