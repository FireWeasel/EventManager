package org.application.entities;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToMany;
import javax.persistence.ManyToOne;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
public class Product {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private String name;
	
	@Column(nullable = false)
	private String description;
	
	@Column(nullable = false)
	private double price;
	
	@Column(nullable = false)
	private int quantity;
	
	@Column(nullable = false)
	@Enumerated(EnumType.STRING)
	private ProductType type;
	
	@ManyToOne(fetch=FetchType.LAZY)
	@JsonIgnore
	private Shop shop;
	
	@ManyToMany(mappedBy = "purchases")
	@JsonIgnore
    private List<Ticket> purchasedBy;

	public Product() {}
	
	public Product(long id, String name, String description, double price, int quantity, ProductType type, Shop shop) {
		this.id = id;
		this.name = name;
		this.description = description;
		this.price = price;
		this.quantity = quantity;
		this.type = type;
		this.shop = shop;
		this.purchasedBy = new ArrayList<Ticket>();
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public ProductType getType() {
		return type;
	}

	public void setType(ProductType type) {
		this.type = type;
	}
	
	public Shop getShop() {
		return shop;
	}

	public void setShop(Shop shop) {
		this.shop = shop;
	}
	
	public List<Ticket> getPurchasedBy() {
		return purchasedBy;
	}
	
	public void setPurchasedBy(List<Ticket> purchasedBy) {
		this.purchasedBy = purchasedBy;
	}
	
	public static class ProductBuilder {
		private long id;
		private String name;
		private String description;
		private double price;
		private int quantity;
		private ProductType type;
		private Shop shop;
		
		public ProductBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public ProductBuilder name(String name) {
			this.name = name;
			return this;
		}
		
		public ProductBuilder description(String description) {
			this.description = description;
			return this;
		}
		
		public ProductBuilder price(double price) {
			this.price = price;
			return this;
		}
		
		public ProductBuilder quntity(int quantity) {
			this.quantity = quantity;
			return this;
		}
		
		public ProductBuilder type(ProductType type) {
			this.type = type;
			return this;
		}
		
		public ProductBuilder shop(Shop shop) {
			this.shop = shop;
			return this;
		}
		
		public Product build() {
			return new Product(id, name, description, price, quantity, type, shop);
		}
	}
}
