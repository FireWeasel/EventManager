package org.application.controllers;

import org.application.entities.Product;
import org.application.entities.Shop;
import org.application.handlers.NotFoundException;
import org.application.service.ProductService;
import org.application.service.ShopService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ProductRest {
	
	@Autowired
	private ProductService productService;
	
	@Autowired
	private ShopService shopService;
	
	@RequestMapping(value = "/products", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Iterable<Product> getAllProducts() {
    	return productService.getAllProducts();
    }
	
	@RequestMapping(value = "/products/{productId}", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public Product getProduct(@PathVariable("productId") long productId) throws Exception {
		Product product = productService.getProduct(productId);
    	if(product == null) {
    		throw new NotFoundException();
    	}
		return product;
    }
	
	@RequestMapping(value = "/products/{productId}", method = RequestMethod.DELETE)
    public void deleteProduct(@PathVariable("productId") Long id) throws Exception {
		Product product = productService.getProduct(id);
		if(product == null) {
    		throw new NotFoundException();
    	}
    	Shop shop = product.getShop();
    	shop.getProducts().remove(product);
    	shopService.createShop(shop);
    	productService.delete(id);
    }
}
