package org.application.controllers;

import org.application.entities.Item;
import org.application.entities.LoanStand;
import org.application.service.ItemService;
import org.application.service.LoanStandService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ItemRest {
	
	@Autowired
	private ItemService itemService;
	
	@Autowired
	private LoanStandService loanStandService;
	
	@RequestMapping(value = "/items", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Item> getAllItems() {
    	return itemService.getAllItems();
    }
	
	@RequestMapping(value = "/items/{itemId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Item getItem(@PathVariable("itemId") long itemId) {
    	return itemService.getItem(itemId);
    }
	
    @RequestMapping(value = "/items/{itemId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Item updateItem(@RequestBody Item item, @PathVariable("itemId") Long id) {
    	Item fromDb = itemService.getItem(id);
    	fromDb.setName(item.getName());
    	fromDb.setDescription(item.getDescription());
    	fromDb.setFee(item.getFee());
    	fromDb.setQuantity(item.getQuantity());
    	fromDb.setType(item.getType());
    	fromDb.setLoanStand(item.getLoanStand());
    	return itemService.createItem(fromDb);
    }
    
    @RequestMapping(value = "/items/{itemId}", method = RequestMethod.DELETE)
    public void deleteItem(@PathVariable("itemId") Long id) {
    	Item item = itemService.getItem(id);
    	LoanStand loanStand = item.getLoanStand();
    	loanStand.getItems().remove(item);
    	loanStandService.createLoanStand(loanStand);
    	itemService.delete(id);
    }
}
