package org.application.handlers;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value=HttpStatus.INTERNAL_SERVER_ERROR,reason="Camp hasn't been reserved.")
public class CampNotReservedException extends Exception {
	private static final long serialVersionUID = 100L;
}
