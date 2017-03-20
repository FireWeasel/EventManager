package org.application.service;

import org.application.entities.Item;
import org.application.repositories.ItemRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ItemService {

	@Autowired
	private ItemRepository itemRepository;
	
	public Item createItem(Item item) {
		return itemRepository.save(item);
	}
	
	public Iterable<Item> getAllItems() {
		return itemRepository.findAll();
	}
	
	public Item getItem(long id) {
		return itemRepository.findOne(id);
	}
	
	public void delete(Long id) {
        itemRepository.delete(id);
    }
}
