﻿/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
$.fx.speeds._default = 1000;
$(document).ready(function () {

    //#region Tooltip Events

    $(document).tooltip(
    {
        show: {
            effect: "slideDown"
        },
        hide: {
            effect: "slideUp"
        }
    });

    //#endregion

    //#region Dialog Events

    $("#mdRecuperarPassword, #mdRegistar").dialog({
        autoOpen: false,
        draggable: false,
        resizable: false,
        show: "blind",
        hide: "blind"
    });

    //#endregion    

    //#region Click Events

    $("#btnRecuperar").click(function () {
        $("#mdRecuperarPassword").dialog("open");
        return false;
    });

    $("#btnRegistar").click(function () {
        $("#mdRegistar").dialog("open");
        return false;
    });

    $("#btnLogin").click(function () {
        $.ajax({
            type: "POST",
            url: "Default.aspx/Login",
            // If you want to pass parameter or data to server side function you can try line
            //data: "{'args':'Hello World'}",
            //else If you don't want to pass any value to server side function leave the data to blank line below
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                //Got the response from server and render to the client
                alert(msg.d);
            },
            error: function () {
                alert('erro');
            }
        });
    });

    $("#btnRecuperarPassword").click(function () {
        $.ajax({
            type: "POST",
            url: "Default.aspx/RecuperarPassword",
            // If you want to pass parameter or data to server side function you can try line
            //data: "{'args':'Hello World'}",
            //else If you don't want to pass any value to server side function leave the data to blank line below
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                //Got the response from server and render to the client
                alert(msg.d);
            },
            error: function () {
                alert('erro');
            }
        });
    });

    $("#btnSubmeterRegisto").click(function () {
        $.ajax({
            type: "POST",
            url: "Default.aspx/Registar",
            // If you want to pass parameter or data to server side function you can try line
            //data: "{'args':'Hello World'}",
            //else If you don't want to pass any value to server side function leave the data to blank line below
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                //Got the response from server and render to the client
                alert(msg.d);
            },
            error: function () {
                alert('erro');
            }
        });
    });

    //#endregion
});