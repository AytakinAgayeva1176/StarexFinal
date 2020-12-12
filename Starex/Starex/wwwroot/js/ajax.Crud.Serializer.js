$(document).ready(function () {
    $("#submitOrderForm").submit(function (event) {
        event.preventDefault(event);
        const $form = $(this);
        const method = $form.attr("method");
        console.log($form.valid());

        $.validator.unobtrusive.parse($form);
        if ($form.valid()) {
            $.ajax({
                url: $form.attr("action"),
                data: $form.serialize(),
                type: method
            }).done(function (response) {

                //window.Swal.fire({
                //    text: response.message,
                //    icon: 'success',
                //    confirmButtonText: 'OK'
                //})
                console.log(response.href);
                if (response.href !== "") {
                    window.location.href = response.href;
                }

                console.log("Salam");
            }).fail(function (xhr) {
                //window.Swal.fire({
                //    icon: 'error',
                //    title: 'Oops...',
                //    text: xhr.responseJSON.message
                //});
            });
        } else {
            console.log("error");
        }
    });
})