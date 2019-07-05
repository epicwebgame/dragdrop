let $dialogBackground = $("#dialogBackground");
let $dialog = $("#dialog");

$(document).ready(function() {
    $("#btnShowDialog").click(showDialog);
    $(document).keyup(documentKeyUpEventHandler);
    $("#dialogTitleBarCloseButton").click(closeDialog);
});

function showDialog(event) {
    $dialogBackground.show();
    positionDialog();
    $dialog.show();
}

function closeDialog(event) {
    $dialog.hide();
    $dialogBackground.hide();
}

function positionDialog() {
    let position = getDialogPosition();
    
    let x = ($(window).width() - $dialog.width()) / 2;
    let y = ($(window).height() - $dialog.height()) / 2;
    
    if (position) {
        x = position.left;
        y = position.top;   
    }

    $dialog.css( {
        left: x, 
        top: y
    })

    setDialogPosition(x, y);
}

function setDialogPosition(x, y) {
    let dialogPosition = { left: x, top: y };
    let s = JSON.stringify(dialogPosition);
    localStorage.setItem("dialogPosition", s);
}

function getDialogPosition() {
    let s = localStorage.getItem("dialogPosition");
    return JSON.parse(s);
}

function documentKeyUpEventHandler(event) {
    if (event.key === "Escape") {
        closeDialog();
    }
}

function dialogDragStartEventHandler(event) {
    event.dataTransfer.effectAllowed = "move";
    console.log("drag start");
}