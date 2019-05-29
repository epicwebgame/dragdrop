$(document).ready(function () {
    $("#btnLogin").click(login);
    $("#btnGetMessage").click(getMessageFromServer);
});

function login() {
    $.ajax(`${window.serverBaseUrl}/login`, {
        method: "POST"
    });
}

function getMessageFromServer() {
    $.ajax(`${window.serverBaseUrl}/home/message`, {
        method: "POST", 
        success: function (data) {
            $("#divMessage > #message").text(data);
        }, 
        error: function () {
            $("#divMessage > #message").text("Error");
        }
    });

    $("#divMessage").show();
}