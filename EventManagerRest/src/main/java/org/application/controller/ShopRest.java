package org.application.controller;

import org.application.entities.Shop;
import org.application.service.ShopService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ShopRest {

	@Autowired
	private ShopService shopService;
	
	@RequestMapping(value = "/shops", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Shop> getAllShops() {
    	return shopService.getAllShops();
    }
	
	@RequestMapping(value = "/shops/{shopId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Shop getShop(@PathVariable("shopId") long shopId) {
    	return shopService.getShop(shopId);
    }
}
