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

function depositToTicket() {
  var ticket = {
    balance: $("#deposit").val()
  }
  $.ajax("http://localhost:8080/users/tickets/deposit", {
    method: "PUT",
    xhrFields: {
      withCredentials: true
    },
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    data: JSON.stringify(ticket),
    success: function() {
      $("#deposit").val("");
      alert("Deposited " + ticket.balance + " successfully!");
    }
  });
}