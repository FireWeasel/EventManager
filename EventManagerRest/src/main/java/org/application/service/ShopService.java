package org.application.service;

import org.application.entities.Shop;
import org.application.repositories.ShopRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ShopService {
	
	@Autowired(required = true)
	private ShopRepository shopRepository;
	
	public Iterable<Shop> getAllShops() {
		return shopRepository.findAll();
	}
	
	public Shop getShop(long id) {
		return shopRepository.findOne(id);
	}
}
