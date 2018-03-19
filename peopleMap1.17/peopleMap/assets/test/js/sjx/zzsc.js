// JavaScript Document
$(document).ready(function(e) {
	/***不需要自动滚动，去掉即可***/
	//time = window.setInterval(function(){
	//	$('.og_next').click();	
	//},5000);
	/***不需要自动滚动，去掉即可***/
    linum = $('.mainlist li').length;//图片数量
    w = linum * 250;//ul宽度
   // w = 250;
	$('.piclist').css('width', w + 'px');//ul宽度
	$('.swaplist').html($('.mainlist').html());//复制内容

	linum2 = $('.mainlist2 li').length;//图片数量
	w2 = linum2* 250;//ul宽度
	$('.piclist2').css('width', w2 + 'px');//ul宽度
	$('.swaplist2').html($('.mainlist2').html());//复制内容

	
	
	$('.og_next').click(function(){
		
		if($('.swaplist,.mainlist').is(':animated')){
			$('.swaplist,.mainlist').stop(true,true);
		}
		
		if($('.mainlist li').length>2){//多于4张图片
			ml = parseInt($('.mainlist').css('left'));//默认图片ul位置
			sl = parseInt($('.swaplist').css('left'));//交换图片ul位置
			if(ml<=0 && ml>w*-1){//默认图片显示时
				$('.swaplist').css({left: '250px'});//交换图片放在显示区域右侧
				$('.mainlist').animate({left: ml - 250 + 'px'},'slow');//默认图片滚动				
				if(ml==(w-250)*-1){//默认图片最后一屏时
					$('.swaplist').animate({left: '0px'},'slow');//交换图片滚动
				}
			}else{//交换图片显示时
				$('.mainlist').css({left: '250px'})//默认图片放在显示区域右
				$('.swaplist').animate({left: sl - 250 + 'px'},'slow');//交换图片滚动
				if(sl==(w-250)*-1){//交换图片最后一屏时
					$('.mainlist').animate({left: '0px'},'slow');//默认图片滚动
				}
			}
		}
	})
	$('.og_prev').click(function(){
		
		if($('.swaplist,.mainlist').is(':animated')){
			$('.swaplist,.mainlist').stop(true,true);
		}
		
		if($('.mainlist li').length>2){
			ml = parseInt($('.mainlist').css('left'));
			sl = parseInt($('.swaplist').css('left'));
			if(ml<=0 && ml>w*-1){
				$('.swaplist').css({left: w * -1 + 'px'});
				$('.mainlist').animate({left: ml + 250 + 'px'},'slow');				
				if(ml==0){
					$('.swaplist').animate({left: (w - 250) * -1 + 'px'},'slow');
				}
			}else{
				$('.mainlist').css({left: (w - 250) * -1 + 'px'});
				$('.swaplist').animate({left: sl + 250 + 'px'},'slow');
				if(sl==0){
					$('.mainlist').animate({left: '0px'},'slow');
				}
			}
		}
	})

	$('.og_next2').click(function () {

	    if ($('.swaplist2,.mainlist2').is(':animated')) {
	        $('.swaplist2,.mainlist2').stop(true, true);
	    }

	    if ($('.mainlist2 li').length > 4) {//多于4张图片
	        m2 = parseInt($('.mainlist2').css('left'));//默认图片ul位置
	        s2 = parseInt($('.swaplist2').css('left'));//交换图片ul位置
	        if (m2 <= 0 && m2 > w2 * -1) {//默认图片显示时
	            $('.swaplist2').css({ left: '1000px' });//交换图片放在显示区域右侧
	            $('.mainlist2').animate({ left: m2 - 1000 + 'px' }, 'slow');//默认图片滚动				
	            if (m2 == (w2 - 1000) * -1) {//默认图片最后一屏时
	                $('.swaplist2').animate({ left: '0px' }, 'slow');//交换图片滚动
	            }
	        } else {//交换图片显示时
	            $('.mainlist2').css({ left: '1000px' })//默认图片放在显示区域右
	            $('.swaplist2').animate({ left: s2 - 1000 + 'px' }, 'slow');//交换图片滚动
	            if (s2 == (w2 - 1000) * -1) {//交换图片最后一屏时
	                $('.mainlist2').animate({ left: '0px' }, 'slow');//默认图片滚动
	            }
	        }
	    }
	})
	$('.og_prev2').click(function () {

	    if ($('.swaplist2,.mainlist2').is(':animated')) {
	        $('.swaplist2,.mainlist2').stop(true, true);
	    }

	    if ($('.mainlist2 li').length > 4) {
	        m2 = parseInt($('.mainlist2').css('left'));
	        s2 = parseInt($('.swaplist2').css('left'));
	        if (m2 <= 0 && m2 > w * -1) {
	            $('.swaplist2').css({ left: w2 * -1 + 'px' });
	            $('.mainlist2').animate({ left: m2 + 1000 + 'px' }, 'slow');
	            if (m2 == 0) {
	                $('.swaplist2').animate({ left: (w2 - 1000) * -1 + 'px' }, 'slow');
	            }
	        } else {
	            $('.mainlist2').css({ left: (w2 - 1000) * -1 + 'px' });
	            $('.swaplist2').animate({ left: s2 + 1000 + 'px' }, 'slow');
	            if (s2 == 0) {
	                $('.mainlist2').animate({ left: '0px' }, 'slow');
	            }
	        }
	    }
	})

	
  
});

$(document).ready(function(){
	$('.og_prev,.og_next').hover(function(){
			$(this).fadeTo('fast',1);
		},function(){
			$(this).fadeTo('fast',0.7);
		})
	$('.og_prev2,.og_next2').hover(function () {
	    $(this).fadeTo('fast', 1);
	}, function () {
	    $(this).fadeTo('fast', 0.7);
	})

})

