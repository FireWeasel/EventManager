package org.application.service;

import org.application.entities.User;
import org.application.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserService {
    
    @Autowired(required = true)
    private UserRepository userRepository;

    public User createUser(User user) {
    	return userRepository.save(user);
    }

    public Iterable<User> findAll() {
        return userRepository.findAll();
    }
    
    public User findOne(Long id) {
        return userRepository.findOne(id);
    }
    
    public User update(User user) {
        return userRepository.save(user);
    }
    
    public void delete(Long id) {
        userRepository.delete(id);
    }
}
