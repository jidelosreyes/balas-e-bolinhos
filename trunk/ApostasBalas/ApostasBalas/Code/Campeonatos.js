/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {

    var DivCompeticoes = '#DivCompeticoes';

    $('#liCampeonatos').addClass('selected');

    $(".buttondiv").button({
        icons: {
            primary: "ui-icon-unlocked"
        }
    });

    $(DivCompeticoes).on('click', '#btnactivar', function (e) {
        $(this).toggleClass('registado', 1000).attr('disabled', true);
        Activar();
        return false;
    });

    $(DivCompeticoes).on('click', '#btnRegistar', function () {
        $(this).toggleClass('registado', 1000).attr('disabled', true);
        Registar($(this).attr('itemid'));
        return false;
    });

    CarregarCompeticoes();

    //#region Funcoes

    function CarregarCompeticoes() {
        $.ajax({
            type: 'POST',
            url: '/Service/ApostasService.svc/ObterCompeticoesRegistadas',
            data: '{}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                var object = JSON.parse(data.d);
                $.each(object, function (i, item) {
                    var ids = $('#DivCompeticoes p input[type=hidden]');
                    $.each(ids, function (i2, item2) {
                        if (item.IdCompeticao == item2.value) {
                            var itemid = '#btnRegistar[itemid="' + item2.value + '"]';
                            $(itemid).toggleClass('registado', 1000).attr('disabled', true);
                            if (item.Activo) {
                                var itemid = '#btnactivar[itemid="' + item.IdCompeticao + '"]';
                                $(itemid).toggleClass('registado', 1000).attr('disabled', true);
                            }
                        }
                    });
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

    function Registar(id) {        
        var dataIn = '{' + '"IdCompeticao":"' + id + '"}';
        $.ajax({
            type: 'POST',
            url: '/Service/ApostasService.svc/RegistarCompeticao',
            data: dataIn,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                jSuccess('Competicao registada com sucesso.',
                   {
                       autoHide: false,
                       TimeShown: 3000,
                       HorizontalPosition: 'center',
                       clickOverlay: true
                   });
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

    function Activar() {
        var id = $(this).attr('itemid');
        $.ajax({
            type: 'POST',
            url: '/Service/ApostasService.svc/ActivarCompeticao',
            data: '{}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {

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

    //#endregion    

});