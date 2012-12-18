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