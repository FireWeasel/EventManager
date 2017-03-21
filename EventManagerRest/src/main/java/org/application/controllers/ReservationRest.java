package org.application.controllers;

import java.util.List;

import org.application.entities.Reservation;
import org.application.entities.User;
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
    
    @RequestMapping(value = "/reservations", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Reservation> getAllReservations() {
    	return reservationService.getAllReservations();
    }
    
    @RequestMapping(value = "/reservations/{reservationId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Reservation getReservation(@PathVariable("reservationId") Long id) {
        return reservationService.getReservation(id);
    }
    
    @RequestMapping(value = "/reservations/{reservationId}/addUser/{userId}", method = RequestMethod.PUT, produces = "application/json")
    @ResponseBody
    public Reservation addUserToReservation(@PathVariable("reservationId") Long reservationId, @PathVariable("userId") Long userId) {
        Reservation reservation = reservationService.getReservation(reservationId);
        User user = userService.getUser(userId);
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
    public void deleteReservation(@PathVariable("reservationId") Long id) {
    	reservationService.deleteReservation(id);
    }
    
    @RequestMapping(value = "/reservations/{reservationId}/payment", method = RequestMethod.PUT)
    @ResponseBody
    public Reservation reservationPayment(@PathVariable("reservationId") Long id) {
    	Reservation fromDB = reservationService.getReservation(id);
    	fromDB.setPaid(true); // TODO: Check if already the reservation is paid
    	return reservationService.createReservation(fromDB);
    }
}
