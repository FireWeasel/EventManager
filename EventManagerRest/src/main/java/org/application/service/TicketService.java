package org.application.service;

import org.application.entities.Ticket;
import org.application.repositories.TicketRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TicketService {

	@Autowired(required = true)
    private TicketRepository ticketRepository;

    public Ticket createTicket(Ticket ticket) {
    	Ticket newTicket = new Ticket(ticket.getId(), ticket.getBalance());
    	return ticketRepository.save(newTicket);
    }

	public Iterable<Ticket> getAllTickets() {
		return ticketRepository.findAll();
	}

	public Ticket getTicket(Long id) {
		return ticketRepository.findOne(id);
	}

	public Ticket checkInTicket(Long id) {
		// TODO: check if the ticket is already have been checked in
		Ticket fromDb = ticketRepository.findOne(id);
		fromDb.checkIn();
		return ticketRepository.save(fromDb);
	}
	
	public Ticket checkOutTicket(Long id) {
		// TODO: check if the ticket is already have been checked out
		Ticket fromDb = ticketRepository.findOne(id);
		fromDb.checkOut();
		return ticketRepository.save(fromDb);
	}
}
