let dragStartContext = undefined;

$(document).ready(function() {
    $("#theDiv").on("dragstart", dragStartEventHandler);
    $("body").on("dragover", dragoverEventHandler);
    $("body").on("drop", dropEventHandler);
});

function dragStartEventHandler(event) {
    (event.originalEvent || event).dataTransfer.setData("text", "");
    
    let $target = $(this);
    let $offset = $target.offset();
    let diffX = event.clientX - $offset.left;
    let diffY = event.clientY - $offset.top;
    let $parent = $target.parent();

    dragStartContext = {
        $target: $target,
        $parent: $parent,
        diffX: diffX, 
        diffY: diffY, 
        parentLeft: $parent === undefined || $parent.prop("nodeName").toLowerCase() === "body" ? 0: $parent.offset().left,
        parentTop: $parent === undefined || $parent.prop("nodeName").toLowerCase() === "body" ? 0: $parent.offset().top
    };

    $target.css("cursor", "move");
    console.log("dragstart");
}

function dropEventHandler(event) {
    let data = (event.originalEvent || event).dataTransfer.getData("text");

    if (dragStartContext) {
        let left = event.clientX - dragStartContext.diffX - dragStartContext.parentLeft;
        let top = event.clientY - dragStartContext.diffY - dragStartContext.parentTop;
        
        dragStartContext.$target.css({
            left: left,
            top: top,
            cursor: "default"
        });

        console.log("drop");
    }
}

function dragoverEventHandler(event) {
    console.log("dragover");
    event.preventDefault();
}