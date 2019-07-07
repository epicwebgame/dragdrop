
function dragStartEventHandler(event) {
    console.log("drag started");
    event.dataTransfer.setData("text", "foo");
    event.dataTransfer.effectAllowed = "move";
}

(function() {
    // let draggableItem = document.getElementById("aDiv");
    // draggableItem.addEventListener("dragstart", dragStartEventHandler);

    $(document).on("dragstart", "#aDiv", dragStartEventHandler);
})();