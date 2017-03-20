package org.application.service;

import org.application.entities.Reservation;
import org.application.repositories.ReservationRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ReservationService {
	
	@Autowired
	private ReservationRepository reservationRepository;
	
	public Reservation createReservation(Reservation reservation) {
		return reservationRepository.save(reservation);
	}
	
	public Reservation getReservation(long id) {
		return reservationRepository.findOne(id);
	}
	
	public Iterable<Reservation> getAllReservations() {
		return reservationRepository.findAll();
	}
}
