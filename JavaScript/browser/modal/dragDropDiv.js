$(document).ready(function() {
    $("#loner, #inner")
    .on("mousedown", mouseDownEventHandler)
    .on("mousemove", mouseMoveEventHandler)
    .on("mouseup", mouseUpEventHandler);
});

let diff;

function mouseDownEventHandler(event) {
    let diffX = event.clientX - $(this).offset().left;
    let diffY = event.clientY - $(this).offset().top;
    diff = { x: diffX, y: diffY };
}

function mouseMoveEventHandler(event) {
    let position = $(this).css("position");
    let parent = $(this).parent().name;
    console.log(`${position}, ${parent}, ${event.buttons & 1}`);

    // $(this).css({
    //     left: event.clientX - diff.x,
    //     top: event.clientY - diff.y
    // });
}

function mouseUpEventHandler(event) {
    diff = undefined;
}