package org.application.controllers;

import org.application.entities.User;
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

    @RequestMapping(value = "/users/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User createUser(@RequestBody User user) {
        return userService.createUser(user);
    }
    
    @RequestMapping(value = "/users", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<User> getAllUsers() {
        return userService.findAll();
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public User getUserByName(@PathVariable("userId") Long id) {
        return userService.findOne(id);
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public User updateUser(@RequestBody User user, @PathVariable("userId") Long id) {
    	User fromDb = userService.findOne(id);
    	fromDb.setUsername(user.getUsername());
    	fromDb.setEmail(user.getEmail());
    	fromDb.setPassword(user.getPassword());
        return userService.update(fromDb);
    }
    
    @RequestMapping(value = "/users/{userId}", method = RequestMethod.DELETE)
    public void deleteUser(@PathVariable("userId") Long id) {
        userService.delete(id);
    }
    
}
