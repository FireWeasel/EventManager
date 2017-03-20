package org.application.controllers;

import org.application.entities.Camp;
import org.application.service.CampService;
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
    public Camp getCamp(@PathVariable("campId") Long id) {
        return campService.getCamp(id);
    }
    
    @RequestMapping(value = "/camps/{campId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Camp updateCamp(@RequestBody Camp camp, @PathVariable("campId") Long id) {
    	Camp fromDb = campService.getCamp(id);
    	fromDb.setName(camp.getName());
    	fromDb.setDescription(camp.getDescription());
    	fromDb.setPrice(camp.getPrice());
    	fromDb.setCheckedIn(camp.isCheckedIn());
    	return campService.createCamp(fromDb);
    }
    
    @RequestMapping(value = "/camps/{campId}", method = RequestMethod.DELETE)
    public void deleteCamp(@PathVariable("campId") Long id) {
    	campService.delete(id);
    }
}
