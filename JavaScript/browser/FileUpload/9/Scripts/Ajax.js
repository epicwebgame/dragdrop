let filesToUpload = undefined;

$(document).ready(function () {
    $("form")
        .on("dragover", e => e.preventDefault())
        .on("drop", formDropEventHandler)
        .on("submit", submitEventHandler);
});

function formDropEventHandler(event) {
    let files = (event.originalEvent || event).dataTransfer.files;
    previewFiles(files, event);

    return false;
}

function previewFiles(files, event) {
    let $previewContainer = $("#previewContainer");

    if (files && files.length > 0) {
        let imageFiles = Array.from(files).filter((file) => file.type.startsWith("image/"));
        if (imageFiles.length === 0) {
            event.stopPropagation();
            event.preventDefault();
            return false;
        }

        filesToUpload = imageFiles;
        $previewContainer.children().remove();

        for (let file of imageFiles) {
            let src = (window.URL || window.webkitURL).createObjectURL(file);
            let img = `<img src = "${src}" class = "previewImage" />`;
            let newDiv = `<div class = "previewItem"><div class = "previewImageContainer">${img}</div><div class = "previewImageFileName">${file.name}</div></div>`;

            $previewContainer.append(newDiv);
        }

        $("span").hide();
        $("#btnSubmit").val(`Upload these ${imageFiles.length} images`).show();
        $("#message").hide();
    }
}

function submitEventHandler(event) {
    if (!filesToUpload || filesToUpload.length === 0) {
        return false;
    }

    let boundary = "---------------------------85341363719878";
    let requestBody = `${boundary}`;
    filesToUpload.forEach(function (file) {
        let reader = new FileReader();
        reader.onload = function (event) {
            let arrayBuffer = event.target.result;
            // let s = new TextDecoder().decode(arrayBuffer);
            let fileContentsAsString = String.fromCharCode.apply(null, new Uint8Array(arrayBuffer));
            requestBody += `\r\nContent-Disposition: form-data; name="files"; filename="${file.name}"\r\nContent-Type: ${file.type}\r\n\r\n${fileContentsAsString}\r\n${boundary}`;
        };
        reader.readAsArrayBuffer(file);
    });

    requestBody += "--";

    let xhr = new XMLHttpRequest();
    xhr.open("POST", "/Home/Ajax", true);
    xhr.setRequestHeader("Content-Type", `Content-Type: multipart/form-data; boundary=${boundary}`);
    xhr.onload = function (event) {
        $("#message").text(event.target.responseText).removeClass("errorMessage").addClass("successMessage").show();
    };
    xhr.error = function (event) {
        $("#message").text(event.target.statusText).removeClass("successMessage").addClass("errorMessage").show();
    };
    xhr.send(requestBody);

    return false;
}