package org.application.entities;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity
public class LoanStand {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private double revenue;

	@Column
	@OneToMany
	private List<Item> items;

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

	public List<Item> getItems() {
		return items;
	}

	public void setItems(List<Item> items) {
		this.items = items;
	}
	
	public void addItem(Item item) {
		this.items.add(item);
	}
	
	public LoanStand() {}
	
	public LoanStand(long id, double revenue) {
		this.id = id;
		this.revenue = revenue;
		this.items = new ArrayList<Item>();
	}
	
	public static class LoanStandBuilder {
		private long id;
		private double revenue;
		
		public LoanStandBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public LoanStandBuilder revenue(double revenue) {
			this.revenue = revenue;
			return this;
		}
		
		public LoanStand build() {
			return new LoanStand(this.id, this.revenue);
		}
	}
}
