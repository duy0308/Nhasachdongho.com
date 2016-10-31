/*
    Auto Grid Plugin
    @author Nguyễn Đức Việt 09/01/2016
	@version 1.0.0
    usage:
     $(document).ready(function() {

        $('#blog-landing').autoGrid({
            no_columns: 4
        });
    });
*/
;(function ($, window, document, undefined) {
    var pluginName = 'autoGrid',
        defaults = {
            padding_x: 0,
            padding_y: 10,
            no_columns: 4,
            margin_bottom: 0
        },
        columns,
        $article,
        article_width;

    function Plugin(element, options) {
        this.element = element;
        this.options = $.extend({}, defaults, options) ;
        this._defaults = defaults;
        this._name = pluginName;
        this.init();
    }

    Plugin.prototype.init = function () {
        var self = this,
            resize_finish, resize_finish2;

        $(window).resize(function(){
				clearTimeout(resize_finish);
				resize_finish = setTimeout(function(){
					self.make_layout_change(self);
				}, 10);
				
				clearTimeout(resize_finish2);
				resize_finish2 = setTimeout(function(){
					self.make_layout_change(self);
				}, 1000);
        });
		
        self.make_layout_change(self);
		
		$(window).bind('load', function(){
			self.make_layout_change(self);
		});
    };

    Plugin.prototype.calculate = function (res_col) {
        var self = this,
            tallest = 0,
            row = 0,
            $container = $(this.element),
            container_width = $container.width();
            $article = $(this.element).children();
		
		article_width = $container.width() - self.options.padding_x;
        if(res_col > 0) {
            article_width = ($container.width() - self.options.padding_x * res_col) / res_col;
        }
		$container.css('position','relative');
       
        columns = res_col;
		
		var index = 0;
		
        $article.each(function(real_index){
			
            var current_column = 0,
                left_out = 0,
                top = 0,
                $this = $(this),
                prevAll = $this.prevAll(),
                tallest = 0;
			if($this.is(":visible")){
				if(columns > 0) {
					current_column = (index % columns);
				}

				for(var t = 0; t < columns; t++) {
					$this.removeClass('c'+t);
				}

				if(index % columns === 0) {
					row++;
				}

				$this.addClass('c' + current_column); 
				$this.addClass('r' + row);

				prevAll.each(function(index) {
					if($(this).hasClass('c' + current_column)) {
						top += $(this).outerHeight() + self.options.padding_y;
					}
				});

				if(columns > 0) {
					left_out = (index % columns) * (article_width + self.options.padding_x);
				}

				$this.css({
					'left': left_out,
					'top' : top,
					'width': article_width, 
					'transition':'all 0.4s', 
					'position':'absolute'
				});
				index++;
			}
        });

        this.tallest($container);
    };

    Plugin.prototype.tallest = function (_container) {
        var column_heights = [],
            largest = 0;

        for(var z = 0; z < columns; z++) {
            var temp_height = 0;
            _container.find('.c'+z).each(function() {
                temp_height += $(this).outerHeight();
            });
            column_heights[z] = temp_height;
        }

        largest = Math.max.apply(Math, column_heights);
        _container.css('height', largest + (this.options.padding_y + this.options.margin_bottom));
    };

    Plugin.prototype.make_layout_change = function (_self) {
		var col = _self.options.no_columns;
		var desktopsmall, tablet, tabletsmall;
		switch (col){
			case 1:
				desktopsmall = 1;
				tablet = 1;
				tabletsmall = 1;
				break;
			case 4:
				desktopsmall = 4;
				tablet = 3;
				tabletsmall = 2;
				break;
			case 3:
				desktopsmall = 2;
				tablet = 2;
				tabletsmall = 2;
				break;
			case 2:
				desktopsmall = 2;
				tablet = 1;
				tabletsmall = 1;
				break;
			default:
				desktopsmall = 4;
				tablet = 3;
				tabletsmall = 2;
		}
		
		var winW = $(window).width();
        if( winW < 480 ){
            col = 1;
        } else if( winW < 677 ) {
            col = tabletsmall;
        }else if( winW < 959 ){
			col = tablet;
		}else if( winW < 959 ){
			col = desktopsmall;
		}
		_self.calculate(col);
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, 'plugin_' + pluginName)) {
                $.data(this, 'plugin_' + pluginName,
                new Plugin(this, options));
            }
        });
    }

})(jQuery, window, document);