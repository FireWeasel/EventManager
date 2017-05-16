function getTicket() {
	return $.ajax("http://localhost:8080/users/current", {
    method: "GET",
    xhrFields: {
      withCredentials: true
    }
  });
}

function purchaseTicket() {
	var ticket = {
		balance: 100
	}
	return $.ajax("http://localhost:8080/users/tickets/create", {
    method: "POST",
    xhrFields: {
      withCredentials: true
    },
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    data: JSON.stringify(ticket)
  });
}