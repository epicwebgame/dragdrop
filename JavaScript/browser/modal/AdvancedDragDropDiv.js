$(document).ready(function() {
    $("#loner, #innerOnItsOwnSeparateLayer, #innerOnSameLayerAsOuter")
    .on("mousedown", mouseDownEventHandler)
    .on("mousemove", mouseMoveEventHandler)
    .on("mouseup", mouseUpEventHandler);
});

let diff;

function mouseDownEventHandler(event) {
    let $target = $(this);
    let $offset = $target.offset();

    let diffX = event.clientX - $offset.left;
    let diffY = event.clientY - $offset.top;

    let $parent = $target.parent();
    let parentLeft = 0;
    let parentTop = 0;

    if ($parent) {
        parentLeft = $parent.offset().left;
        parentTop = $parent.offset().top;
    }

    diff = { x: diffX, y: diffY, parentLeft: parentLeft, parentTop: parentTop };

    console.log(diff);
    $target.css("cursor", "move");
}

function mouseMoveEventHandler(event) {

    console.log(`clientX: ${event.clientX}, clientY: ${event.clientY}`);

    let $target = $(this);

    if (diff) {
        $target.css({
            left: event.clientX - diff.x - diff.parentLeft,
            top: event.clientY - diff.y - diff.parentTop
        });

        console.log(event.clientX - diff.x - diff.parentLeft);
    }
    
    console.log(`left: ${$target.position().left}, top: ${$target.position().top}`);
}

function mouseUpEventHandler(event) {
    diff = undefined;
    $(this).css("cursor", "default");
}