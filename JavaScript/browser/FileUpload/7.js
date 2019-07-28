$(document).ready(function() {
    // Or, the accept attribute could even be supplied a 
    // comma-separated list of MIME types like so: image/jpeg, 
    // image/png, image/gif, image/bmp
    $("#file").attr("accept", "image/*").attr("multiple", "true").on("change", fileInputControlChangeEventHandler);
});

function fileInputControlChangeEventHandler(event) {
    previewFiles(event.target.files);
}

function previewFiles(files) {
    let $previewContainer = $("#previewContainer");

    if (files && files.length > 0) {
        $previewContainer.children().remove();

        for (let file of files) {
            let src = (window.URL || window.webkitURL).createObjectURL(file);
            let img = `<img src = "${src}" class = "previewImage" />`;
            let newDiv = `<div class = "previewItem"><div class = "previewImageContainer">${img}</div><div class = "previewImageFileName">${file.name}</div></div>`;

            $previewContainer.append(newDiv);
        }

        $("#numImages").text(`${files.length} images`).show();
        $("#btnSubmit").val(`Upload these ${files.length} images`).show();
    }
}