/// <reference path="../Scripts/jquery-1.8.3.min.js" />
/// <reference path="../Scripts/jquery-ui-1.9.2.min.js" />
$(document).ready(function () {

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

    //#region Notification
    //#endregion

});