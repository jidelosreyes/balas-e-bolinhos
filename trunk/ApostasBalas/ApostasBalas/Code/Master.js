/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
$(document).ready(function () {

    //#region Menu Routing

    $('#liHome').click(function () {
        $(window.location).attr('href', 'Home');
    });

    $('#liCampeonatos').click(function () {
        $(window.location).attr('href', 'Campeonatos');
    });

    $('#liApostas').click(function () {
        $(window.location).attr('href', 'Apostas');
    });

    $('#liClassificacao').click(function () {
        $(window.location).attr('href', 'Classificacao');
    });

    $('#liEstatisticas').click(function () {
        $(window.location).attr('href', 'Estatisticas');
    });

    //#endregion   

    $('#btnLogOut').click(function () {
        $.ajax({
            type: 'POST',
            url: 'Pages/Home.aspx/LogOut',
            data: '{}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                $(window.location).attr('href', 'Inicio')
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

    //#region Process Indicator

    var ProcessMessage = $("#ProcessMessage");
    var ProcessFilter = $("#ProcessFilter");
    ProcessMessage._hide();
    ProcessFilter._hide();
    $.ajaxSetup({
        beforeSend: function () {
            // show gif here, eg:
            ProcessMessage.fadeIn();
            ProcessFilter.fadeIn();
        },
        complete: function () {
            // hide gif here, eg:
            ProcessMessage.fadeOut();
            ProcessFilter.fadeOut();
        }
    });

    //#endregion

});