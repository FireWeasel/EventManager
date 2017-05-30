package org.application.service;

import org.application.entities.BorrowedItem;
import org.application.repositories.BorrowedItemRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class BorrowedItemService {
	
	@Autowired
	private BorrowedItemRepository borrowedItemRepository;
	
	public BorrowedItem createBorrowedItem(BorrowedItem borrowedItem) {
		return borrowedItemRepository.save(borrowedItem);
	}

	public BorrowedItem getBorrowedItem(Long id) {
		return borrowedItemRepository.findOne(id);
	}
}
