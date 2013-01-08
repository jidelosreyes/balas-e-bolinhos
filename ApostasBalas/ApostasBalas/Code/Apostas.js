/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {
    $('#liApostas').addClass('selected');
    $("#grdApostar").css('display', 'none');
    $('#ddlApostar').on('change', function () {
        var Id = $(this).val();
        var grdApostar = $("#grdApostar");
        if (Id == '0') {
            grdApostar.fadeOut(1000, function () {
                grdApostar.css('display', 'none');
                grdApostar.empty();
            });
            return false;
        };
        grdApostar.fadeOut(1000, function () {
            var dataIn = '{' + '"IdJornada":"' + Id + '"}';
            $.ajax({
                type: 'POST',
                url: '/Service/ApostasService.svc/ObterJornadaById',
                data: dataIn,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    grdApostar.empty();
                    var object = JSON.parse(result.d);
                    $.each(object, function (i, item) {
                        var htmltoApend = '<p><span>Jogo ' + (i + 1) + '</span><label>' + item.Equipa1 + '</label><input type="text" value=' + item.Resultado1 + ' /><input type="text" value=' + item.Resultado2 + ' /><label>' + item.Equipa2 + '</label></p>';
                        $(htmltoApend).appendTo(grdApostar);
                    });
                    var submitBtn = '<p style="padding-top: 15px"><span>&nbsp;</span><input class="submit" type="submit" id="btnApostar" value="Apostar" /></p>';
                    $(submitBtn).appendTo(grdApostar);
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
            grdApostar.fadeIn(1000);
        });
        return false;
    });

    $('#btnApostar').live('click', function () {
        alert($('#grdApostar p > input').val());
        return false;
    });

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
});