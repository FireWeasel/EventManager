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
public class Reservation {
	@Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
	private Boolean paid;
	
	@Column(nullable = false)
	@OneToMany(mappedBy="reservation")
	@JsonIgnore
	private List<User> reservedBy;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Boolean getPaid() {
		return paid;
	}

	public void setPaid(Boolean paid) {
		this.paid = paid;
	}

	public List<User> getReservedBy() {
		return reservedBy;
	}

	public void setReservedBy(List<User> reservedBy) {
		this.reservedBy = reservedBy;
	}
	
	public void addReservedBy(User user) {
		this.reservedBy.add(user);
	}
	
	public Reservation() {
		this.paid = false;
		this.reservedBy = new ArrayList<User>();
	}

	public Reservation(long id, Boolean paid) {
		this.id = id;
		this.paid = paid;
		this.reservedBy = new ArrayList<User>();
	}
	
	public static class ReservationBuilder {
		private long id;
		private Boolean paid;
		
		public ReservationBuilder id(long id) {
			this.id = id;
			return this;
		}
		
		public ReservationBuilder paid(Boolean paid) {
			this.paid = paid;
			return this;
		}
		
		public Reservation build() {
			return new Reservation(id, paid);
		}
	}
}
