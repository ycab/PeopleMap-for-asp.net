$(function(){
	$("#keyword").focus(function(event) {
		/* Act on the event */
		var val = $.trim($(this).val());
		if(val=="Search"){
			$(this).val("");
		}
	}).blur(function(event) {
		/* Act on the event */
		var val = $.trim($(this).val());
		if(val==""){
			$(this).val("Search");
		}
	});

	$("#search-submit").click(function(event) {
		/* Act on the event */
		event.preventDefault();
		var val = $.trim($("#keyword").val());
		if(val!==""&& val!=="Search"){
			$("#searchform").submit();
		}else{
			alert("请输入关键词");
		}
	});
	
	$(".wp-menu li").hover(function() {
			/* Stuff to do when the mouse enters the element */
			$(this).addClass("n6");
			$(this).siblings().find('.sub-menu').stop(true,true).slideUp(150)
			$(this).children('.sub-menu').stop(true,true).slideDown(200);
	}, function() {
			/* Stuff to do when the mouse leaves the element */
			$(this).removeClass("n6");
			$(this).children('.sub-menu').stop(true,true).slideUp(150);
    });
	$(".links-wrap").each(function(index, el) {
		$(el).click(function() {
			/* Stuff to do when the mouse enters the element */
			$(this).addClass('wrap-open').children('.link-items').toggle(300).present().removeClass('wrap-open')
		});
	});
	$(document).bind("click",function(e){
		var target  = $(e.target);
		if(target.closest(".links-wrap").length == 0){
			$(".link-items").hide();
		}
	})	
	
});