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
    },
    error: function() {
      $("#logout").hide();
      $("#userControl").show(); 
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

  isLogged();
});