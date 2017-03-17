package org.application.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Shop {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private double revenue;

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

	public Shop() {}
	
	public Shop(long id, double revenue) {
		this.id = id;
		this.revenue = revenue;
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
