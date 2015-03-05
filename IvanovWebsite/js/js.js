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
	
	//select
	$("span.select").each(function () {
        var Text = $(this).children("select").children("option:selected").text()
        Text = Text.length > 40 ? Text.substring(0, 37) + " ..." : Text;
        $(this).children("span").text(Text);
    });

    $("span.select select").change(function () {
        var Text = $(this).children("option:selected").text();
        Text = Text.length > 40 ? Text.substring(0, 37) + " ..." : Text;
        $(this).parent().children("span").text(Text);
    });
	
});