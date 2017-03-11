package org.application.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Ticket {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private long id;
	
	@Column
	private Boolean checkedIn;
	
	@Column
	private Boolean checkedOut;
	
	@Column(nullable = false)
	private float balance;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Boolean getCheckedIn() {
		return checkedIn;
	}

	public void setCheckedIn(Boolean checkedIn) {
		this.checkedIn = checkedIn;
	}

	public Boolean getCheckedOut() {
		return checkedOut;
	}

	public void setCheckedOut(Boolean checkedOut) {
		this.checkedOut = checkedOut;
	}

	public float getBalance() {
		return balance;
	}

	public void setBalance(float balance) {
		this.balance = balance;
	}
	
	public Ticket() {}

	public Ticket(long id, float balance) {
		this.id = id;
		this.checkedIn = false;
		this.checkedOut = false;
		this.balance = balance;
	}
	
	public void checkIn() {
		this.checkedIn = true;
	}
	
	public void checkOut() {
		this.checkedOut = true;
	}
	
	public static class TicketBuilder {
		private long id;
		private float balance;
		
		public TicketBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public TicketBuilder balance(float balance) {
			this.balance = balance;
			return this;
		}
		
		public Ticket build() {
			return new Ticket(id, balance);
		}
	}
}
