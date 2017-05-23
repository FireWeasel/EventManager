package org.application.controllers;

import org.application.entities.Camp;
import org.application.entities.Reservation;
import org.application.handlers.NotFoundException;
import org.application.service.CampService;
import org.application.service.ReservationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class CampRest {
	
	@Autowired
    private CampService campService;
	
	@Autowired
	private ReservationService reservationService;

    @RequestMapping(value = "/camps/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Camp createCamp(@RequestBody Camp camp) {
        return campService.createCamp(camp);
    }
    
    @RequestMapping(value = "/camps", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Camp> getAllCamps() {
    	return campService.getAllCamps();
    }
    
    @RequestMapping(value = "/camps/{campId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Camp getCamp(@PathVariable("campId") Long id) throws Exception {
        Camp camp = campService.getCamp(id);
        if(camp == null) {
        	throw new NotFoundException();
        }
        return camp;
    }
    
    @RequestMapping(value = "/camps/{campId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Camp updateCamp(@RequestBody Camp camp, @PathVariable("campId") Long id) throws Exception {
    	Camp fromDb = campService.getCamp(id);
    	if(fromDb == null) {
        	throw new NotFoundException();
        }
    	fromDb.setName(camp.getName());
    	fromDb.setDescription(camp.getDescription());
    	fromDb.setPrice(camp.getPrice());
    	fromDb.setCheckedIn(camp.isCheckedIn());
    	return campService.createCamp(fromDb);
    }
    
    @RequestMapping(value = "/camps/{campId}", method = RequestMethod.DELETE)
    public void deleteCamp(@PathVariable("campId") Long id) throws Exception {
    	Camp camp = campService.getCamp(id);
    	if(camp == null) {
        	throw new NotFoundException();
        }
    	Reservation reservation = camp.getReservation();
    	reservationService.deleteReservation(reservation.getId());
    	campService.delete(id);
    }
    
    @RequestMapping(value = "/camps/free", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Camp> getFreeCamps() {
    	return campService.getFreeCamps();
    }
}
