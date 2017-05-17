package org.application.repositories;

import java.util.List;

import org.application.entities.Camp;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

public interface CampRepository extends CrudRepository<Camp, Long> {
	
	@Query("SELECT c FROM Camp c WHERE c.reservation IS NULL")
	public List<Camp> findFree();
}
