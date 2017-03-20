package org.application.entities;

import javax.persistence.Column;
import javax.persistence.*;

@Entity
public class Camp {
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
	private boolean checkedIn;

	public Camp(){ }

    public Camp(long id, String name, String description, double price) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.checkedIn = false;
    }

    public String getName() { return name; }

    public void setName(String name) {
        this.name = name;
    }

    public long getId() { return id; }

    public void setId(long id) { this.id = id; }
    
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

	public boolean isCheckedIn() {
		return checkedIn;
	}

	public void setCheckedIn(boolean checkedIn) {
		this.checkedIn = checkedIn;
	}
	
    public static class CampBuilder {
        private long id;
        private String name;
        private String description;
        private double price;

        public CampBuilder id(long id) {
            this.id = id;
            return this;
        }

        public CampBuilder name(String name) {
            this.name = name;
            return this;
        }

        public CampBuilder description(String description) {
            this.description = description;
            return this;
        }

        public CampBuilder price(double price) {
            this.price = price;
            return this;
        }
        
        public Camp build() {
            return new Camp(id, name, description, price);
        }
    }
}
