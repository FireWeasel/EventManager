package org.application.entities;


import javax.persistence.Column;
import javax.persistence.*;

@Entity
public class Event {
	@Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    private long id;
	
	@Column(nullable = false)
    private String name;
	
	@Column(nullable = false)
    private String address;

    public Event(){ }

    public Event(long id, String name, String address) {
        this.id = id;
        this.name = name;
        this.address = address;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getName() { return name; }

    public void setName(String name) {
        this.name = name;
    }

    public long getId() { return id; }

    public void setId(long id) { this.id = id; }

    public static class EventBuilder {
        private long id;
        private String name;
        private String address;

        public EventBuilder id(long id) {
            this.id = id;
            return this;
        }

        public EventBuilder name(String name) {
            this.name = name;
            return this;
        }

        public EventBuilder address(String address) {
            this.address = address;
            return this;
        }

        public Event build() {
            return new Event(id, name, address);
        }
    }
}
