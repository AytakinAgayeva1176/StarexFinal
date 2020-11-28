$(document).ready(function () {
    $('.select2DropDown').select2({
        
        placeholder: "Seçin",
        language: {
            inputTooShort: function () {
                return "Bir hərf daxil edin";
            },
            noResults: function () {
                return "Nəticə tapılmadı";
            },
            searching: function () {
                return "Axtarılır";
            }
        },
        allowClear: true,
        width: "resolve" // to adjust proper width of select2 wrapped elements);

    
    });
});