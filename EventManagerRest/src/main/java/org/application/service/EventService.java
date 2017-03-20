package org.application.service;

import org.application.entities.Event;
import org.application.repositories.EventRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class EventService {
    
    @Autowired
    private EventRepository eventRepository;

    public Event createEvent(Event event) {
    	return eventRepository.save(event);
    }

    public Event getEvent(Long id){
        return eventRepository.findOne(id);
    }
    
    public Iterable<Event> getAllEvents() {
    	return eventRepository.findAll();
    }
	
	public void delete(Long id) {
		eventRepository.delete(id);
	}
}
