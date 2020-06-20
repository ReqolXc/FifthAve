$('.special.cards .image').dimmer({
    on: 'hover'
  });

$('button.back-to-top').click(function() {
	$('html, body').animate({
		scrollTop: 0
	}, 700);
	return false;
});