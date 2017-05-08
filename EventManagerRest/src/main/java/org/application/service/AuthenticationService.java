package org.application.service;

import java.security.Principal;
import org.application.entities.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class AuthenticationService {
	
	@Autowired
	private UserService userService;
	
	public User getCurrentlyLoggedInUser(Principal principal) {
		final String username = (String) principal.getName();
		if (username == null) {
			return null;
		}
		return userService.getUserByUsername(username);
	}
}
