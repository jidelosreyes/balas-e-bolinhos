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

    function Teste() {
        alert('cenas');
    };

    $.ajax({
        type: 'POST',
        url: '/Service/ApostasService.svc/ObterComp',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            var object = JSON.parse(data.d);
            $.each(object, function (i, item) {
                alert(item.Descricao);
                alert(item.IdCompeticao);
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