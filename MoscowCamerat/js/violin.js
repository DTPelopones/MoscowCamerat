//$(document).ready(function () {
//    var activeHeight = 450,
//        navBrand = $('.navbar-brand'),
//        navItem = $('.navbar-nav a'),
//        padding = 9.5,
//        fontSize = 16;
        
//    function scroll_fn() {

//        document_height = $(document).height();
//        scroll_so_far = $(window).scrollTop();
//        window_height = $(window).height();

//        max_scroll = document_height - window_height;

//        scroll_percentage = scroll_so_far / (max_scroll / 100);

//        $('#header').css({ background: "-webkit-gradient(linear, left top, right top, color-stop(" + scroll_percentage + "%,#779aab), color-stop(" + scroll_percentage + "%,#aabcbe))" });
//        $('#header').css({ background: "-webkit-linear-gradient(left, #779aab " + scroll_percentage + "%,#aabcbe " + scroll_percentage + "%)" });
//        $('#header').css({ background: "-moz-linear-gradient(left, #779aab " + scroll_percentage + "%, #aabcbe " + scroll_percentage + "%)" });
//        $('#header').css({ background: "-o-linear-gradient(left, #779aab " + scroll_percentage + "%,#aabcbe " + scroll_percentage + "%)" });
//        $('#header').css({ background: "-ms-linear-gradient(left, #779aab " + scroll_percentage + "%,#aabcbe " + scroll_percentage + "%)" });
//        $('#header').css({ background: "linear-gradient(to right, #779aab " + scroll_percentage + "%,#aabcbe " + scroll_percentage + "%)" });
//    }

//    $(window).scroll(function () {
//        var screenWidth = $(window).width();
//        if (screenWidth > 991) {
//            var topHeight = activeHeight - $(document).scrollTop(),
//                scale = topHeight / activeHeight,
//                currPadding = padding,
//                currFontSize = fontSize;

//            if (scale > 0) {
//                currPadding = (padding + (scale * 10)) + 'px';
//                if (screenWidth > 991) {
//                    currFontSize = (fontSize + (scale * 2)) + 'px';
//                }
//            }
//            navItem.css({ 'padding-top': currPadding, 'padding-bottom': currPadding, 'font-size': currFontSize });
//            navBrand.css({ 'padding-top': currPadding, 'padding-bottom': currPadding });
//        }
//        scroll_fn();
//    });

//    $(window).resize(function () {
//        scroll_fn();
//    });
//});