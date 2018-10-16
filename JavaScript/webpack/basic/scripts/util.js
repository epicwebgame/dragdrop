export default function doo(message) {
    var contentDiv = document.getElementById("content");
    print(message);
    write(contentDiv, message);
}

function print(message) {
    console.info(message);
}

function write(targetElement, message) {
    targetElement.innerHTML = message;
}