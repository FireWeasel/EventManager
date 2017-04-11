package org.application.controllers;

import java.util.List;

import org.application.entities.BorrowedItem;
import org.application.entities.Item;
import org.application.entities.Product;
import org.application.entities.Ticket;
import org.application.entities.User;
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
	
    @RequestMapping(value = "/tickets/{ticketId}/products/{productId}", method = RequestMethod.POST, produces = "application/json")
    @ResponseBody
    public Ticket buyProduct(@PathVariable("ticketId") Long ticketId, @PathVariable("productId") Long productId) {
    	Ticket ticket = ticketService.getTicket(ticketId);
    	Product product = productService.getProduct(productId);
    	ticket.setBalance(ticket.getBalance()-product.getPrice());
    	product.setQuantity(product.getQuantity()-1);
    	ticket.getPurchases().add(product);
    	product.getPurchasedBy().add(ticket);
    	// TODO: check if ticket balance and product quantity is enough
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
    public Ticket borrowItem(@PathVariable("ticketId") Long ticketId, @PathVariable("itemId") Long itemId) {
    	Ticket ticket = ticketService.getTicket(ticketId);
    	Item item = itemService.getItem(itemId);
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
    public Ticket returnBorrowedItem(@PathVariable("ticketId") Long ticketId, @PathVariable("itemId") Long itemId) {
    	Ticket ticket = ticketService.getTicket(ticketId);
    	Item item = itemService.getItem(itemId);
    	BorrowedItem borrowedItem = ticketService.getBorrowedItem(ticket, item);
    	if(borrowedItem != null) {
    		item.setQuantity(item.getQuantity() + 1);
    		borrowedItem.setReturned(true);
    		// TODO: check if ticket balance is enough
    		ticket.setBalance(ticket.getBalance() - item.getFee());
    		itemService.createItem(item);
    		borrowedItemService.createBorrowedItem(borrowedItem);
    		return ticketService.createTicket(ticket);
    	}
    	return null;
    }
}
