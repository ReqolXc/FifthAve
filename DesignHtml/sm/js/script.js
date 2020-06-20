$('.ui.sticky').sticky();
$('.ui.rating').rating();
$('.special.cards .image').dimmer({ on: 'hover' });

$('button.back-to-top').click(function () {
  $('html, body').animate({
    scrollTop: 0
  }, 700);
  return false;
});


$(window).scroll(function () {
  upButtonFunc();
});



var amountScrolled = 500;
var upButtonFunc = function () {
  if ($(window).scrollTop() >= amountScrolled && $('button.back-to-top').hasClass('hidden') && !$('button.back-to-top').hasClass('animating'))
    $('button.back-to-top').transition('scale');

  if ($(window).scrollTop() < amountScrolled && $('button.back-to-top').hasClass('visible') && !$('button.back-to-top').hasClass('animating'))
    $('button.back-to-top').transition('scale');
};