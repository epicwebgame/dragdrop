$(document).ready(function() {

    $("#btnJQuery").click(() => {
        let one = $("#one");
        one.css("background-color", "green");

        let theOtherOne = $("#two > #one");
        theOtherOne.css("background-color", "green");
    });

    $("#btnJavaScript").click(() => {
        let one = document.getElementById("one");
        one.style.backgroundColor = "yellow";

        let theOtherOne = document.querySelector("#two > #one");
        theOtherOne.style.backgroundColor = "yellow";
    });
});