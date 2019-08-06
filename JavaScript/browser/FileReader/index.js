$(document).ready(function() {
    $("#fileInputControl").on("change", fileInputControlChangeEventHandler);
});

function fileInputControlChangeEventHandler(event) {
    let fileInputControl = event.target;
    let files = fileInputControl.files;

    let firstFile = files[0];

    let fileReader = new FileReader();

    fileReader.onload = function(event) {
        let dataUrl = event.target.result;
        $("#preview").attr("src", `${dataUrl}`);
     }
    
    fileReader.readAsDataURL(firstFile);
}