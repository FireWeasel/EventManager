$(document).ready(function() {
  "use strict";
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

  $("#menu-toggle").click(function(e) {
      e.preventDefault();
      $("#wrapper").toggleClass("toggled");
      RotateArrow();
  });
});
