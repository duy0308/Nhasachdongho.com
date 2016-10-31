(function($){
	
	"use strict";
	// Nguyen Duc Viet
	
	//topbar dropdown
	$('.top-menu .current, .nav-top > li > a, .top-search .current').click(function(){
		if($(this).parent().hasClass('openning')){
			$(this).parent().removeClass('openning');
		}else{
			$(this).closest('.top-bar').find('.openning').removeClass('openning'); 
			$(this).parent().addClass('openning');
		}
		
	});
	$(document).click(function(e){
		if(!$(e.target).closest('.top-bar').length){
			$('.top-bar').find('.openning').removeClass('openning');
		}
	});
	
	//cart dropdown
	$(document).on('click', '.cart-toggler', function(){
		$(this).next('.topcart_content').stop().slideToggle(300);
	});
	
	$('body').append('<div id="loading"></div>');
	$( document ).ajaxComplete(function( event, request, options ){
		if(options.url.indexOf('wc-ajax=add_to_cart') != -1 && options.type != 'GET'){
			$('html, body').animate({scrollTop: 0}, 1000, function(){
				$('.topcart .topcart_content').stop().slideDown(500);
			});
		}
		$( "#loading" ).fadeOut(400);
	});
	$( document ).ajaxSend(function(event, xhr, options){
		if(options.url.indexOf('wc-ajax=get_refreshed_fragments') == -1 && options.type != 'GET'){
			$( "#loading" ).show();
		}
	});
	
	//Category view mode
	$(document).on('click', '.view-mode > a', function(){
		$(this).addClass('active').siblings('.active').removeClass('active');
		if($(this).hasClass('grid')){
			$('#archive-product .shop-products').removeClass('list-view');
			$('#archive-product .shop-products').addClass('grid-view');
			$('#archive-product .list-col4').removeClass('col-xs-12 col-sm-4');
			$('#archive-product .list-col8').removeClass('col-xs-12 col-sm-8');
		}else{
			$('#archive-product .shop-products').addClass('list-view');
			$('#archive-product .shop-products').removeClass('grid-view');
			$('#archive-product .list-col4').addClass('col-xs-12 col-sm-4');
			$('#archive-product .list-col8').addClass('col-xs-12 col-sm-8');
		}
	});
	$("#close_social").click(function (e) {
        $(this).parent().toggleClass("closed"); 
		e.stopPropagation();
		return false;
    });
	
	$('li[data-vc-tab]').click(function(){
		setTimeout(function(){
			$(window).resize();
		}, 100);
	});
	
	//toggle categories event
	$(document).on('click', '#secondary .product-categories .cat-parent .opener', function(){
		if($(this).parent().hasClass('opening')){
			$(this).parent().removeClass('opening').children('ul').stop().slideUp(300);
		}else{
			$(this).parent().siblings('.opening').removeClass('opening').children('ul').stop().slideUp(300);
			$(this).parent().addClass('opening').children('ul').stop().slideDown(300);
		}
	});
	
	$('.quantity input.qty').keypress(function(e){
		if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
			return false;
		}
	});
	
})(jQuery); //end of jquery events


jQuery(document).ready(function($){
	
	//select html helper
	$('select.iz-sl').each(function(){
		var my_val = $(this).children(':selected').text();
		if(!$(this).parent().hasClass('iz-sl-wrap')){
			$(this).wrap('<div class="iz-sl-wrap"></div>');
		}
		if(!$(this).parent().children('.iz-vt-slvl').length){
			$(this).parent().append('<span class="iz-vt-slvl">'+ my_val +'</span>');
		}else{
			$(this).parent().children('.iz-vt-slvl').text(my_val);
		}
	});
	$(document).on('change', 'select.iz-sl', function(){
		var my_val = $(this).children(':selected').text();
		$(this).parent().children('.iz-vt-slvl').text(my_val);
	});
	
	//init for owl carousel
    var owl = $('[data-owl="slide"]');
	owl.each(function(index, el) {
		var $item = $(this).data('item-slide');
		var $rtl = $(this).data('ow-rtl');
		var $loop = ($(this).data('loop') == true) ? true : false;
		var $dots = ($(this).data('dots') == true) ? true : false;
		var $nav = ($(this).data('nav') == false) ? false : true;
		var $margin = ($(this).data('margin')) ? $(this).data('margin') : 0;
		var $delay = ($(this).data('delay')) ? $(this).data('delay') : 1000;
		var $duration = ($(this).data('duration')) ? $(this).data('duration') : 450;
		var $autoplay = ($(this).data('autoplay')) ? $(this).data('autoplay') : false;
		var $desksmall_items = ($(this).data('desksmall')) ? $(this).data('desksmall') : (($item) ? $item : 4);
		var $tablet_items = ($(this).data('tablet')) ? $(this).data('tablet') : (($item) ? $item : 2);
		var $tabletsmall_items = ($(this).data('tabletsmall')) ? $(this).data('tabletsmall') : (($item) ? $item : 2);
		var $mobile_items = ($(this).data('mobile')) ? $(this).data('mobile') : (($item) ? $item : 1);
		var $tablet_margin = Math.floor($margin / 1.5);
		var $mobile_margin = Math.floor($margin / 3);
		var $default_items = ($item) ? $item : 5;
		$(this).owlCarousel({
			loop : $loop,
			nav : $nav,
			dots: $dots,
			margin: $margin,
			rtl: $rtl,
			items : $default_items,
			autoplay: $autoplay, 
			autoplayTimeout: $delay,
			smartSpeed: $duration,
			responsive:{
				0:{
			      items: $mobile_items, // In this configuration 1 is enabled from 0px up to 479px screen size 
				  margin: $mobile_margin
			    },

			    480:{
			      items: $tabletsmall_items, // from 480 to 677 default 1
				  margin: $tablet_margin
			    },

			    640:{
			      items: $tablet_items, // from this breakpoint 678 to 959 default 2
				  margin: $tablet_margin
			    },

			    991:{
			      items: $desksmall_items, // from this breakpoint 960 to 1199 default 3
				  margin: $margin

			    },
			    1199:{
			      items:$default_items,
			    }
			}
		});
	});
	
	//add icon for search button
	$('.widget_search .search-form button[type="submit"],.widget_search .search-form input[type="submit"]').append('<i class="fa fa-search"></i>');
	
	//Add quick view box
	$('body').append('<div class="quickview-wrapper"><div class="overlay-bg" style="position: absolute; width: 100%; height: 100%; top: 0; left: 0; z-index: 10; cursor: pointer;" onclick="hideQuickView()"></div><div class="quick-modal"><span class="qvloading"></span><span class="closeqv"><i class="fa fa-times"></i></span><div id="quickview-content"></div><div class="clearfix"></div></div></div>');
		
	//show quick view
	$(document).on('click', '.quickviewbtn a.quickview', function(event){
		event.preventDefault();
		showQuickView($(this).attr('data-quick-id'));
	});
	$(document).on('click', '.closeqv', function(){
		hideQuickView();
	});
	
	// init Animate Scroll
	if( $('body').hasClass('bigshop-animate-scroll') && !Modernizr.touch ){
		var wow = new WOW(
			{
				mobile : false,
			}
		);
		wow.init();
	}
	
	//Go to top
	$(document).on('click', '#back-top', function(){
		$("html, body").animate({ scrollTop: 0 }, "slow");
	});
	
	// Scroll
	var currentP = 0;
	
	$(window).scroll(function(){
		var headerH = $('.header-container').height();
		var scrollP = $(window).scrollTop();
		
		if($(window).width() > 1024){
			if(scrollP != currentP){
				//Back to top
				if(scrollP >= headerH){
					$('#back-top').addClass('show');
				} else {
					$('#back-top').removeClass('show');
				}
				
				currentP = $(window).scrollTop();
			}
		}
	});
	
	//tooltip
	$('a.add_to_wishlist, a.compare.button, .yith-wcwl-wishlistexistsbrowse a[rel="nofollow"], .yith-wcwl-share a, .social-icons a').each(function(){
		var text = $.trim($(this).text());
		var title = $.trim($(this).attr('title'));
		$(this).attr('data-toggle', 'tooltip');
		if(!title){
			$(this).attr('title', text);
		}
	});
	
	$('[data-toggle="tooltip"]').tooltip({container: 'body'});
	
	//mobile menu display
	$(document).on('click', '.nav-mobile .toggle-menu, .mobile-menu-overlay', function(){
		$('body').toggleClass('mobile-nav-on');
	});
	$('.mobile-menu li.dropdown, .mobile-menu li.menu-item-has-children').append('<span class="toggle-submenu"><i class="fa fa-angle-right"></i></span>');
	$(document).on('click', '.mobile-menu li.dropdown .toggle-submenu, .mobile-menu li.menu-item-has-children .toggle-submenu', function(){
		if($(this).parent().siblings('.opening').length){
			var old_open = $(this).parent().siblings('.opening');
			old_open.children('ul').stop().slideUp(200);
			old_open.children('.toggle-submenu').children('.fa').removeClass('fa-angle-down').addClass('fa-angle-right');
			old_open.removeClass('opening');
		}
		if($(this).parent().hasClass('opening')){
			$(this).parent().removeClass('opening').children('ul').stop().slideUp(200);
			$(this).parent().children('.toggle-submenu').children('.fa').removeClass('fa-angle-down').addClass('fa-angle-right');
		}else{
			$(this).parent().addClass('opening').children('ul').stop().slideDown(200);
			$(this).parent().children('.toggle-submenu').children('.fa').removeClass('fa-angle-right').addClass('fa-angle-down');
		}
	});
	
	//gird layout auto arrange
	$('.auto-grid').each(function(){
		var $col = ($(this).data('col')) ? $(this).data('col') : 4;
		$(this).autoGrid({
			no_columns: $col
		});
	});
	
	$('.menu-categories .title_menu').click(function(){
		$(this).next('.menucontent').stop().slideToggle(400);
	});
	
	//product countdown
	window.setInterval(function(){
		$('.product-image .countdown').each(function(){
			var me = $(this);
			var hours = parseInt(me.find('.hours_left').html());
			var mins = parseInt(me.find('.min_left').html());
			var secs = parseInt(me.find('.secs_left').html());
			if(hours >= 0 && mins >= 0 && secs >= 0){
				if(secs == 0){
					secs = 59;
					if(mins == 0){
						mins = 59;
						if(hours > 0){
							hours = hours - 1;
						}
					}else{
						mins = mins - 1;
					}
				}else{
					secs = secs - 1;
				}
				me.find('.hours_left').html(hours);
				me.find('.min_left').html(mins);
				me.find('.secs_left').html(secs);
			}
		});
	}, 1000);
	
	// customize review popup
	$(document).on('click', '#review_form_wrapper .overlay_bg, #review_form .close', function(){
		$(this).closest('#review_form_wrapper').fadeOut(300);
	});
	$(document).on('click', '.show-review-form', function(){
		if($(this).closest('#quickview-content').length){
			$(this).closest('#quickview-content').find('.tabs .reviews_tab a').trigger('click');
			$(this).closest('#quickview-content').find('#review_form_wrapper').fadeIn(300);
		}else{
			$('.tabs .reviews_tab a').trigger('click');
			$('#review_form_wrapper').fadeIn(300);
		}
	});
	
	//custom next / prev of carouFredsel
	$('#slider-prev').append('<i class="fa fa-angle-left"></i>');
	$('#slider-next').append('<i class="fa fa-angle-right"></i>');
	
	//quantity controls
	$(document).on('click', '.quantity span', function(){
		var max = ($(this).siblings('input').attr('max')) ? parseInt($(this).siblings('input').attr('max')) : 999999999;
		var min = ($(this).siblings('input').attr('min')) ? parseInt($(this).siblings('input').attr('min')) : 0;
		var next_val = parseInt($(this).siblings('input').val());
		var current_val = next_val;
		if($(this).hasClass('decrease') && current_val > min){
			next_val = current_val - 1;
		}
		if($(this).hasClass('increase') && current_val < max){
			next_val = current_val + 1;
		}
		$(this).siblings('input').val(next_val).change();
	});
	
	//blog tabs modify
	$('.blog-tabs-wrap .blog-tab-content').each(function(index){
		var tab = '';
		if($(this).children('.blog-widget-title').length){
			tab = $(this).children('.blog-widget-title').text();
		}
		var html = '<li class="tab'+ ((index == 0) ? ' active':'') +'"><a href="javascript:void(0)">' + tab + '</a></li>';
		$('.blog-tabs-wrap ul.tabs').append(html);
	});
	$('.blog-tabs-wrap .blog-tabs-content').children().first().addClass('active');
	$(document).on('click', '.blog-tabs-wrap ul.tabs a', function(){
		var me = $(this).parent().index();
		$(this).parent().addClass('active').siblings().removeClass('active');
		$('.blog-tabs-wrap .blog-tabs-content').children().eq(me).addClass('active').siblings().removeClass('active');
	});
	
	//categories menu mobile
	$('.menu-categories .mega_main_menu_ul > li.menu-item-has-children').append('<span class="toggler"></span>');
	$(document).on('click', '.toggler', function(){
		if($(this).closest("li").hasClass('opening')){
			$(this).closest("li").removeClass('opening');
			$(this).closest("li").children('ul').stop().slideUp(300);
		}else{
			$(this).closest("li").siblings('.opening').removeClass('opening').children('ul').stop().slideUp(300);
			$(this).closest("li").addClass('opening').children('ul').stop().slideDown(300);
		}
	});
	
	// toggle product categories
	$('#secondary .product-categories .cat-parent').append('<span class="opener"></span>');
	
	//hide tag title if content empty
	$('.widget_product_tag_cloud .tagcloud').each(function(){
		if(!$(this).html()) $(this).closest('.widget_product_tag_cloud').remove();
	});
	
});//end of document ready

"use strict";
//Nguyen Duc Viet
function showQuickView(productID){
	jQuery('#quickview-content').html('');

	jQuery('body').addClass('quickview');
	window.setTimeout(function(){
		jQuery('.quickview-wrapper').addClass('open');
		
		jQuery.post(
			ajaxurl, 
			{
				'action': 'bigshop_product_quickview',
				'data':   productID
			}, 
			function(response){
				response = response.replace('[yith_compare_button]', '');
				jQuery('#quickview-content').html(response);
				
				/*thumbnails carousel*/
				jQuery('#quickview-content .quick-thumbnails').owlCarousel({
					items: 2,
					nav : true,
					dots: false,
					margin: 10
				});
				
				/* variable product form */
				if(jQuery('#quickview-content .variations_form').length){
					jQuery( '#quickview-content .variations_form' ).wc_variation_form();
					jQuery( '#quickview-content .variations_form .variations select' ).change();
				}
				
				/* tabs reset */
				jQuery('#quickview-content .woocommerce-tabs .tabs > li').each(function(index){
					if(index == 0){
						jQuery(this).addClass('active');
					}
					jQuery(this).children('a').attr('href', 'javascript:void(0)');
				});
				jQuery('#quickview-content .woocommerce-tabs .panel').first().addClass('active');
				jQuery(document).on('click', '#quickview-content .woocommerce-tabs .tabs > li > a', function(){
					var eq = jQuery(this).parent().index();
					jQuery(this).parent('li').addClass('active').siblings().removeClass('active');
					jQuery(this).closest('.woocommerce-tabs').find('.panel').removeClass('active').eq(eq).addClass('active');
				});
				
				/*thumbnail click*/
				jQuery('#quickview-content .quick-thumbnails a').each(function(){
					var quickThumb = jQuery(this);
					var quickImgSrc = quickThumb.attr('href');
					
					quickThumb.on('click', function(event){
						event.preventDefault();
						jQuery('.main-image').find('img').attr('src', quickImgSrc);
					});
				});
			}
		);
	}, 300);
}
function hideQuickView(){
	jQuery('.quickview-wrapper').removeClass('open');
			
	window.setTimeout(function(){
		jQuery('body').removeClass('quickview');
	}, 500);
}
//for responsive
function setSliderHeight(){
	var winW = jQuery(window).width();
	var padd = 80;
	if(winW > 768){
		padd = 80;
	}else if(winW > 480){
		padd = 40;
	}else{
		padd = 20;
	}
	jQuery('.owlslideshow .slide-item').each(function(){
		var $_me = jQuery(this);
		var img_height = jQuery(this).children('img').height();
		$_me.closest('.owl-item').height(img_height);
		var par_height = img_height - padd;
		$_me.find('.col-xs-12, .col-xs-6').height(par_height);
		$_me.children('.slide-content').find('.row').css('height', 'auto');
		$_me.children('.slide-content').find('img').css('max-height', (par_height - 10) + 'px');
	});
	if(jQuery('.owlslideshow').closest('.col-sm-9').length){
		jQuery('.owlslideshow').each(function(){
			var $_this = jQuery(this);
			$_this.closest('.col-sm-9').siblings().find('.wpb_text_column a').height($_this.height() / 2 - 10);
		});
	}
	if(jQuery('.category_group_left').length){
		 jQuery.each( jQuery('.category_group_left'), function( key, value ) {
			var _subh = jQuery(this).next('.category_group_right').height();
			jQuery(this).height(_subh);
			jQuery(this).next('.category_group_right').height(_subh);
		 });
	}
}
function itemEqualHeight(){
	jQuery('.products.grid-view').each(function(){
		var eqH = 0;
		jQuery(this).find('.product-wrapper .gridview .product-name').each(function(){
			if(jQuery(this).height() > eqH){
				eqH = jQuery(this).height();
			}
		});
		jQuery(this).find('.product-wrapper .gridview .product-name').height(eqH);
	});
}
jQuery(window).load(function () { 
	//itemEqualHeight();
	setSliderHeight();
});
jQuery(window).bind('load', function(){
	//itemEqualHeight();
});
jQuery(window).resize(function(){
	//itemEqualHeight();
	setSliderHeight();
});
 


