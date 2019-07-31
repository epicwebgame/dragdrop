$(document).ready(function() {
    $("#files").attr("accept", "text/*").on("change", fileInputControlChangeEventHandlerAsync);
});

async function fileInputControlChangeEventHandlerAsync(event) {
    let files = event.target.files;
    await previewFilesAsync(files, event);
}

async function previewFilesAsync(files, event) {
    if (!files || files.length === 0) {
        event.preventDefault();
        return false;
    }

    let textFiles = Array.from(files).filter(file => file.type.startsWith("text/"));

    if (textFiles.length === 0) {
        event.preventDefault();
        return false;
    }

    $("#preview").children().remove();
    
    let contentOfAllFiles = "";
    for (let i = 0; i < textFiles.length; i++) {
        let textFile = textFiles[i];
        var fileContents = await new MyFile(textFile).readAsTextAsync();
        contentOfAllFiles += fileContents;
    }

    // OR, instead of the above for loop, we can even to
    // // let promises = [];
    // let fileContentsArray = await Promise.all(promises);
    // let contentOfAllFiles = fileContentsArray.reduce((previousValue, currentValue) => `${previousValue}${currentValue}`);

    $("#preview").html(contentOfAllFiles);
}

function MyFile(file) {
    this.file = file;
}

MyFile.prototype.readAsTextAsync = function() {
    let myFile = this;
    return new Promise(readAsTextInternal);

    function readAsTextInternal(callback) {
        let fileReader = new FileReader();
        
        fileReader.onload = function(event) {
            let fileContents = myFile.file.name;
            fileContents += "<br />------------------------------------------<br />";
            fileContents += event.target.result;
            fileContents += "<br /><br />";
    
            callback(fileContents);
        };
    
        fileReader.onerror = function() {
            let message = `An error occurred while reading the file ${myFile.file.name}.`;
            if (event.target.error && event.target.error.message) {
                message += `<br />Error message: ${event.target.error.message}`;
            }
            message += "<br /><br />";
        };
        
        fileReader.readAsText(myFile.file);
    };
};