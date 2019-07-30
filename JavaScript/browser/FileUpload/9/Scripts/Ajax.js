$(document).ready(function () {
    // Or, the accept attribute could even be supplied a 
    // comma-separated list of MIME types like so: image/jpeg, 
    // image/png, image/gif, image/bmp
    $("#file").attr("accept", "image/*").on("change", fileInputControlChangeEventHandler);

    $("#btnSelect").click(selectButtonClickEventHandler);
    $("form").on("submit", submitEventHandler);
});

function selectButtonClickEventHandler(event) {
    $("#file").click();
    return false;
}

let filesToUpload = undefined;

function fileInputControlChangeEventHandler(event) {
    previewFiles(event.target.files, event);
    $("#message").hide();
}

function previewFiles(files, event) {
    let $previewContainer = $("#previewContainer");

    if (files && files.length > 0) {

        let imageFiles = Array.from(files).filter((file) => file.type.startsWith("image/"));
        if (imageFiles.length === 0) {
            event.stopPropagation();
            event.preventDefault();
        }

        filesToUpload = imageFiles;
        $previewContainer.children().remove();

        for (let file of imageFiles) {
            let src = (window.URL || window.webkitURL).createObjectURL(file);
            let img = `<img src = "${src}" class = "previewImage" />`;
            let newDiv = `<div class = "previewItem"><div class = "previewImageContainer">${img}</div><div class = "previewImageFileName">${file.name}</div></div>`;

            $previewContainer.append(newDiv);
        }

        $("#numImages").text(`${files.length} images`).show();
        $("#btnSubmit").val(`Upload these ${files.length} images`).show();
    }
}

function submitEventHandler(event) {
    if (!filesToUpload || filesToUpload.length === 0) {
        return false;
    }

    let requestBody = `${boundary}\r\n`;
    let boundary = "---------------------------85341363719878";
    filesToUpload.forEach(function (file) {
        let reader = new FileReader();
        reader.onload = function (event) {
            let arrayBuffer = event.target.result;
            // let s = new TextDecoder().decode(arrayBuffer);
            let fileContentsAsString = String.fromCharCode.apply(null, new Uint8Array(arrayBuffer));
            requestBody += `Content-Disposition: form-data; name = "files"; filename = "${file.name}\r\nContent-Type: ${file.type}\r\n${fileContentsAsString}\r\n${boundary}"`;
        };
        reader.readAsArrayBuffer(file);
    });

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
}