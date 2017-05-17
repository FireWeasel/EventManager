function registerUser(user) {
  $.ajax("http://localhost:8080/users/create", {
    method: "POST",
    contentType: "application/json; charset=utf-8",
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

function getUser() {
  return $.ajax("http://localhost:8080/users/current", {
    method: "GET",
    xhrFields: {
      withCredentials: true
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
      $("#user-control").hide();
      $("#logout, #tickets-link, #camps-link").show();
    },
    error: function() {
      $("#logout, #tickets-link, #camps-link").hide();
      $("#user-control").show();
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