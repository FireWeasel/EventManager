function createReservation() {
	return $.ajax("http://localhost:8080/users/reservations/create", {
    method: "POST",
    xhrFields: {
      withCredentials: true
    },
    contentType: "application/json; charset=utf-8",
    dataType: "json"
	});
}