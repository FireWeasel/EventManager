package org.application.entities;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class PaymentLog {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private Date date;
	
	@Column(nullable = false)
	private double amount;
	
	@Column(nullable = false)
	private Ticket ticket;
	
	public PaymentLog() {}
	
	public PaymentLog(long id, double amount, Ticket ticket) {
		this.id = id;
		this.amount = amount;
		this.date = new Date();
		this.ticket = ticket;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	public double getAmount() {
		return amount;
	}

	public void setAmount(double amount) {
		this.amount = amount;
	}

	public Ticket getTicket() {
		return ticket;
	}

	public void setTicket(Ticket ticket) {
		this.ticket = ticket;
	}
	
	public static class PaymentLogBuilder {
		private long id;
		private double amount;
		private Ticket ticket;
		
		public PaymentLogBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public PaymentLogBuilder ticket(Ticket ticket) {
			this.ticket = ticket;
			return this;
		}
		
		public PaymentLogBuilder amount(double amount) {
			this.amount = amount;
			return this;
		}
		
		public PaymentLog build() {
			return new PaymentLog(id, amount, ticket);
		}
	}
}
