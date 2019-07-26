$(document).ready(function() {

    $("#txt, #textarea").on("dragover", dragOverEventHandler);
    
    $("#txt").on("drop", txtDropEventHandler);
    $("#textarea").on("drop", textareaDropEventHandler);
});

function dragOverEventHandler(event) {
    event.preventDefault();
}

function dropEventHandler(event, callback) {
    let items = ((event.originalEvent || event).dataTransfer.items);

    if (items.length > 0) {
        for (let item of items) {
            let content = undefined;
            if (item.kind === "file") {
                content = item.getAsFile().name;
                if (callback && typeof callback === "function") {
                    callback(content);
                }
            } else if (item.kind === "string") {
                item.getAsString(s => { 
                    content = s;
                    if (callback && typeof callback === "function") {
                        callback(content);
                    }
                });
            }
        }
    }

    $(this).css("cursor", "default");
    event.preventDefault();
}

function txtDropEventHandler(event) {
    dropEventHandler(event, function(content) {
        let previousText = $(event.target).val();
        if (previousText !== "") {
            previousText += "; ";
        }
        $(event.target).val(`${previousText}${content}`);
    });
}

function textareaDropEventHandler(event) {
    dropEventHandler(event, function(content) {
        let previousText = $(event.target).val();
        if (previousText !== "") {
            previousText += "\r\n";
        }
        $(event.target).val(`${previousText}${content}`);
    });
}