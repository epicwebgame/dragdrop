$(document).ready(function() {

    $("#ul, #div, #txt, #textarea")
    .on("dragover", dragOverEventHandler)
    .on("dragexit", dragExitEventHandler);

    $("#ul").on("drop", listDropEventHandler);
    $("#div").on("drop", divDropEventHandler);
    $("#txt").on("drop", txtDropEventHandler);
    $("#textarea").on("drop", textareaDropEventHandler);
});

function dragOverEventHandler(event) {
    let dataTransfer = (event.originalEvent || event).dataTransfer;
    if (dataTransfer.items.length > 0) {
        $(this).css("cursor", "move");
    }

    event.preventDefault();
}

function dragExitEventHandler(event) {
    $(this).css("cursor", "default");
    event.preventDefault();
}

function dropEventHandler(event, callback) {
    let items = ((event.originalEvent || event).dataTransfer.items);

    if (items.length > 0) {

        $(event.target).html("");
        if ($(event.targert).val) {
            $(event.target).val("");
        }

        if (items.length === 1 && items[0].kind === "file") {
            let item = items[0].getAsFile();
            console.log(`${item.constructor.name}, ${typeof item}`);
            let reader = new FileReader();
            reader.onload = function(event) {
                let fileContents = reader.result;
                if (callback && typeof callback === "function") {
                    callback(fileContents);
                }
            };
            reader.readAsText(item);
        } else {
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
    }

    $(this).css("cursor", "default");
    event.preventDefault();
}

function listDropEventHandler(event) {
    let $target = $(event.target);
    dropEventHandler(event, function(content) {
        $target.append(`<li>${content}</li>`);
    });
}

function divDropEventHandler(event) {
    let $target = $(event.target);
    dropEventHandler(event, function(content) {
        $target.append(`<div>${content}</div>`);
    });
}

function txtDropEventHandler(event) {
    let $target = $(event.target);
    dropEventHandler(event, function(content) {
        let previousText = $target.val();
        if (previousText !== "") {
            previousText += "; ";
        }
        $target.val(`${previousText}${content}`);
    });
}

function textareaDropEventHandler(event) {
    let $target = $(event.target);
    dropEventHandler(event, function(content) {
        let previousText = $target.val();
        if (previousText !== "") {
            previousText += "\r\n";
        }
        $target.val(`${previousText}${content}`);
    });
}