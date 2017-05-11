package org.application.controllers;

import java.util.List;

import org.application.entities.Product;
import org.application.entities.Shop;
import org.application.handlers.NotFoundException;
import org.application.service.ProductService;
import org.application.service.ShopService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ShopRest {

	@Autowired
	private ShopService shopService;
	@Autowired
	private ProductService productService;
	
	@RequestMapping(value = "/shops/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Shop createShop(@RequestBody Shop shop) {
        return shopService.createShop(shop);
    }
	
	@RequestMapping(value = "/shops", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Shop> getAllShops() {
    	return shopService.getAllShops();
    }
	
	@RequestMapping(value = "/shops/{shopId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Shop getShop(@PathVariable("shopId") long shopId) throws Exception {
		Shop shop = shopService.getShop(shopId);
		if (shop == null) {
			throw new NotFoundException();
		}
    	return shop;
    }
	
	@RequestMapping(value = "/shops/{shopId}/products/create", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Shop addProduct(@PathVariable("shopId") long shopId, @RequestBody Product product) throws Exception {
    	Shop shop = shopService.getShop(shopId);
    	if (shop == null) {
			throw new NotFoundException();
		}
		product.setShop(shop);
		shop.addProduct(product);
		productService.createProduct(product);
		return shopService.createShop(shop);
    }
	
	@RequestMapping(value = "/shops/{shopId}/products", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public List<Product> getShopProducts(@PathVariable("shopId") long shopId) {
    	return shopService.getShop(shopId).getProducts();
    }
}
