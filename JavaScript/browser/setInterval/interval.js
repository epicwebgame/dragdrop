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
    let duration = 5000;

    handle = window.setInterval( () => {
        console.log(duration);

        if (duration <= 0) {
            // clear the interval
            window.clearInterval(handle);

            // enable the button
            $("#send").prop("disabled", false);

            // reset the seconds text
            $("#seconds").text("0");

        } else {
            let seconds = Math.ceil(duration / 1000);
            $("#seconds").text(seconds);
            duration -= 1000;
        }
    }, 1000);
}