$(function(){
	$(window).on('load', function () {
		$('.prlx').parallax("50%", 0.1);
	});
	
	$('.tabs nav a').click(function(){
		$('.tabs nav a').removeClass('active');
		$(this).addClass('active');
		
				
		var activeNav = $(this).attr('data-tab-nav');
		var current = $('.tabs').find($('.tab[data-tab-content=' + activeNav +']'));
		
		$('.tabs .tab').removeClass('show');
		current.addClass('show');
				
		return false;
	});
	
	
	
	
});