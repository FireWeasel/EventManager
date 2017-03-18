package org.application.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class LoanStand {
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

	public LoanStand() {}
	
	public LoanStand(long id, double revenue) {
		this.id = id;
		this.revenue = revenue;
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
