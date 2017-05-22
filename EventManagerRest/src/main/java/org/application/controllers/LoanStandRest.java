package org.application.controllers;

import java.util.List;

import org.application.entities.Item;
import org.application.entities.LoanStand;
import org.application.handlers.NotFoundException;
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
public class LoanStandRest {

	@Autowired
	private LoanStandService loanStandService;
	
	@Autowired
	private ItemService itemService;
	
	@RequestMapping(value = "/stands/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public LoanStand createLoanStand(@RequestBody LoanStand loanStand) {
        return loanStandService.createLoanStand(loanStand);
    }
	
	@RequestMapping(value = "/stands", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<LoanStand> getAllLoanStands() {
    	return loanStandService.getAllLoanStands();
    }
	
	@RequestMapping(value = "/stands/{loanStandId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public LoanStand getLoanStand(@PathVariable("loanStandId") long loanStandId) throws Exception {
		LoanStand loanStand = loanStandService.getLoanStand(loanStandId);
		if(loanStand == null) {
			throw new NotFoundException();
		}
    	return loanStand;
    }
	
	@RequestMapping(value = "/stands/{loanStandId}/items/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public LoanStand addItem(@RequestBody Item item, @PathVariable("loanStandId") long loanStandId) throws Exception {
		LoanStand loanStand = loanStandService.getLoanStand(loanStandId);
		if(loanStand == null) {
			throw new NotFoundException();
		}
		item.setLoanStand(loanStand);
		loanStand.addItem(item);
		itemService.createItem(item);
        return loanStandService.createLoanStand(loanStand);
    }
	
	@RequestMapping(value = "/stands/{loanStandId}/items", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public List<Item> getLoanStandItems(@PathVariable("loanStandId") long loanStandId) throws Exception {
		LoanStand loanStand = loanStandService.getLoanStand(loanStandId);
		if(loanStand == null) {
			throw new NotFoundException();
		}
    	return loanStand.getItems();
    }
	
	@RequestMapping(value = "/stands/{loanStandId}/items/{itemId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Item updateItem(@RequestBody Item item, @PathVariable("itemId") Long id) throws Exception {
    	Item fromDb = itemService.getItem(id);
    	if(fromDb == null) {
			throw new NotFoundException();
		}
    	fromDb.setName(item.getName());
    	fromDb.setDescription(item.getDescription());
    	fromDb.setFee(item.getFee());
    	fromDb.setQuantity(item.getQuantity());
    	fromDb.setType(item.getType());
    	fromDb.setLoanStand(loanStandService.getLoanStand(id));
    	return itemService.createItem(fromDb);
    }
}
