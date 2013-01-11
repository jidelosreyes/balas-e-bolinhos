/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {
    $('#liApostas').addClass('selected');

    $(document).tooltip(
    {
        show: {
            effect: 'slideDown'
        },
        hide: {
            effect: 'slideUp'
        }
    });

    $("#grdApostar").css('display', 'none');
    $("#grdVerApostas").css('display', 'none');
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
                url: '/Service/ApostasService.svc/ObterJogosApostar',
                data: dataIn,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    grdApostar.empty();
                    var object = JSON.parse(result.d);
                    $.each(object, function (i, item) {
                        var disabled = '';
                        var jogoRealizado = '<a title="Data: ' + item.Data + '" />';
                        if (item.Realizado == 'True') {
                            disabled = 'disabled="disabled"';
                            jogoRealizado = '<a title="Jogo já realizado." />';
                        }
                        var htmltoApend = '<p class="jogo"><input id="hdd" type="hidden" value=' + item.Id + ' /><span>Jogo ' + (i + 1) + '</span><label>' + item.Equipa1 + '</label><input id="txtResultado1" ' + disabled + ' type="text" value=' + item.Resultado1 + ' /><input id="txtResultado2" ' + disabled + ' type="text" value=' + item.Resultado2 + ' /><label>' + item.Equipa2 + '</label>' + jogoRealizado + '</p>';
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

    $('#ddlVerApostas').on('change', function () {
        var Id = $(this).val();
        var grdVerApostas = $("#grdVerApostas");
        if (Id == '0') {
            grdVerApostas.fadeOut(1000, function () {
                grdVerApostas.css('display', 'none');
                grdVerApostas.empty();
            });
            return false;
        };
        grdVerApostas.fadeOut(1000, function () {
            var dataIn = '{' + '"IdJornada":"' + Id + '"}';
            $.ajax({
                type: 'POST',
                url: '/Service/ApostasService.svc/ObterJornadaById',
                data: dataIn,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    grdVerApostas.empty();
                    var object = JSON.parse(result.d);
                    $.each(object, function (i, item) {
                        var htmltoApend = '<p><span>Jogo ' + (i + 1) + '</span><label>' + item.Equipa1 + '</label><input disabled="disabled" type="text" value=' + item.Resultado1 + ' /><input disabled="disabled" type="text" value=' + item.Resultado2 + ' /><label>' + item.Equipa2 + '</label></p>';
                        $(htmltoApend).appendTo(grdVerApostas);
                    });
                    var totalPontos = '<p><span>Total de Pontos</span><input disabled="disabled" class="total" type="text" value="" /></p>';
                    $(totalPontos).appendTo(grdVerApostas);
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
            grdVerApostas.fadeIn(1000);
        });
        return false;
    });

    $('#btnApostar').live('click', function () {
        var apostas = $('#grdApostar p.jogo');
        $.each(apostas, function (i, item) {
            var Resultado1 = $(item).find('#txtResultado1').val();
            var Resultado2 = $(item).find('#txtResultado2').val();
            var Id = $(item).find('#hdd').val();
            var dataIn = '{' + '"Id":"' + Id + '" ' + ',"Resultado1":"' + Resultado1 + '"' + ',"Resultado2":"' + Resultado2 + '"}';
            $.ajax({
                type: 'POST',
                url: '/Service/ApostasService.svc/Apostar',
                data: dataIn,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    jSuccess('Apostas realizadas com sucesso.',
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
        });
        return false;
    });

    CarregarJornadas();

    //CarregarJornadasAnteriores();

    //function CarregarJornadasAnteriores() {
    //    $.ajax({
    //        type: 'POST',
    //        url: '/Service/ApostasService.svc/ObterJornadasAnteriores',
    //        data: '{}',
    //        contentType: 'application/json; charset=utf-8',
    //        dataType: 'json',
    //        success: function (data) {
    //            var object = JSON.parse(data.d);
    //            $.each(object, function (i, item) {
    //                var itemToAppend = '<option value="' + item.IdJornada + '">' + item.Descricao + '</option>';
    //                $(itemToAppend).appendTo('#ddlVerApostas');
    //            });
    //            return false;
    //        },
    //        error: function () {
    //            jError('Ocorreu um erro contacte o suporte tecnico dos balas.',
    //               {
    //                   autoHide: false,
    //                   TimeShown: 3000,
    //                   HorizontalPosition: 'center',
    //                   clickOverlay: true
    //               });
    //        }
    //    });
    //}

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