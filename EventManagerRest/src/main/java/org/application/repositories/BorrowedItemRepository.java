package org.application.repositories;

import org.application.entities.BorrowedItem;
import org.springframework.data.repository.CrudRepository;

public interface BorrowedItemRepository extends CrudRepository<BorrowedItem, Long> {

}
