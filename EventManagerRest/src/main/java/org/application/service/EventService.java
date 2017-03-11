package org.application.service;

import org.application.entities.Event;
import org.application.repositories.EventRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class EventService {
    
    @Autowired(required = true)
    private EventRepository eventRepository;

    public Event createEvent(Event event) {
    	return eventRepository.save(event);
    }

    public Event findOne(Long id){
        return eventRepository.findOne(id);
    }
    
    public Iterable<Event> findAll() {
    	return eventRepository.findAll();
    }

	public Event update(Event event) {
		return eventRepository.save(event);
	}
	
	public void delete(Long id) {
		eventRepository.delete(id);
	}
}
