let mouseDownContext = undefined;

$(document).ready(function() {
    $("#theDiv").on("mousedown", mouseDownEventHandler).on("mousemove", mouseMoveEventHandler).on("mouseup", mouseUpEventHandler);
});

function mouseDownEventHandler(event) {
    if ((event.buttons & 1) === 1) {
        console.clear();

        let $target = $(this);
        let $parent = $(this).parent();
        let $offset = $target.offset();
        let parentLeft = ($parent === undefined || $parent.prop("nodeName").toLowerCase() === "body") ? 0 : $parent.offset().left;
        let parentTop = ($parent === undefined || $parent.prop("nodeName").toLowerCase() === "body") ? 0 : $parent.offset().top;

        let diffX = event.clientX - $offset.left - parentLeft;
        let diffY = event.clientY - $offset.top - parentTop;
        
        mouseDownContext = {
            $target: $target,
            $parent: $parent,
            diffX: diffX,
            diffY : diffY,
            parentLeft: parentLeft,
            parentTop: parentTop
        };

        $target.css("cursor", "move");

        console.log("mousedown");
    }
}

function mouseMoveEventHandler(event) {
    if (mouseDownContext && ((event.buttons & 1) === 1)) {
        let left = event.clientX - mouseDownContext.diffX - mouseDownContext.parentLeft;
        let top = event.clientY - mouseDownContext.diffY - mouseDownContext.parentTop;
        
        mouseDownContext.$target.css({
            left: left,
            top: top
        });

        console.log("mousemove");
    }
}

function mouseUpEventHandler(event) {
    if (mouseDownContext) {
        mouseDownContext.$target.css("cursor", "default");
        mouseDownContext = undefined;
        console.log("mouseup");
    }
}