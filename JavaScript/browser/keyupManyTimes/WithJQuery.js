$(document).ready(function() {
    $("#btnShow").click(showButtonClickEventHandler);
});

function textboxKeyUpEventHandler(event) {
    if (event.keyCode === 13) {
        console.log("key up");
    }
}

function showButtonClickEventHandler(event) {
    let $control = $("#textboxContainer");
    let markup = "<div id = \"textboxContainer\"> \
    <input type = \"text\" class = \"textbox\" /> \
    <button id = \"btnHide\">Ok, make me go away</button> \
    </div>";

    // $(document).off("keyup", ".textbox", textboxKeyUpEventHandler);
    // $(document).off("click", "#btnHide", hideButtonClickEventHandler);

    if ($control && $control.length > 0) {
        $control.remove();
    }

    $(document.body).append(markup);

    $(document).on("keyup", ".textbox", null, textboxKeyUpEventHandler);
    $(document).on("click", "#btnHide", null, hideButtonClickEventHandler);
}

function hideButtonClickEventHandler(event) {
    let $control = $("#textboxContainer");
    
    if ($control && $control.length > 0) {
        $control.remove();
    }

    // $(document).off("keyup", ".textbox", textboxKeyUpEventHandler);
    // $(document).off("click", "#btnHide", hideButtonClickEventHandler);
}