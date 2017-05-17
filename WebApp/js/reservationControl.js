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

function getReservationUsers(id) {
  return $.ajax("http://localhost:8080/reservations/" + id + "/users", {
    method: "GET",
    xhrFields: {
      withCredentials: true
    }
  });
}

function populateReservationDetails(reservation) { 
  getReservationUsers(reservation.id).then(function(data) {
    $("#reservation-details").show();
    $("#reservation-users").empty();
    data.forEach(function(user) {
      var item = $("<li>" + user.username + " - " + user.email + "</li>");
      $("#reservation-users").append(item);
    });
    if (data.length > 5) {
      $("#user-reservation").hide();
    } else {
      $("#user-reservation").show();
    }
    if (!reservation.paid) {
      $("#finalize-reservation-btn").show();
    } else {
      $("#user-reservation").hide();
      $("#finalize-reservation-btn").hide();
    }
  });
}

function addToReservation(id) {
  var email = $("#add-user-email").val();
  return $.ajax("http://localhost:8080/reservations/" + id + "/add/" + email, {
    method: "PUT",
    xhrFields: {
      withCredentials: true
    },
    contentType: "application/json; charset=utf-8",
    dataType: "json"
  });
}

function payReservation(id) {
  return $.ajax("http://localhost:8080/reservations/" + id + "/payment", {
    method: "PUT",
    xhrFields: {
      withCredentials: true
    },
    contentType: "application/json; charset=utf-8",
    dataType: "json"
  });
}