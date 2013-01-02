/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {
    $('#liCampeonatos').addClass('selected');

//    $('#example').delegate('input', 'click', function () {
//        var tr = $(this).parents('tr:first');
//        tds = tr.find('td');
//        l = tds.length;

//        tds.fadeOut('slow', function () {
//            if (! --l) {
//                tr.remove();
//                alert('ajax');
//            }
//        });
//        //alert('teste');
//        return false;
//    });

    $(".buttondiv").button({
        icons: {
            primary: "ui-icon-check"
        }
    });

    $('#DivCompeticoes').delegate('button', 'click', function () {
        //        var tr = $(this).parents('p');
        //        $(tr).slideUp('slow', function () {
        //            $(this).remove();
        //            alert('ajax');
        //        });
        $(this).toggleClass('Registado', 1000);
        return false;
    });

});