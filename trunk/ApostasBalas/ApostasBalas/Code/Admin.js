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

});