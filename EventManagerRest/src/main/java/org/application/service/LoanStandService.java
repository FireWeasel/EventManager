package org.application.service;

import org.application.entities.LoanStand;
import org.application.repositories.LoanStandRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class LoanStandService {
	
	@Autowired(required = true)
	private LoanStandRepository loanStandRepository;
	
	public LoanStand createLoanStand(LoanStand loanStand) {
		return loanStandRepository.save(loanStand);
	}
	
	public Iterable<LoanStand> getAllLoanStands() {
		return loanStandRepository.findAll();
	}
	
	public LoanStand getLoanStand(long id) {
		return loanStandRepository.findOne(id);
	}
}
