package org.application.service;

import org.application.entities.Camp;
import org.application.repositories.CampRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CampService {
    
    @Autowired
    private CampRepository campRepository;

    public Camp createCamp(Camp camp) {
    	return campRepository.save(camp);
    }

    public Camp getCamp(Long id){
        return campRepository.findOne(id);
    }
    
    public Iterable<Camp> getAllCamps() {
    	return campRepository.findAll();
    }
	
	public void delete(Long id) {
		campRepository.delete(id);
	}
}
