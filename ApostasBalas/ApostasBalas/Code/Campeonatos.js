/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {

    //#region Variaveis

    var DivCompeticoes = '#DivCompeticoes';

    //#endregion

    //#region Bind de Eventos

    $('#liCampeonatos').addClass('selected');

    $(".buttondiv").button({
        icons: {
            primary: "ui-icon-unlocked"
        }
    });

    $('#DivCompeticoes p #btnactivar').attr('disabled', true);

    $(DivCompeticoes).on('click', '#btnactivar', function (e) {
        var Id = $(this).attr('itemid');
        $(this).toggleClass('registado', 1000).attr('disabled', true);
        var botoes = $('#DivCompeticoes p');
        $.each(botoes, function myfunction(i, item) {
            var btnregClass = $(item).children('#btnRegistar').hasClass('registado');
            var btnAct = $(item).children('#btnactivar');
            var btnItemId = $(btnAct).attr('itemid');
            if (btnItemId != Id) {
                if (btnregClass) {
                    btnAct.removeClass('registado').attr('disabled', false);
                } else {
                    btnAct.attr('disabled', true);
                };
            };
        });
        Activar(Id);
        return false;
    });

    $(DivCompeticoes).on('click', '#btnRegistar', function () {
        $(this).toggleClass('registado', 1000).attr('disabled', true);
        var itemid = $(this).attr('itemid');
        Registar(itemid);
        var btnActivarId = '#btnactivar[itemid="' + itemid + '"]';
        $(btnActivarId).attr('disabled', false);
        return false;
    });

    //#endregion

    //#region Carregar Competicoes

    CarregarCompeticoes();

    //#endregion

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
                            var btnRegistar = '#btnRegistar[itemid="' + item2.value + '"]';
                            var btnActivar = '#btnactivar[itemid="' + item.IdCompeticao + '"]';
                            $(btnActivar).attr('disabled', false);
                            $(btnRegistar).toggleClass('registado', 1000).attr('disabled', true);
                            if (item.Activo) {
                                $(btnActivar).toggleClass('registado', 1000).attr('disabled', true);
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

    function Activar(id) {
        var dataIn = '{' + '"IdCompeticao":"' + id + '"}';
        $.ajax({
            type: 'POST',
            url: '/Service/ApostasService.svc/ActivarCompeticao',
            data: dataIn,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                jSuccess('Competicao activada com sucesso.',
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

    //#endregion    

});