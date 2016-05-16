(function () {
    "use strict";
    $(window).ready(function () {
        var $btnScroll = $("#btn-scroll");
        $btnScroll.hide();

        $(window).scroll(function () {
            var height = $(window).scrollTop();

            if (height > 100) {
                $btnScroll.fadeIn(300);
            } else {
                $btnScroll.fadeOut(300);
            }
        });

        $btnScroll.on("click", function (n) {
            $("html, body").animate({ scrollTop: 0 }, "slow");
            return false;
        })
    })
}());