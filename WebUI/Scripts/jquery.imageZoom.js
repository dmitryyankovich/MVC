(function($) {
    'use strict';
    $.fn.imageZoom = function(options) {
        var settings = $.extend({}, $.fn.defaults, options);
        var lensStyle = 'background-position: 0px 0px;width: ' + settings.lensSize
            + 'px;height: ' + settings.lensSize + 'px;float: left;display: none;cursor: none;border-radius: '
            + (settings.lensSize / 2 + settings.borderSize) + 'px;float: left;display: none;border: '
            + settings.borderSize + 'px solid ' + settings.borderColor
            + ';background-repeat: no-repeat;position: absolute;';

        var obj, offset, lens, objectWidth, objectHeight, backgroundWidth, backgroundHeight;

        return this.each(function() {
            obj = $(this);
            offset = $(this).offset();
            objectWidth = obj.width();
            objectHeight = obj.height();
            lens = $('<div style="' + lensStyle + '"></div>').appendTo($('body'));
            backgroundWidth = objectWidth * settings.imgScale;
            backgroundHeight = objectHeight * settings.imgScale;
            lens.css({ backgroundImage: 'url("' + obj.attr('src') + '")',
                "background-size": backgroundWidth + 'px' + ' ' + backgroundHeight + 'px'});
            lens.mousemove(changePosition);
            $(this).mousemove(changePosition);
            lens.mouseout(outOfImage);
            $(this).mouseout(outOfImage);
        });

        function changePosition(e) {
            var leftPosition = e.pageX - offset.left;
            var topPosition = e.pageY - offset.top;

            if (!(leftPosition < 0 || topPosition < 0 || leftPosition > obj.width() || topPosition > obj.height())) {
                lens.show();
                leftPosition = (leftPosition * settings.imgScale - lens.width() / 2) * (-1);
                topPosition = (topPosition * settings.imgScale - lens.height() / 2) * (-1);
                lens.css({ backgroundPosition: leftPosition + 'px ' + topPosition + 'px' });
                leftPosition = e.pageX - lens.width() / 2;
                topPosition = e.pageY - lens.height() / 2;
                lens.css({ left: leftPosition + 'px', top: topPosition + 'px' });
            }
        }

        function outOfImage(e){
            lens.hide();
        }
    };

    $.fn.defaults = {
        lensSize: 100,
        borderSize: 4,
        lensClass : 'lens',
        borderColor: '#888',
        imgScale: 2
    }

})(jQuery);
