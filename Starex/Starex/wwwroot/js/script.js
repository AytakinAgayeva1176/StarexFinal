
$(document).ready(function () {

    $(document).on("click", ".number-btns i", function () {

        if ($(this).hasClass("fa-angle-up")) {

            var x = $(".number").val();
            x++;
            $(".number").val(x);
        }

        else if ($(this).hasClass("fa-angle-down") && $(".number").val()>0) {
            var x = $(".number").val();
            x--;
            $(".number").val(x);
        }

    });

    //$(document).on("keydown", "#inputElem", function () {

    //    if ($(".weight-type").val()==="kg") {

    //        $(".up-btn")
    //    }

    //    else if ($(".weight-type").val() === "gr") {

    //    }

    //});



    $(document).on("click", ".tabs li", function () {
        $(".tabs li").removeClass("active-li")
        $(this).addClass("active-li")
        $(".tabs-content>div").addClass("d-none")
        $(".tabs-content>div").eq($(this).index()).removeClass("d-none")

    })

    $(document).on("click", ".dashboard-tabs li", function () {
        $(".dashboard-tabs li").removeClass("active-li")
        $(this).addClass("active-li")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".componentss>div>div").addClass("d-none")
        $(".dashboard-tabs-content>div").eq($(this).index()).removeClass("d-none")

    });


    $(document).on("click", ".dropdown_menu li", function () {
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs li").eq($(this).index()).addClass("active-li")
        $(".componentss>div>div").addClass("d-none")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".dashboard-tabs-content>div").eq($(this).index()).removeClass("d-none")

    });

    $(document).on("click", ".burger-menu", function () {
        $(".burger-menu").toggleClass("change")
        $(".menu-nav ul").toggleClass("d-block");
    });

    //console.log($("header").outerHeight(true) + $(".dashboard-content>div:nth-child(1)").outerHeight(true) + $(".dashboard-content>div:nth-child(2)").outerHeight(true) + 50);

    var form;
    $(document).on("click", ".add-order", function () {
        $("html, body").animate({ scrollTop: 600 }, 600);
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".new-order").addClass("d-none")
        $(".china").hide();
        $(".new-declaration").addClass("d-none")
        $(".order-country").removeClass("d-none")
        form = "order";
    });

    $(document).on("click", ".add-declaration", function () {
        $("html, body").animate({ scrollTop: 600 }, 600);
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".new-order").addClass("d-none")
        $(".china").show();
        $(".new-declaration").addClass("d-none")
        $(".order-country").removeClass("d-none")
        form = "declaration";
    });


    var CountryId;
    var currency;
    $(document).on("click", ".country", function () {

        var CountryName = $(this).find("a").attr("href").split('/')[1];
        console.log(CountryName);
        if (CountryName === "us") {
            CountryId = 1
            currency = "USD"
        }
       else if (CountryName === "tr") {
            CountryId = 2
            currency = "TL"
        }

        else {
            CountryId = 3
            currency = "USD"
        }


        $.ajax({
            url: "/Home/GetAllProductWithId",
            data: { id: CountryId },
            type: "POST"
        }).done(function (response) {
            $("#ProductType").select2({
                closeOnSelect: true,
                allowClear: true,
                placeholder: "Seçin",
                data: response.items
            });
        }).fail(function (response) {
            console.log("fail");
        });
  
        $("html, body").animate({ scrollTop: 600 }, 600);
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".order-country").addClass("d-none")
        if (form == "order") {
            $(".new-order").removeClass("d-none")
        }
        if (form == "declaration") {
            $(".currency").text(currency)
            $(".new-declaration").removeClass("d-none")

            $("input[ name=CountryId]").val(CountryId)
        }
    })

    $(document).on("keyup", ".form-wrap input", function () {
        $("input[ name=CountryId]").val(CountryId)
        var totalPrice = parseInt($("input[name=Product_Price]").val()) +
            parseInt($("input[name=Cargo_Price]").val()) +
            parseInt($("input[name=Product_Price]").val()) * 0.025 +
            parseInt($("input[name=Cargo_Price]").val()) * 0.025;
        $("input[name=priceResult]").val(totalPrice);
        $("input[name=PriceResult]").val(totalPrice);
    });

    $(document).on("change", ".currency-select", function () {
        $(".amount-input").removeAttr('disabled');
        if ($(this).val() == 2) {
            $("input[name=amount]").attr("placeholder", "Məbləğ - TL");
        }
        if ($(this).val() == 1) {
            $("input[name=amount]").attr("placeholder", "Məbləğ - USD");
        }

    });

    $(document).on("keyup", ".input-group > input", function () {
        if ($(this).val() != "") {
            $(".balance-btn").removeAttr("disabled");
        }

    });

    // if($(this).val() != "" && $("textarea").val() != "" && $("input[name='category']").is(":checked") == true){
   // $("input[type='submit']").removeAttr("disabled");
// } e


    //$(document).on("change", ".input-group > input ", function () {
    //    var empty = false;
    //    $('form > input').each(function () {
    //        if ($(this).val() == '') {
    //            empty = true;
    //        }
    //    });

    //    if (empty) {
    //        $('#register').attr('disabled', 'disabled');
    //      } else {
    //        $('#register').removeAttr('disabled'); 
    //    }

    //});

});