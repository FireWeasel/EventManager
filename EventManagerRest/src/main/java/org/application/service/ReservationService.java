package org.application.service;

import org.application.entities.Camp;
import org.application.entities.Reservation;
import org.application.entities.User;
import org.application.repositories.ReservationRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ReservationService {
	
	@Autowired
	private ReservationRepository reservationRepository;
	@Autowired
	private UserService userService;
	@Autowired
	private CampService campService;
	
	public Reservation createReservation(Reservation reservation) {
		return reservationRepository.save(reservation);
	}
	
	public Reservation getReservation(long id) {
		return reservationRepository.findOne(id);
	}
	
	public Iterable<Reservation> getAllReservations() {
		return reservationRepository.findAll();
	}

	public void deleteReservation(Long id) {
		Reservation reservation = getReservation(id);
    	for(final User user : reservation.getReservedBy()) {
    		user.setReservation(null);
    		userService.createUser(user);
    	}
    	Camp camp = reservation.getCamp();
    	camp.setReservation(null);
    	campService.createCamp(camp);
		reservationRepository.delete(id);
	}
}
