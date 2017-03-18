package org.application.controller;

import org.application.entities.LoanStand;
import org.application.service.LoanStandService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class LoanStandRest {

	@Autowired
	private LoanStandService loanStandRepository;
	
	@RequestMapping(value = "/stands", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<LoanStand> getAllLoanStands() {
    	return loanStandRepository.getAllLoanStands();
    }
	
	@RequestMapping(value = "/stands/{loanStandId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public LoanStand getLoanStand(@PathVariable("loanStandId") long loanStandId) {
    	return loanStandRepository.getLoanStand(loanStandId);
    }
}
