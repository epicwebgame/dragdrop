$(document).ready(function () {
    $("form").on("dragover", e => e.preventDefault()).on("drop", formDropEventHandler);
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

        $previewContainer.children().remove();

        let form = document.getElementsByTagName("form")[0];
        let formData = form.formData || new FormData(form);

        for (let file of imageFiles) {
            let src = (window.URL || window.webkitURL).createObjectURL(file);
            let img = `<img src = "${src}" class = "previewImage" />`;
            let newDiv = `<div class = "previewItem"><div class = "previewImageContainer">${img}</div><div class = "previewImageFileName">${file.name}</div></div>`;

            $previewContainer.append(newDiv);

            formData.append("files", file, file.name);
        }

        $("span").hide();
        // $("#numImages").text(`${imageFiles.length} images`).show();
        $("#btnSubmit").val(`Upload these ${imageFiles.length} images`).show();
    }
}