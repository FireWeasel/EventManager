package org.application.service;

import org.application.entities.Event;
import org.application.repositories.EventRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class EventService {
    private long lastId;
    
    @Autowired(required = true)
    private EventRepository eventRepository;
    
    public synchronized long getAndIncrementId() {
        return ++lastId;
    }

    public Event createEvent(Event event) {
    	return eventRepository.save(event);
    }

    public Event findOne(Long id){
        return eventRepository.findOne(id);
    };
    
}
