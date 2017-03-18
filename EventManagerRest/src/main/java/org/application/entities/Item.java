package org.application.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Item {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private String name;
	
	@Column(nullable = false)
	private String description;
	
	@Column(nullable = false)
	private double fee;
	
	@Column(nullable = false)
	private int quantity;
	
	@Column(nullable = false)
	@Enumerated(EnumType.STRING)
	private ItemType type;

	public Item() {}
	
	public Item(long id, String name, String description, double fee, int quantity, ItemType type) {
		this.id = id;
		this.name = name;
		this.description = description;
		this.fee = fee;
		this.quantity = quantity;
		this.type = type;
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

	public double getFee() {
		return fee;
	}

	public void setFee(double fee) {
		this.fee = fee;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public ItemType getType() {
		return type;
	}

	public void setType(ItemType type) {
		this.type = type;
	}
	
	public static class ItemBuilder {
		private long id;
		private String name;
		private String description;
		private double fee;
		private int quantity;
		private ItemType type;
		
		public ItemBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public ItemBuilder name(String name) {
			this.name = name;
			return this;
		}
		
		public ItemBuilder description(String description) {
			this.description = description;
			return this;
		}
		
		public ItemBuilder fee(double fee) {
			this.fee = fee;
			return this;
		}
		
		public ItemBuilder quntity(int quantity) {
			this.quantity = quantity;
			return this;
		}
		
		public ItemBuilder type(ItemType type) {
			this.type = type;
			return this;
		}
		
		public Item build() {
			return new Item(id, name, description, fee, quantity, type);
		}
	}
}
