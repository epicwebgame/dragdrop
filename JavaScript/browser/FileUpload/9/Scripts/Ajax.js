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

async function submitEventHandler(event) {

    event.preventDefault();

    if (!filesToUpload || filesToUpload.length === 0) {
        return false;
    }

    let boundary = "---------------------------85341363719878";
    let requestBody = `${boundary}`;

    for (let file of filesToUpload) {
        let fileChunk = await new MyFile(file, boundary).readAsArrayBuffer();
        requestBody += fileChunk;
    }
    
    requestBody += "--";

    let xhr = new XMLHttpRequest();
    xhr.open("POST", "/Home/Ajax", true);
    xhr.setRequestHeader("Content-Type", `multipart/form-data; boundary=${boundary}`);
    xhr.onload = function (event) {
        $("#message").text(event.target.responseText).removeClass("errorMessage").addClass("successMessage").show();
    };
    xhr.error = function (event) {
        $("#message").text(event.target.statusText).removeClass("successMessage").addClass("errorMessage").show();
    };
    xhr.send(requestBody);

    return false;
}

function MyFile(file, boundary) {
    this.file = file;
    this.boundary = boundary;
}

MyFile.prototype.readAsArrayBuffer = function () {
    let file = this.file;
    let boundary = this.boundary;
    return new Promise(readAsArrayBufferInternal);

    function readAsArrayBufferInternal(resolve, reject) {
        let reader = new FileReader();
        //reader.onload = function (event) {
        //    let arrayBuffer = event.target.result;
        //    let fileContentsAsString = new TextDecoder().decode(arrayBuffer);
        //    // let fileContentsAsString = String.fromCharCode.apply(null, new Uint8Array(arrayBuffer));
        //    let fileChunk = `\r\nContent-Disposition: form-data; name="files"; filename="${file.name}"\r\nContent-Type: ${file.type}\r\n\r\n${fileContentsAsString}\r\n${boundary}`;

        //    resolve(fileChunk);
        //};
        //reader.readAsArrayBuffer(file);

        reader.onload = function (event) {
            let fileContentsAsString = event.target.result;
            let fileChunk = `\r\nContent-Disposition: form-data; name="files"; filename="${file.name}"\r\nContent-Type: ${file.type}\r\n\r\n${fileContentsAsString}\r\n${boundary}`;

            resolve(fileChunk);
        };
        reader.readAsBinaryString(file);
    }
};