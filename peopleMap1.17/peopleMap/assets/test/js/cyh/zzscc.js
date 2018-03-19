// JavaScript Document
$(document).ready(function (e) {
    /***不需要自动滚动，去掉即可***/
    /***time = window.setInterval(function(){
		$('.og_next').click();	
	},5000);***/
    /***不需要自动滚动，去掉即可***/
    linum = $('.mainlist li').length;//图片数量
    w = linum * 250;//ul宽度
    $('.piclist').css('width', w + 'px');//ul宽度
    $('.swaplist').html($('.mainlist').html());//复制内容

    linum1 = $('.mainlist1 li').length;//图片数量
    w1 = linum1 * 250;//ul宽度
    $('.piclist1').css('width', w1 + 'px');//ul宽度
    $('.swaplist1').html($('.mainlist1').html());//复制内容

    $('.og_next').click(function () {

        if ($('.swaplist,.mainlist').is(':animated')) {
            $('.swaplist,.mainlist').stop(true, true);
        }

        if ($('.mainlist li').length > 4) {//多于4张图片
            ml = parseInt($('.mainlist').css('left'));//默认图片ul位置
            sl = parseInt($('.swaplist').css('left'));//交换图片ul位置
            if (ml <= 0 && ml > w * -1) {//默认图片显示时
                $('.swaplist').css({ left: '1000px' });//交换图片放在显示区域右侧
                $('.mainlist').animate({ left: ml - 1000 + 'px' }, 'slow');//默认图片滚动				
                if (ml == (w - 1000) * -1) {//默认图片最后一屏时
                    $('.swaplist').animate({ left: '0px' }, 'slow');//交换图片滚动
                }
            } else {//交换图片显示时
                $('.mainlist').css({ left: '1000px' })//默认图片放在显示区域右
                $('.swaplist').animate({ left: sl - 1000 + 'px' }, 'slow');//交换图片滚动
                if (sl == (w - 1000) * -1) {//交换图片最后一屏时
                    $('.mainlist').animate({ left: '0px' }, 'slow');//默认图片滚动
                }
            }
        }
    })
    $('.og_prev').click(function () {

        if ($('.swaplist,.mainlist').is(':animated')) {
            $('.swaplist,.mainlist').stop(true, true);
        }

        if ($('.mainlist li').length > 4) {
            ml = parseInt($('.mainlist').css('left'));
            sl = parseInt($('.swaplist').css('left'));
            if (ml <= 0 && ml > w * -1) {
                $('.swaplist').css({ left: w * -1 + 'px' });
                $('.mainlist').animate({ left: ml + 1000 + 'px' }, 'slow');
                if (ml == 0) {
                    $('.swaplist').animate({ left: (w - 1000) * -1 + 'px' }, 'slow');
                }
            } else {
                $('.mainlist').css({ left: (w - 1000) * -1 + 'px' });
                $('.swaplist').animate({ left: sl + 1000 + 'px' }, 'slow');
                if (sl == 0) {
                    $('.mainlist').animate({ left: '0px' }, 'slow');
                }
            }
        }
    })



    $('.og_next1').click(function () {

        if ($('.swaplist1,.mainlist1').is(':animated')) {
            $('.swaplist1,.mainlist1').stop(true, true);
        }

        if ($('.mainlist1 li').length > 4) {//多于4张图片
            ml = parseInt($('.mainlist1').css('left'));//默认图片ul位置
            sl = parseInt($('.swaplist1').css('left'));//交换图片ul位置
            if (ml <= 0 && ml > w * -1) {//默认图片显示时
                $('.swaplist1').css({ left: '1000px' });//交换图片放在显示区域右侧
                $('.mainlist1').animate({ left: ml - 1000 + 'px' }, 'slow');//默认图片滚动				
                if (ml == (w - 1000) * -1) {//默认图片最后一屏时
                    $('.swaplist1').animate({ left: '0px' }, 'slow');//交换图片滚动
                }
            } else {//交换图片显示时
                $('.mainlist1').css({ left: '1000px' })//默认图片放在显示区域右
                $('.swaplist1').animate({ left: sl - 1000 + 'px' }, 'slow');//交换图片滚动
                if (sl == (w - 1000) * -1) {//交换图片最后一屏时
                    $('.mainlist1').animate({ left: '0px' }, 'slow');//默认图片滚动
                }
            }
        }
    })
    $('.og_prev1').click(function () {

        if ($('.swaplist1,.mainlist1').is(':animated')) {
            $('.swaplist1,.mainlist1').stop(true, true);
        }

        if ($('.mainlist1 li').length > 4) {
            ml = parseInt($('.mainlist1').css('left'));
            sl = parseInt($('.swaplist1').css('left'));
            if (ml <= 0 && ml > w * -1) {
                $('.swaplist1').css({ left: w * -1 + 'px' });
                $('.mainlist1').animate({ left: ml + 1000 + 'px' }, 'slow');
                if (ml == 0) {
                    $('.swaplist1').animate({ left: (w - 1000) * -1 + 'px' }, 'slow');
                }
            } else {
                $('.mainlist1').css({ left: (w - 1000) * -1 + 'px' });
                $('.swaplist1').animate({ left: sl + 1000 + 'px' }, 'slow');
                if (sl == 0) {
                    $('.mainlist1').animate({ left: '0px' }, 'slow');
                }
            }
        }
    })




});

$(document).ready(function () {
    $('.og_prev,.og_next,.og_prev1,.og_next1').hover(function () {
        $(this).fadeTo('fast', 1);
    }, function () {
        $(this).fadeTo('fast', 0.7);
    })

})

