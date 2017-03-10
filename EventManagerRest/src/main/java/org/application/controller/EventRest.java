package org.application.controller;

import org.application.entities.Event;
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
    
    @RequestMapping(value = "/events/{eventId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Event getEventByName(@PathVariable("eventId") Long id) {
        return eventService.findOne(id);
    }
}
