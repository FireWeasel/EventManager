package org.application.controllers;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import org.application.entities.BorrowedItem;
import org.application.entities.Item;
import org.application.entities.Product;
import org.application.entities.Ticket;
import org.application.entities.User;
import org.application.handlers.InsufficientBalanceException;
import org.application.handlers.NotFoundException;
import org.application.handlers.NotInStockException;
import org.application.handlers.TicketAlreadyCheckedInException;
import org.application.handlers.TicketAlreadyCheckedOutException;
import org.application.handlers.TicketNotCheckedInException;
import org.application.service.BorrowedItemService;
import org.application.service.ItemService;
import org.application.service.ProductService;
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
	
	@Autowired
	private ProductService productService;
	
	@Autowired
	private ItemService itemService;
	
	@Autowired
	private BorrowedItemService borrowedItemService;
	
	@RequestMapping(value = "/tickets", method = RequestMethod.GET, produces = "application/json")
	@ResponseBody
	public Iterable<Ticket> getAllTickets() {
		return ticketService.getAllTickets();
	}
	
	@RequestMapping(value = "/tickets/{ticketId}", method = RequestMethod.GET, produces = "application/json")
	@ResponseBody
	public Ticket getTicket(@PathVariable("ticketId") Long id) throws Exception {
		Ticket ticket = ticketService.getTicket(id);
		if (ticket == null) {
			throw new NotFoundException();
		}
		return ticket;
	}
	
	@RequestMapping(value = "/tickets/checkIn/{ticketId}", method = RequestMethod.POST, produces = "application/json")
	@ResponseBody
	public Ticket checkInTicket(@PathVariable("ticketId") Long id) throws Exception {
		Ticket ticket = ticketService.getTicket(id);
		if (ticket == null) {
			throw new NotFoundException();
		}
		if (ticket.getCheckedIn() == true) {
			throw new TicketAlreadyCheckedInException();
		}
		return ticketService.checkInTicket(id);
	}
	
	@RequestMapping(value = "/tickets/checkOut/{ticketId}", method = RequestMethod.POST, produces = "application/json")
	@ResponseBody
	public Ticket checkOutTicket(@PathVariable("ticketId") Long id) throws Exception {
		Ticket ticket = ticketService.getTicket(id);
		if (ticket == null) {
			throw new NotFoundException();
		}
		if (ticket.getCheckedIn() == false) {
			throw new TicketNotCheckedInException();
		}
		if (ticket.getCheckedOut() == true) {
			throw new TicketAlreadyCheckedOutException();
		}
		return ticketService.checkOutTicket(id);
	}
	
	@RequestMapping(value = "/tickets/{ticketId}", method = RequestMethod.DELETE)
    public void deleteTicket(@PathVariable("ticketId") Long id) throws Exception {
		Ticket ticket = ticketService.getTicket(id);
		if (ticket == null) {
			throw new NotFoundException();
		}
		User user = ticket.getOwner();
		if (user == null) {
			throw new NotFoundException();
		}
		user.setTicket(null);
		ticket.setOwner(null);
		userService.createUser(user);
        ticketService.delete(id);
    }
	
    @RequestMapping(value = "/tickets/{ticketId}/products/{productId}", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public Ticket buyProduct(@PathVariable("ticketId") Long ticketId, @PathVariable("productId") Long productId) throws Exception {
    	Ticket ticket = ticketService.getTicket(ticketId);
    	Product product = productService.getProduct(productId);
    	if (ticket == null || product == null) {
    		throw new NotFoundException();
    	}
    	if (product.getQuantity() <= 0) {
    		throw new NotInStockException();
    	}
    	if (ticket.getBalance() - product.getPrice() < 0) {
    		throw new InsufficientBalanceException();
    	}
    	ticket.setBalance(ticket.getBalance()-product.getPrice());
    	product.setQuantity(product.getQuantity()-1);
    	ticket.getPurchases().add(product);
    	product.getPurchasedBy().add(ticket);
    	productService.createProduct(product);
        return ticketService.createTicket(ticket);
    }
    
    @RequestMapping(value = "/tickets/{ticketId}/products", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public List<Product> getTicketProducts(@PathVariable("ticketId") long ticketId) {
    	return ticketService.getTicket(ticketId).getPurchases();
    }
    
    @RequestMapping(value = "/tickets/{ticketId}/items/{itemId}", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public Ticket borrowItem(@PathVariable("ticketId") Long ticketId, @PathVariable("itemId") Long itemId) throws Exception {
    	Ticket ticket = ticketService.getTicket(ticketId);
    	Item item = itemService.getItem(itemId);
    	if (ticket == null || item == null) {
    		throw new NotFoundException();
    	}
    	if (item.getQuantity() <= 0) {
    		throw new NotInStockException();
    	}
    	item.setQuantity(item.getQuantity() - 1);
    	BorrowedItem borrowedItem = new BorrowedItem();
    	borrowedItem.setItem(item);
    	borrowedItem.setTicket(ticket);
    	ticket.getBorrowedItems().add(borrowedItem);
    	itemService.createItem(item);
    	borrowedItemService.createBorrowedItem(borrowedItem);
        return ticketService.createTicket(ticket);
    }
    
    @RequestMapping(value = "/tickets/{ticketId}/items", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public List<BorrowedItem> getTicketItems(@PathVariable("ticketId") long ticketId) {
    	return ticketService.getTicket(ticketId).getBorrowedItems();
    }
    
    @RequestMapping(value = "/tickets/{ticketId}/items/{itemId}/return", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public Ticket returnBorrowedItem(@PathVariable("ticketId") Long ticketId, @PathVariable("itemId") Long itemId) throws Exception {
    	Ticket ticket = ticketService.getTicket(ticketId);
    	Item item = itemService.getItem(itemId);
    	if (ticket == null || item == null) {
    		throw new NotFoundException();
    	}
    	BorrowedItem borrowedItem = ticketService.getBorrowedItem(ticket, item);
    	if (borrowedItem == null) {
    		throw new NotFoundException();
    	}
		Date currentDate = new Date();
		SimpleDateFormat formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		long diff = currentDate.getTime() - formatter.parse(borrowedItem.getDateBorrowed()).getTime();
		int days = (int) (diff / (1000 * 60 * 60 * 24));
		if (days == 0) {
			days++;
		}
		if (ticket.getBalance() - (item.getFee() * days) < 0) {
			throw new InsufficientBalanceException();
		}
		item.setQuantity(item.getQuantity() + 1);
		borrowedItem.setReturned(true);
		ticket.setBalance(ticket.getBalance() - item.getFee() * days);
		itemService.createItem(item);
		borrowedItemService.createBorrowedItem(borrowedItem);
		return ticketService.createTicket(ticket);
    }
}
