let fileControl = document.getElementById("fileControl");
let btn = document.getElementById("btn");
btn.addEventListener("click", buttonClickEventHandler);

function buttonClickEventHandler(event) {
    console.clear();
    console.log(`value: ${fileControl.value}`);
    console.log(fileControl.files);

    event.preventDefault();
}