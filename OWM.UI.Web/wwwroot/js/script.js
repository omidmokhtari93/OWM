﻿$(function() {
    $('[counter]').each(function() {
        $(this).prop('Counter', 0).animate({
                Counter: $(this).text().replace(',', '')
            },
            {
                duration: 1000,
                easing: 'swing',
                step: function(now) {
                    $(this).text(Math.ceil(now));
                    $(this).Digit();
                }
            });
    });
});

$.fn.Digit = function () {
    return this.each(function () {
        $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
    });
}

function Checkinputs(n) {
    var t = !1,
        a = $("#" + n).find("input[required]");
    return 0 === a.length && (a = $("#" + n).find("textarea[required]")), a.each(function (n, a) {
        "" == a.value && (RedAlert(a, ""), t = !0)
    }), t
}

function RedAlert(t, e) {
    var n;
    n = "string" == typeof t ? $("#" + t) : t, $(n).addClass("is-invalid", 500), setTimeout(function() {
        $(n).removeClass("is-invalid")
    }, 4e3), $.notify(e, {
        globalPosition: "top left"
    })
}

function ElementRedalert(ele, pos, txt) {
    var element;
    if (typeof ele == "string") { element = $("#" + ele); } else { element = ele; }
    $(element).notify(txt, { position: pos, className: "error" });
}

function ElementGreenalert(ele, pos, txt) {
    var element;
    if (typeof ele == "string") { element = $("#" + ele); } else { element = ele; }
    $(element).notify(txt, { position: pos, className: "success" });
}

function GreenAlert(t, e) {
    var n;
    n = "string" == typeof t ? $("#" + t) : t, $(n).addClass("is-valid", 500), setTimeout(function() {
        $(n).removeClass("is-valid")
    }, 4e3), $.notify(e, {
        className: "success",
        clickToHide: !1,
        autoHide: !0,
        position: "top left"
    })
}

function ClearFields(t) {
    $('#'+ t).children('input:text, textarea').each(function () {
        var baseColor = $(this).css('color');
        $(this).animate({ color: $(this).css('background-color') }, function () {
            $(this).val('');
            $(this).css('color', baseColor);
        });
    }); $("#" + t).find("select").prop("selectedIndex", 0)
}

function AjaxGet(t) {
    $.ajax({
        type: "Get",
        url: t.url,
        data: t.param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: t.func,
        error: t.err
    })
}

function AjaxPost(t) {
    $.ajax({
        type: "Post",
        url: t.url,
        data: t.param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: t.func,
        error: t.err
    })
}

$(function() {
    setTimeout(function () { $('#ValidationSummary ul li').fadeOut(700) }, 5000);    
    $('#ValidationSummary').on('click',
        'li',
        function () {
            $(this).fadeOut();
        });
})
