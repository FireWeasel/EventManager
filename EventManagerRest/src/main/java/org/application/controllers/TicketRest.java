package org.application.controllers;

import org.application.entities.Ticket;
import org.application.entities.User;
import org.application.service.TicketService;
import org.application.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TicketRest {

	@Autowired
	private TicketService ticketService;
	
	@Autowired
	private UserService userService;
	
	@RequestMapping(value = "/tickets", method = RequestMethod.GET, produces = "application/json")
	@ResponseBody
	public Iterable<Ticket> getAllTickets() {
		return ticketService.getAllTickets();
	}
	
	@RequestMapping(value = "/tickets/{ticketId}", method = RequestMethod.GET, produces = "application/json")
	@ResponseBody
	public Ticket getTicket(@PathVariable("ticketId") Long id) {
		return ticketService.getTicket(id);
	}
	
	@RequestMapping(value = "/tickets/checkIn/{ticketId}", method = RequestMethod.POST, produces = "application/json")
	@ResponseBody
	public Ticket checkInTicket(@PathVariable("ticketId") Long id) {
		return ticketService.checkInTicket(id);
	}
	
	@RequestMapping(value = "/tickets/checkOut/{ticketId}", method = RequestMethod.POST, produces = "application/json")
	@ResponseBody
	public Ticket checkOutTicket(@PathVariable("ticketId") Long id) {
		return ticketService.checkOutTicket(id);
	}
	
	@RequestMapping(value = "/tickets/{ticketId}", method = RequestMethod.DELETE)
    public void deleteTicket(@PathVariable("ticketId") Long id) {
		Ticket ticket = ticketService.getTicket(id);
		User user = ticket.getOwner();
		user.setTicket(null);
		ticket.setOwner(null);
		userService.createUser(user);
        ticketService.delete(id);
    }
}
