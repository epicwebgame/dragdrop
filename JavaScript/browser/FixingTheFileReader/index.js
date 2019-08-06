$(document).ready(function() {
    $("#fileInputControl").on("change", fileInputControlChangeEventHandlerAsync);
});

async function fileInputControlChangeEventHandlerAsync(event) {
    let fileInputControl = event.target;
    let files = fileInputControl.files;

    let contentOfAllFiles = "";

    for (let file of files) {

        var myFileReader = new MyFileReader();

        let fileContents = await myFileReader.readAsTextAsync(file);

        contentOfAllFiles += fileContents;
    }

    $("#preview").text(contentOfAllFiles);
}

function MyFileReader() { }

MyFileReader.prototype.readAsTextAsync = function(file) {
    return new Promise( (resolve, reject) => {
        try {
            var reader = new FileReader();

            reader.onload = function(event) {
                let fileContents = event.target.result;

                let fileChunk = file.name;
                fileChunk += "\r\n------------------------------\r\n";
                fileChunk += fileContents;
                fileChunk += "\r\n\r\n";

                resolve(fileChunk);
            }

            reader.readAsText(file);
        } catch(error) {
            reject(error);
        }
    } );
}