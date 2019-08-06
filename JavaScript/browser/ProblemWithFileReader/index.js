$(document).ready(function() {
    $("#fileInputControl").on("change", fileInputControlChangeEventHandler);
});

function fileInputControlChangeEventHandler(event) {
    let fileInputControl = event.target;
    let files = fileInputControl.files;

    let contentOfAllFiles = "";

    // for (let file of files) {

    //     var fileReader = new FileReader();

    //     fileReader.onload = function(event) {
    //         let fileContents = event.target.result;

    //         contentOfAllFiles += file.name;
    //         contentOfAllFiles += "\r\n------------------------------\r\n";
    //         contentOfAllFiles += fileContents;
    //         contentOfAllFiles += "\r\n\r\n";
    //     }

    //     fileReader.readAsText(file);

    //     $("#preview").text(contentOfAllFiles);
    // }

    let firstFile = files[0];

    let contentOfAllFiles = "";
    var fileReader = new FileReader();
    fileReader.onload = function(event) {
        let fileContents = event.target.result;
        contentOfAllFiles += fileContents;

        let secondFile = files[1];
        var anotherFileReader = new FileReader();
    }
    fileReader.readAsText(file);


}