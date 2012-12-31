/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {
    $('#liHome').addClass('selected');
    $('#example tr').each(function () {
        var th = $(this).closest('tr').find('th');
        if (th != null) {
            $(this).addClass('TableNormal')
        }
        var posicao = $(this).closest('tr').find('td:first').text();
        if (posicao == 1) {
            $(this).addClass('TableHighlight');
        }
        else {
            $(this).addClass('TableOther');
        }
    });
});