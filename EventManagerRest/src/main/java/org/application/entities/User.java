package org.application.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;

@Entity
public class User {
	@Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false, unique = true)
    private String username;
	
	@Column(nullable = false, unique = true)
    private String email;
	
	@Column(nullable = false)
	private String password;
	
	@ManyToOne
	private Reservation reservation;
	
	@OneToOne(mappedBy = "owner")
	private Ticket ticket;
	
	@Column(nullable = false)
	private UserRole userRole;

    public User() { 
    	this.userRole = UserRole.USER;
    }

    public User(long id, String username, String email, String password, Ticket ticket) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.password = password;
        this.ticket = ticket;
        this.userRole = UserRole.USER;
    }

	public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getEmail() { 
    	return email; 
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
    
    public long getId() { 
    	return id; 
    }

    public void setId(long id) {
    	this.id = id; 
    }

    public Reservation getReservation() {
		return reservation;
	}

	public void setReservation(Reservation reservation) {
		this.reservation = reservation;
	}
    
    public Ticket getTicket() {
		return ticket;
	}

	public void setTicket(Ticket ticket) {
		this.ticket = ticket;
	}

	public UserRole getUserRole() {
		return userRole;
	}

	public void setUserRole(UserRole userRole) {
		this.userRole = userRole;
	}

	public static class UserBuilder {
        private long id;
        private String username;
        private String email;
        private String password;
        private Ticket ticket;

		public UserBuilder id(long id) {
            this.id = id;
            return this;
        }

        public UserBuilder name(String username) {
            this.username = username;
            return this;
        }

        public UserBuilder address(String email) {
            this.email = email;
            return this;
        }
        
        public UserBuilder ticket(Ticket ticket) {
        	this.ticket = ticket;
        	return this;
        }

        public User build() {
            return new User(id, username, email, password, ticket);
        }
    }
}
