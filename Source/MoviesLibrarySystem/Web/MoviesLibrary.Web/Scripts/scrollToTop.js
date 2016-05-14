(function () {
    "use strict";
    $(window).ready(function () {
        $("#btn-scroll").on("click", function (n) {
            $("html, body").animate({ scrollTop: 0 }, "slow");
            return false;
        })
    })
}());