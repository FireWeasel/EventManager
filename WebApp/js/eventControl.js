function getEvents() {
  return $.ajax("http://localhost:8080/events", {
    method: "GET"
  });
}

function populateEventDetails() { 
  getEvents().then(function(data) {
    $(".events-details").empty();
    data.forEach(function(eventObj) {
      var eventName = $("<h3>" + eventObj.name + "</h3>");
      var eventAddress = $("<h5>" + eventObj.address + "</h5>");
      var eventDescription = $("<p>" + eventObj.description + "</p>");
      $(".events-details").append(eventName);
      $(".events-details").append(eventAddress);
      $(".events-details").append(eventDescription);
      $(".events-details").append("<hr>");
    });
  });
}