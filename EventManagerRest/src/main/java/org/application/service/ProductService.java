package org.application.service;

import org.application.entities.Product;
import org.application.repositories.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ProductService {

	@Autowired
	private ProductRepository productRepository;
	
	public Product createProduct(Product product) {
		return productRepository.save(product);
	}
	
	public Iterable<Product> getAllProducts() {
		return productRepository.findAll();
	}
	
	public Product getProduct(long id) {
		return productRepository.findOne(id);
	}
	
	public void delete(long id) {
		productRepository.delete(id);
	}
}
