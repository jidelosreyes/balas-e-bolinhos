/// <reference path="../Content/jqwidgets/jqx.base.css" />

/// <reference path="../Scripts/jNotify.jquery.min.js" />
/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$(document).ready(function () {
    $('#liAdmin').addClass('selected');
    $("#myButton").jqxButton({ width: '120px', height: '35px', theme: 'darkblue' });
    var source = [
                    "Affogato",
                    "Americano",
                    "Bicerin",
                    "Breve",
                    "Café Bombón",
                    "Café au lait",
                    "Caffé Corretto",
                    "Café Crema",
                    "Caffé Latte",
                    "Caffé macchiato",
                    "Café mélange",
                    "Coffee milk",
                    "Cafe mocha",
                    "Cappuccino",
                    "Carajillo",
                    "Cortado",
                    "Cuban espresso",
                    "Espresso",
                    "Eiskaffee",
                    "The Flat White",
                    "Frappuccino",
                    "Galao",
                    "Greek frappé coffee",
                    "Iced Coffee﻿",
                    "Indian filter coffee",
                    "Instant coffee",
                    "Irish coffee",
                    "Liqueur coffee"
		        ];
    $("#jqxWidget").jqxDropDownList({ source: source, selectedIndex: 1, width: '200', height: '25', theme: 'base' });
       
    $.ajax({
        type: 'POST',
        url: '/Service/ApostasService.svc/ObterCompeticoes',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var data2 = JSON.parse(result.d);
            var source2 =
            {
                datatype: "json",
                datafields: [
                    { name: 'IdCompeticao', type: 'string' },
                    { name: 'Descricao', type: 'string' },
                    { name: 'DataCriacao', type: 'string' },
                    { name: 'DataActualizacao', type: 'string' }
                ],
                localdata: result.d
            };
            var dataAdapter = new $.jqx.dataAdapter(source2);
            $("#jqxgrid").jqxGrid(
            {
                width: '100%',
                source: dataAdapter,
                theme: 'base',
                columnsresize: false,
                autoheight: true,
                scrollbarsize: 0,               
                columns: [
                    { text: 'Id', datafield: 'IdCompeticao' },
                    { text: 'Descricao', datafield: 'Descricao' },
                    { text: 'Data Criacao', datafield: 'DataCriacao' },
                    { text: 'Data Actualizacao', datafield: 'DataActualizacao' }
                ]
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