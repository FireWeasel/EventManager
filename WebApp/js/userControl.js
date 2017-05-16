function registerUser(user) {
  $.ajax("http://localhost:8080/users/create", {
    method: "POST",
    contentType: "application/json",
    dataType: "json",
    data: JSON.stringify(user),
    success: function() {
      $('.cd-user-modal').removeClass('is-visible');
      login_selected();
    },
    error: function(xhr) {
        alert("Error " + xhr.status + ": Check console for details");
        console.log(xhr.statis + ": " + xhr.responseText);
    }
  });
}

function loginUser() {
  $.ajax("http://localhost:8080/login", {
    method: "POST",
    data: $("#login-form").serialize(),
    xhrFields: {
      withCredentials: true
    },
    success: function() {
      location.reload();   
    },
    error: function(xhr) {
        alert("Error " + xhr.status + ": Check console for details");
        console.log(xhr.statis + ": " + xhr.responseText);
    }
  });
}

$(document).ready(function() {
  "use strict";

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
});