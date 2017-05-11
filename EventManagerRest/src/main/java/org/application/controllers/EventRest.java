package org.application.controllers;

import org.application.entities.Event;
import org.application.handlers.NotFoundException;
import org.application.service.EventService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class EventRest {
	
	@Autowired
    private EventService eventService;

    @RequestMapping(value = "/events/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Event createEvent(@RequestBody Event event) {
        return eventService.createEvent(event);
    }
    
    @RequestMapping(value = "/events", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Event> getAllEvents() {
    	return eventService.getAllEvents();
    }
    
    @RequestMapping(value = "/events/{eventId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Event getEvent(@PathVariable("eventId") Long id) throws Exception {
    	Event event = eventService.getEvent(id);
    	if(event == null) {
    		throw new NotFoundException();
    	}
        return event;
    }
    
    @RequestMapping(value = "/events/{eventId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Event updateEvent(@RequestBody Event event, @PathVariable("eventId") Long id) throws Exception {
    	Event fromDb = eventService.getEvent(id);
    	if(fromDb == null) {
    		throw new NotFoundException();
    	}
    	fromDb.setName(event.getName());
    	fromDb.setAddress(event.getAddress());
    	fromDb.setDescription(event.getDescription());
    	return eventService.createEvent(fromDb);
    }
    
    @RequestMapping(value = "/events/{eventId}", method = RequestMethod.DELETE)
    public void deleteEvent(@PathVariable("eventId") Long id) throws Exception {
    	if(eventService.getEvent(id) == null) {
    		throw new NotFoundException();
    	}
    	eventService.delete(id);
    }
}
