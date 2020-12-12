
$(document).ready(function () {

    tabbed();

    $(document).on("click", ".number-btns i", function () {

        if ($(this).hasClass("fa-angle-up")) {

            var x = $(".number").val();
            x++;
            $(".number").val(x);
            Calculate_amounts();
        }

        else if ($(this).hasClass("fa-angle-down") && $(".number").val() > 0) {
            var x = $(".number").val();
            x--;
            $(".number").val(x);
            Calculate_amounts();
        }

    });
    $(document).on("keyup", "#inputElem", function () {
        Calculate_amounts();
    });
    $(document).on("change", ".country-type", function () {
        Calculate_amounts();
    });
    $(document).on("change", ".weight-type", function () {
        Calculate_amounts();
    });
    $(document).on("change", ".maye-type", function () {
        Calculate_amounts();
    });

    function Calculate_amounts() {
        var sum = 0.00;

        var cntry = $('.country-wrap select').find('option:selected').val();
        var weight = 0;
        var liquid = $(".maye input").is(":checked").valueOf();
        var weight_type = $(".weight-type").find('option:selected').val();

        if (weight_type == "kg") {
            weight = $("#inputElem").val();
        }
        else {
            weight = $("#inputElem").val() / 1000;
        }

        if (cntry == "US") {
            if (weight > 0 && weight <= 0.25) {
                sum = 2.50;
            }
            if (weight > 0.25 && weight <= 0.5) {
                sum = 4.00;
            }
            if (weight > 0.50 && weight <= 0.75) {
                sum = 5.50;
            }
            if (weight > 0.75 && weight <= 1) {
                sum = 6.90;
            }
            if (weight > 1 && weight <= 5) {
                sum = weight * 6.50 + 0.00
            }
            if (weight > 5 && weight <= 10) {
                sum = weight * 6.00 + 0.00
            }
            if (weight > 5 && weight <= 10) {
                sum = weight * 6.00 + 0.00
            }
            if (weight > 10) {
                sum = weight * 5.50 + 0.00
            }
        }

        if (cntry == "CN") {
            if (weight > 0 && weight <= 0.25) {
                sum = 4.90;
            }
            if (weight > 0.25 && weight <= 0.5) {
                sum = 6.90;
            }
            if (weight > 0.50 && weight <= 0.75) {
                sum = 8.50;
            }
            if (weight > 0.75 && weight <= 1) {
                sum = 9.50;
            }
            if (weight > 1) {
                sum = weight * 9.50 + 0.00
            }
        }

        if (cntry == "TR") {
            if (liquid == false) {
                if (weight > 0 && weight <= 0.25) {
                    sum = 2.50;
                }
                if (weight > 0.25 && weight <= 0.5) {
                    sum = 3.50;
                }
                if (weight > 0.50 && weight <= 0.75) {
                    sum = 4.50;
                }
                if (weight > 0.75 && weight <= 1) {
                    sum = 5.50;
                }
                if (weight > 1 && weight < 2) {
                    sum = weight * 5.50 + 0.00
                }
                if (weight >= 2 && weight <= 5) {
                    sum = weight * 5.00 + 0.00
                }
                if (weight > 5 && weight <= 10) {
                    sum = weight * 5.50 + 0.00
                }
                if (weight > 10) {
                    sum = weight * 4.00 + 0.00
                }
            }

            if (liquid == true) {
                if (weight > 0 && weight <= 0.25) {
                    sum = 2.00;
                }
                if (weight > 0.25 && weight <= 0.5) {
                    sum = 4.00;
                }
                if (weight > 0.50 && weight <= 0.75) {
                    sum = 6.00;
                }
                if (weight > 0.75 && weight <= 1) {
                    sum = 8.00;
                }
                if (weight > 1) {
                    sum = weight * 8.00 + 0.00
                }
            }
        }

        $(".weight_total span").text("$" + sum.toFixed(2));
    }


    function tabbed() {
        var getpath = window.localStorage.getItem("path");
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs li[index='" + getpath + "']").addClass("active-li")
        $(".componentss>div>div").addClass("d-none")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".dashboard-tabs-content>div[index='" + getpath + "']").removeClass("d-none")

    }

    $(document).on("click", ".burger-menu", function () {
        $(".burger-menu").toggleClass("change")
        $(".menu-nav ul").toggleClass("d-block");
    });


    $(document).on("click", ".tabs li", function () {
        $(".tabs li").removeClass("active-li")
        $(this).addClass("active-li")
        $(".tabs-content>div").addClass("d-none")
        $(".tabs-content>div").eq($(this).index()).removeClass("d-none")

    })

    $(document).on("click", ".dashboard-tabs li", function () {
        $(".dashboard-tabs li").removeClass("active-li")
        $(this).addClass("active-li")
        $(".componentss>div>div").addClass("d-none")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".dashboard-tabs-content>div").eq($(this).index()).removeClass("d-none")
        path = $(".dropdown_menu li").eq($(this).index()).find("a").attr("href").split('/')[3];
        var postpath = window.localStorage.getItem("path");
        postpath = path;
        window.localStorage.setItem("path", postpath);
        tabbed();

    });


    $(document).on("click", ".dropdown_menu li", function () {
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs li").eq($(this).index()).addClass("active-li")
        $(".componentss>div>div").addClass("d-none")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".dashboard-tabs-content>div").eq($(this).index()).removeClass("d-none")
        path = $(this).find("a").attr("href").split('/')[3];
        var postpath = window.localStorage.getItem("path");
        postpath = path;
        window.localStorage.setItem("path", postpath);
        tabbed();
    });


    var form;
    function AddOnClick() {
        $(".dashboard-tabs li").removeClass("active-li")
        $(".dashboard-tabs-content>div").addClass("d-none")
        $(".new-order").addClass("d-none")
        $(".new-declaration").addClass("d-none")
        $(".order-country").removeClass("d-none")
        $("html, body").animate({ scrollTop: 600 }, 600);
    }

    $(document).on("click", ".add-order", function () {
        AddOnClick()
        $(".china").hide();
        form = "order";
    });

    $(document).on("click", ".add-declaration", function () {
        AddOnClick()
        $(".china").show();
        form = "declaration";
    });

    $(document).on("click", ".fa-plus", function () {
        AddOnClick()
        $(".china").hide();
        form = "order";
    });

    $(document).on("click", ".fa-newspaper", function () {
        AddOnClick()
        $(".china").show();
        form = "declaration";
    });




    $(document).on("click", ".dashboard-tabs li[index='orders']", function () {
        orderStatusId = 0;
        GetOrders();
    });
    $(document).on("click", ".dashboard-tabs li[index='declarations']", function () {
        declarationStatusId = 0;
        GetDeclarations();
    });

    var orderStatusId = 0;
    var declarationStatusId = 0;

    GetOrders();
    GetDeclarations();

    $(document).on("click", ".orders li", function () {
        orderStatusId = $(this).find("a").attr("href").split('/')[2];
        $(".orders li").removeClass("active-li");
        $(this).addClass("active-li");
        GetOrders();
    });


    $(document).on("click", ".declarations li", function () {
        declarationStatusId = $(this).find("a").attr("href").split('/')[2];
        $(".declarations li").removeClass("active-li");
        $(this).addClass("active-li");
        GetDeclarations();
    });


    function GetOrders() {
        $.ajax({
            url: "GetAllOrdersWithStatusId",
            type: "Post",
            dataType: "html",
            data: { id: orderStatusId },
            success: function (data) {
                $('.orderList').empty().append(data);
            }
        })
    }

    function GetDeclarations() {
        $.ajax({
            url: "GetAllDeclarationsWithStatusId",
            type: "Post",
            dataType: "html",
            data: { id: declarationStatusId },
            success: function (data) {
                $('.declarationList').empty().append(data);
            }
        })
    }



    var CountryId;
    var currency;
    $(document).on("click", ".country", function () {

        var CountryName = $(this).find("a").attr("href").split('/')[1];
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

            var postpath = window.localStorage.getItem("path");
            postpath = "orders";
            window.localStorage.setItem("path", postpath);
        }
        if (form == "declaration") {
            $(".currency").text(currency)
            $(".new-declaration").removeClass("d-none")

            $("input[ name=CountryId]").val(CountryId)


            var postpath = window.localStorage.getItem("path");
            postpath = "declarations";
            window.localStorage.setItem("path", postpath);
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


    $(document).on("click", ".copy-btn", function () {
        $(this).animate({
            fontSize: "28px"
        }, 100);
        $(this).animate({
            fontSize: "22px"
        }, 100);
        $(this).css("color", "#005fb5");
        var value1 = $(this).closest('.address-item').find("p").text(); //Upto this I am getting value
        var $temp = $("<input>");
        $("body").append($temp);
        $temp.val(value1).select();
        document.execCommand("copy");
        $temp.remove();
    })


});



