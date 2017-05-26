package org.application.repositories;

import org.application.entities.PaymentLog;
import org.springframework.data.repository.CrudRepository;

public interface PaymentLogRepository extends CrudRepository<PaymentLog, Long> {

}
