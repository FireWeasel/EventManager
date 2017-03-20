package org.application.controllers;

import org.application.entities.Reservation;
import org.application.entities.User;
import org.application.service.ReservationService;
import org.application.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
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

    @RequestMapping(value = "/users/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User createUser(@RequestBody User user) {
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
    	fromDb.setPassword(user.getPassword());
        return userService.createUser(fromDb);
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.DELETE)
    public void deleteUser(@PathVariable("userId") Long id) {
        userService.delete(id);
    }
    
	@RequestMapping(value = "/users/{userId}/reservations/create", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public User createReservation(@PathVariable("userId") long userId) {
		Reservation reservation = new Reservation();
		User user = userService.getUser(userId);
        reservation.addReservedBy(user);
		user.setReservation(reservation);
		reservationService.createReservation(reservation);
		return userService.createUser(user);
    }
    
}
