var degrees = 0;
function RotateArrow() {
    var $elem = $('#menu-toggle');

    $({deg: degrees}).animate({deg: degrees += 180}, {
        duration: 1000,
        step: function(now) {
            $elem.css({
                transform: 'rotate(' + now + 'deg)'
            });
        }
    });
}

$(document).ready(function() {
  "use strict";

  $("#menu-toggle").click(function(e) {
      e.preventDefault();
      $("#wrapper").toggleClass("toggled");
      RotateArrow();
  });

  $("#logout").click(function() {
    logout();
  });

  $("#dashboard-link").click(function(e) {
    $("#events-container").show(1000);
    $("#recent-news-container").show(1000);
    $("#events-full-container").hide(1000);
    $("#camps-container").hide(1000);
    $("#tickets-container").hide(1000);
    $("#about-container").hide(1000);
    $("#contact-container").hide(1000);
  });

  $("#events-link").click(function(e) {
    $("#events-full-container").show(1000);
    $("#events-container").hide(1000);
    $("#recent-news-container").hide(1000);
    $("#camps-container").hide(1000);
    $("#tickets-container").hide(1000);
    $("#about-container").hide(1000);
    $("#contact-container").hide(1000);
  });

  $("#camps-link").click(function(e) {
    $("#camps-container").show(1000);
    $("#events-container").hide(1000);
    $("#recent-news-container").hide(1000);
    $("#events-full-container").hide(1000);
    $("#tickets-container").hide(1000);
    $("#about-container").hide(1000);
    $("#contact-container").hide(1000);
    getUser().then(function(data) {
      if (data.ticket == null) {
        $("#reserve-btn").hide();
      } else {
        if(data.reservation != null) {
          $("#reserve-btn").hide();
          populateReservationDetails(data.reservation);
        } else {
          $("#reservation-details").hide();
        }
      }
    });
  });

  $("#tickets-link").click(function(e) {
    $("#tickets-container").show(1000);
    $("#events-container").hide(1000);
    $("#recent-news-container").hide(1000);
    $("#events-full-container").hide(1000);
    $("#camps-container").hide(1000);
    $("#about-container").hide(1000);
    $("#contact-container").hide(1000);
    getUser().then(function(data) {
      if(data.ticket != null) {
        $("#ticket-amount").text("Ticket amount: " + data.ticket.balance + "$");
        $("#purchase-btn").hide();
        $("#download-ticket-btn").attr("href", "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=" + data.ticket.id);
        $("#ticket-details").show();
        $("#ticket-amount").show();
      }
    });
  });

  $("#about-link").click(function(e) {
    $("#about-container").show(1000);
    $("#events-container").hide(1000);
    $("#recent-news-container").hide(1000);
    $("#events-full-container").hide(1000);
    $("#camps-container").hide(1000);
    $("#tickets-container").hide(1000);
    $("#contact-container").hide(1000);
  });

  $("#contact-link").click(function(e) {
    $("#contact-container").show(1000);
    $("#events-container").hide(1000);
    $("#recent-news-container").hide(1000);
    $("#events-full-container").hide(1000);
    $("#camps-container").hide(1000);
    $("#tickets-container").hide(1000);
    $("#about-container").hide(1000);
  });

  $("#purchase-btn").click(function(e) {
    purchaseTicket().then(function(data) {
      $("#purchase-btn").hide();
      $("#download-ticket-btn").attr("href", "https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=" + data.ticket.id);
      $("#ticket-details").show();
      $("#reserve-btn").show();
      $("#ticket-amount").show();
    });
  });

  $("#register-form").submit(function(e) {
    e.preventDefault();
    var user = {
      username: $("#signup-username").val(),
      email: $("#signup-email").val(),
      password: $("#signup-password").val()
    };
    registerUser(user);
  });

  $("#login-form").submit(function(e) {
    e.preventDefault();
    loginUser();
  });

  $("#reserve-btn").click(function(e) {
    createReservation().then(function(data) {
      $("#reserve-btn").hide();
      $("#reservation-details, #user-reservation, #finalize-reservation-btn").show();
    });
  });

  $("#add-reservation-btn").click(function() {
    getUser().then(function(data) {
      addToReservation(data.reservation.id).then(function() {
        populateReservationDetails(data.reservation);
      });
    });
  });

  $("#finalize-reservation-btn").click(function() {
    getUser().then(function(data) {
      payReservation(data.reservation.id).then(function() {
        $("#user-reservation, #finalize-reservation-btn").hide();
      });
    });
  });

  $("#deposit-btn").click(function() {
    depositToTicket();
  });

  isLogged();
  populateEventDetails();
});
