
$(document).ready(function () {

    $(document).on("click", ".orderdetailsId", function () {
        var id = $(this).data("id");
        $.ajax({
            url: "OrderDetails",
            type: "POST",
            dataType: "html",
            data: { id: id },
            success: function (data) {
                $('.modalDiv').empty();
                $('.modalDiv').html(data);
                $("#orderDetails").show();

            }
        })
    });

    $(document).on("click", ".modalNone", function () {
        // $("#orderDetails").attr('style', 'display:none !important');
        $("#orderDetails").hide();
    });

    $(document).on("click", ".close", function () {
        $("#orderDetails").hide();
    });


    $(document).on("click", ".declarationdetailsId", function () {
        var id = $(this).data("id");
        $.ajax({
            url: "DeclarationDetails",
            type: "POST",
            dataType: "html",
            data: { id: id },
            success: function (data) {
                $('.modalDiv').empty();
                $('.modalDiv').html(data);
                $("#declarationDetails").show();

            }
        })
    });

    $(document).on("click", ".modalNone", function () {
        // $("#orderDetails").attr('style', 'display:none !important');
        $("#declarationDetails").hide();
    });

    $(document).on("click", ".close", function () {
        $("#declarationDetails").hide();
    });

    $(document).on("click",".copy-btn", function () {
        value = $(this).data('clipboard-text'); //Upto this I am getting value
        var $temp = $("<input>");
        $("body").append($temp);
        $temp.val(value).select();
        document.execCommand("copy");
        $temp.remove();
    })
   

    $(document).on("click", ".arrow-close", function () {
        $(this).addClass("arrow-open").removeClass("arrow-close");
        $('.arrow').addClass('fa-angle-right').removeClass('fa-angle-left');
        $(".menu-nav p").hide();
        $(".menu-nav").css("width", "100px");
        $(".menu-nav img").css({ "margin-top": "50px","width": "80px"});
        $("section").css("padding-left", "100px");
        $(".homesection>div").css("width", "calc( 100% - 100px)");
    });

    $(document).on("click", ".arrow-open", function () {
        $(this).addClass("arrow-close").removeClass("arrow-open");
        $('.arrow').addClass('fa-angle-left').removeClass('fa-angle-right');
        $(".menu-nav p").show();
        $(".menu-nav").css("width", "220px");
        $(".menu-nav img").css({ "margin-top": "0", "width": "100px" });
        $("section").css("padding-left", "220px");
        $(".homesection>div").css("width", "calc( 100% - 220px)");
    });

});
