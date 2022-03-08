$(document).ready(function () {
    debugger;
    $('#ruanganFormId').validate({
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
            'NamaRuangan': {
                required: true
            },
            'Lantai': {
                required: true
            },
            'DayaTampung': {
                required: true
            }

        },
        messages: {
            'NamaRuangan': 'Silakan Inputkan Nama Ruangan',
            'Lantai': 'Silakan Inputkan Lantainya',
            'DayaTampung': 'Silakan Inputkan Daya Tampungnya'
        }
    });
});