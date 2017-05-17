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

function generateTicket() {
	getUser().then(function(data) {
		$("#ticket-name").text(data.username);
		$("#ticket-email").text(data.email);
		$("#qr-code").attr("src", "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" + data.ticket.id);
	});
}