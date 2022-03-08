$(document).ready(function () {
    debugger;
    $('#reservasiFormId').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'SubjectReservasi': {
                required: true
            },
            'TanggalReservasi': {
                required: true
            },
            'JamMulai': {
                required: true
            },
            'JamSelesai': {
                required: true
            },
            'JamSelesai': {
                required: true
            }

        },
        messages: {
        }
    });
    $(".datepicker").datepicker({
        dateFormat: "dd-mm-yy",
        changemonth: true,
        changeyear: true
    });
});