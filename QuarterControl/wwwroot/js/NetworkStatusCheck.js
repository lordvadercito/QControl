$(document).ready(function () {
    netStatusCheck();
    setInterval(function () {
        netStatusCheck();
    }, 10000);
});

function netStatusCheck() {    
    var data = 0;
    var url = "../../Home/NetworkCheck";
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        Accept: "application/json",
        contentType: "application/json",
        dataType: "JSON",
        success: function (response) {
        },
        failure: function (response) {
        },
        error: function (response) {
        },
        complete: function (response) {
            statusChange(response);
        }
    });
}

function statusChange(status) {
    var netstatus = $("#netStatus");
    netstatus.find('span').remove();
    netstatus.empty();
    netstatus.append("<span class='glyphicon " + ((status.responseJSON == "OK") ? "glyphicon-ok-circle'" : "glyphicon-remove-circle'") + "></span>&nbsp; " + ((status.responseJSON == "OK") ? "CONECTADO" : "NO CONECTADO"));
    netstatus.css('color', ((status.responseJSON == "OK") ? 'green' : 'red'));
}