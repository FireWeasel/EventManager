package org.application.service;

import org.application.entities.PaymentLog;
import org.application.repositories.PaymentLogRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class PaymentLogService {
	@Autowired
	private PaymentLogRepository paymentLogRepository;
	
	public PaymentLog create(PaymentLog paymentLog) {
		return paymentLogRepository.save(paymentLog);
	}
	
	public Iterable<PaymentLog> getAllPaymentLogs() {
		return paymentLogRepository.findAll();
	}
	
	public PaymentLog getPaymentLog(long id) {
		return paymentLogRepository.findOne(id);
	}
}
