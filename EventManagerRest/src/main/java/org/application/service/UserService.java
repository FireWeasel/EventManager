package org.application.service;

import org.application.entities.User;
import org.application.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserService {
    
    @Autowired
    private UserRepository userRepository;

    public User createUser(User user) {
    	return userRepository.save(user);
    }

    public Iterable<User> getAllUsers() {
        return userRepository.findAll();
    }
    
    public User getUser(Long id) {
        return userRepository.findOne(id);
    }
    
    public void delete(Long id) {
        userRepository.delete(id);
    }

	public User getUserByUsername(String username) {
		return userRepository.findByUsername(username);
	}

	public User getUserByEmail(String email) {
		return userRepository.findByEmail(email);
	}
}
