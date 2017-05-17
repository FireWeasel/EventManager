package org.application.repositories;

import org.application.entities.User;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

public interface UserRepository extends CrudRepository<User, Long> {

	@Query("SELECT u FROM User u WHERE LOWER(u.username) = LOWER(:username)")
	public User findByUsername(@Param("username") String username);

	@Query("SELECT u FROM User u WHERE LOWER(u.email) = LOWER(:email)")
	public User findByEmail(@Param("email") String email);
}
