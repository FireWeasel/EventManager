package org.application.controllers;

import org.application.entities.Product;
import org.application.entities.Shop;
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
    public Product getProduct(@PathVariable("productId") long productId) {
    	return productService.getProduct(productId);
    }
	
	@RequestMapping(value = "/products/{productId}", method = RequestMethod.PUT, produces = "application/json", consumes = "application/json")
    @ResponseBody
    public Product updateProduct(@RequestBody Product product, @PathVariable("productId") Long id) {
    	Product fromDb = productService.getProduct(id);
    	fromDb.setName(product.getName());
    	fromDb.setDescription(product.getDescription());
    	fromDb.setPrice(product.getPrice());
    	fromDb.setQuantity(product.getQuantity());
    	fromDb.setType(product.getType());
    	fromDb.setShop(product.getShop());
    	return productService.createProduct(fromDb);
    }
	
	@RequestMapping(value = "/products/{productId}", method = RequestMethod.DELETE)
    public void deleteProduct(@PathVariable("productId") Long id) {
		Product product = productService.getProduct(id);
    	Shop shop = product.getShop();
    	shop.getProducts().remove(product);
    	shopService.createShop(shop);
    	productService.delete(id);
    }
}
