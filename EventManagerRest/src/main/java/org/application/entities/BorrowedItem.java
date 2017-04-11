package org.application.entities;

import java.text.SimpleDateFormat;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
public class BorrowedItem {
	@Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JsonIgnore
	private Ticket ticket;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JsonIgnore
	private Item item;
	
	@Column(nullable = false)
	private Date dateBorrowed;
	
	@Column(nullable = false)
	private Boolean returned;
	
	public BorrowedItem() {
		this.dateBorrowed = new Date();
		this.returned = false;
	}

	public BorrowedItem(long id, Ticket ticket, Item item) {
		this.id = id;
		this.ticket = ticket;
		this.item = item;
		this.dateBorrowed = new Date();
		this.returned = false;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Ticket getTicket() {
		return ticket;
	}

	public void setTicket(Ticket ticket) {
		this.ticket = ticket;
	}

	public Item getItem() {
		return item;
	}

	public void setItem(Item item) {
		this.item = item;
	}

	public String getDateBorrowed() {
		SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		return format.format(dateBorrowed);
	}

	public void setDateBorrowed() {
		this.dateBorrowed = new Date();
	}
	
	public Boolean getReturned() {
		return returned;
	}

	public void setReturned(Boolean returned) {
		this.returned = returned;
	}

	public static class BorrowedItemBuilder {
		private long id;
		private Ticket ticket;
		private Item item;
		
		public BorrowedItemBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public BorrowedItemBuilder ticket(Ticket ticket) {
			this.ticket = ticket;
			return this;
		}
		
		public BorrowedItemBuilder item(Item item) {
			this.item = item;
			return this;
		}
		
		public BorrowedItem build() {
			return new BorrowedItem(id, ticket, item);
		}
	}
}
