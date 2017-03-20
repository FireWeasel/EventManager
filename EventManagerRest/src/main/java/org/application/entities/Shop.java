package org.application.entities;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
public class Shop {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private double revenue;
	
	@Column(nullable = false)
	@OneToMany(mappedBy="shop")
	@JsonIgnore
	private List<Product> products;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public double getRevenue() {
		return revenue;
	}

	public void setRevenue(double revenue) {
		this.revenue = revenue;
	}
	
	public List<Product> getProducts() {
		return products;
	}

	public void setProducts(List<Product> products) {
		this.products = products;
	}
	
	public void addProduct(Product product) {
		this.products.add(product);
	}

	public Shop() {}
	
	public Shop(long id, double revenue) {
		this.id = id;
		this.revenue = revenue;
		this.products = new ArrayList<Product>();
	}

	public static class ShopBuilder {
		private long id;
		private double revenue;
		
		public ShopBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public ShopBuilder revenue(double revenue) {
			this.revenue = revenue;
			return this;
		}
		
		public Shop build() {
			return new Shop(this.id, this.revenue);
		}
	}
}
