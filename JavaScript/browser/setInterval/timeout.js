let handle = undefined;

$(document).ready(function() {
    $("#send").click(sendButtonClickEventHandler).prop("disabled", true);
    startTheCountDown();
});

function sendButtonClickEventHandler(event) {
    $.ajax("https://jsonplaceholder.typicode.com/todos/1", {
        success: function() {
            $("#status").text("Sent").addClass("success").removeClass("error").show();
            startTheCountDown();
        }, 
        error: function() {
            $("#status").text("Couldn't send.").addClass("error").removeClass("success").show();
        }
    });
}

function startTheCountDown() {
    handle = window.setTimeout(intervalFunction, 1000, 5 * 1000);
}

function intervalFunction(duration) {
    console.log(duration);

    // clear interval
    window.clearTimeout(handle);

    if (duration <= 0) {
        // enable the button
        $("#send").prop("disabled", false);

        // reset the seconds text
        $("#seconds").text("0");

    } else {
        let seconds = Math.ceil(duration / 1000);
        $("#seconds").text(seconds);
        duration -= 1000;
        handle = window.setTimeout(intervalFunction, 1000, duration);
    }
}