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

function isLogged() {
  $.ajax("http://localhost:8080/users/current", {
    method: "GET",
    xhrFields: {
        withCredentials: true
    },
    success: function() {
      $("#userControl").hide();
      $("#logout").show();
      $("#tickets-link").show();
    },
    error: function() {
      $("#logout").hide();
      $("#userControl").show();
      $("#tickets-link").hide();
    }
  });
}

function logout() {
  $.ajax("http://localhost:8080/logout", {
    method: "GET",
    xhrFields: {
        withCredentials: true
    },
    success: function() {
      location.reload();   
    },
    error: function(xhr) {
      if (xhr.status == 404) {
        location.reload();
      }
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

  $("#tickets-link").click(function(e) {
    $("#tickets-container").show(1000);
    $("#events-container").hide(1000);
    $("#recent-news-container").hide(1000);
    getTicket().then(function(data) {
      if(data.ticket != null) {
        $("#purchase-btn").hide();
        $("#download-ticket-btn").show();
      }
    });
  });

  $("#dashboard-link").click(function(e) {
    $("#events-container").show(1000);
    $("#recent-news-container").show(1000);
    $("#tickets-container").hide(1000);
    $("#ticket").hide();
  });

  $("#purchase-btn").click(function(e) {
    purchaseTicket().then(function(data) {
      $("#purchase-btn").hide();
      $("#download-ticket-btn").show();
    });
  });

  $("#download-ticket-btn").click(function(e) {
    generateTicket();
    $("#download-ticket-btn").hide();
    $("#ticket").show();
  });

  isLogged();
});