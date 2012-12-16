/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
/// <reference path="../Scripts/jquery.validate.min.js" />
$.fx.speeds._default = 1000;
$(document).ready(function () {

    //#region Tooltip Events

    $(document).tooltip(
    {
        show: {
            effect: 'slideDown'
        },
        hide: {
            effect: 'slideUp'
        }
    });

    //#endregion

    //#region Dialog Events

    $('#mdRecuperarPassword, #mdRegistar').dialog({
        autoOpen: false,
        draggable: false,
        resizable: false,
        show: 'blind',
        hide: 'blind',
        create: function (type, data) {
            $(this).parent().appendTo('#form1');
        }
    });

    //#endregion    

    //#region Click Events

    $('#btnRecuperar').click(function () {
        $('#mdRecuperarPassword').dialog('open');
        return false;
    });

    $('#btnRegistar').click(function () {
        $('#mdRegistar').dialog('open');
        return false;
    });

    $('#btnLogin').click(function () {
        $.ajax({
            type: 'POST',
            url: 'Default.aspx/Login',
            // If you want to pass parameter or data to server side function you can try line
            //data: '{'args':'Hello World'}",
            //else If you don't want to pass any value to server side function leave the data to blank line below
            data: '{}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                //Got the response from server and render to the client
                alert(msg.d);
            },
            error: function () {
                alert('erro');
            }
        });
    });

    $('#btnRecuperarPassword').click(function () {
        var email = $('#txtEmailRecup').val();
        if (!$('#form1').valid()) {
            return false;
        }
        $.ajax({
            type: 'POST',
            url: 'Default.aspx/RecuperarPassword',
            data: "{'args':'" + email + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                alert(msg.d);
            },
            error: function () {
                alert('erro');
            }
        });
    });

    $("#btnSubmeterRegisto").click(function () {
        if (!$('#form1').valid()) {
            return false;
        }
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

    //#region Validation

    $("#form1").validate(
        {
            rules: {
                email: {
                    required: true,
                    email: true
                },
                nome: {
                    required: true
                },
                password: {
                    required: true
                },
                conf_password:
                    {
                        required: true,
                        equalTo: "#txtPasswordRegisto"
                    }
            },
            messages: {
                email: {
                    required: "O campo email é obrigatorio.",
                    email: "Insere um e-mail válido."
                },
                nome: {
                    required: "O campo nome é obrigatorio.",
                },
                password: {
                    required: "O campo password é obrigatorio.",
                },
                conf_password: {
                    required: "O campo confirmação de senha é obrigatorio.",
                    equalTo: "O campo confirmação de password deve ser identico ao campo password."
                }
            },
            highlight: function (label) {
                $(label).addClass('error');
            },
            success: function (label) {
                label
                    .text('OK!').addClass('valid')
                   .addClass('success');
            }
        });

    //#endregion

});