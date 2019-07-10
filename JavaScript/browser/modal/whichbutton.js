$(document).ready(function() {
    $("div")
    .on("mousedown", mouseDownEventHandler)
    .on("mousemove", mouseMoveEventHandler)
    .on("mouseup", mouseUpEventHandler);
});

function mouseDownEventHandler(event) {
    $(this).css("cursor", "move");
}

function mouseMoveEventHandler(event) {
    let leftMouseButtonPressed = (event.buttons & 1 === 1);
    
}

function mouseUpEventHandler(event) {
    $(this).css("cursor", "default");
}