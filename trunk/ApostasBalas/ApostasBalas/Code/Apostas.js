/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {
    $('#liApostas').addClass('selected');

    CarregarJornadas();

    function CarregarJornadas() {
        $.ajax({
            type: 'POST',
            url: '/Service/ApostasService.svc/ObterJornadas',
            data: '{}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                var object = JSON.parse(data.d);
                $.each(object, function (i, item) {
                    var itemToAppend = '<option value="' + item.IdJornada + '">' + item.Descricao + '</option>';
                    $(itemToAppend).appendTo('#ddlApostar');
                    $(itemToAppend).appendTo('#ddlVerApostas');
                });
                return false;
            },
            error: function () {
                jError('Ocorreu um erro contacte o suporte tecnico dos balas.',
                   {
                       autoHide: false,
                       TimeShown: 3000,
                       HorizontalPosition: 'center',
                       clickOverlay: true
                   });
            }
        });
    };

    $('#ddlApostar, #ddlVerApostas').on('change', function () {
        alert($(this).val());
        return false;
    });

});