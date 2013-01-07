/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
$(document).ready(function () {

    //#region Menu Routing

    $('body').css('display', 'none');
    $('body').fadeIn(1000);

    $('#liHome').click(function (event) {
        event.preventDefault();
        linkLocation = 'Home';
        $('body').fadeOut(1000, redirectPage);
        //$(window.location).attr('href', 'Home');
    });

    $('#liCampeonatos').click(function (event) {
        event.preventDefault();
        linkLocation = 'Campeonatos';
        $('body').fadeOut(1000, redirectPage);
        //$(window.location).attr('href', 'Campeonatos');
    });

    $('#liApostas').click(function (event) {
        event.preventDefault();
        linkLocation = 'Apostas';
        $('body').fadeOut(1000, redirectPage);
        //$(window.location).attr('href', 'Apostas');
    });

    $('#liClassificacao').click(function (event) {
        event.preventDefault();
        linkLocation = 'Classificacao';
        $('body').fadeOut(1000, redirectPage);
        //$(window.location).attr('href', 'Classificacao');
    });

    $('#liEstatisticas').click(function (event) {
        event.preventDefault();
        linkLocation = 'Estatisticas';
        $('body').fadeOut(1000, redirectPage);
        //$(window.location).attr('href', 'Estatisticas');
    });

    function redirectPage() {
        window.location = linkLocation;
    }

    //#endregion     

    //#region Log Out

    $('#btnLogOut').click(function () {
        $.ajax({
            type: 'POST',
            url: '/Service/ApostasService.svc/LogOut',
            data: '{}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                $(window.location).attr('href', 'Inicio');
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

    //#endregion

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