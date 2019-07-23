(function() {
    const allDivs = document.querySelectorAll("div");
    allDivs.forEach(function(value, key) {
        const parent = value.parentElement;
        let parentHasId = (parent.id && (parent.id !== ""));
        let parentIdString = parentHasId ? "#" + parent.id : "";
        console.log(`${value.id}.parent: ${parent.nodeName.toLowerCase()}${parentIdString}`);

       const firstChild = document.getElementById("firstChild");
       const secondChild = document.getElementById("secondChild");
       const child1 = document.getElementById("child1");
       const child2 = document.getElementById("child2");

       firstChild.setAttribute("style", "width: 10%; height: 10%;");
       secondChild.setAttribute("style", "width: 10%; height: 10%;");
       child1.setAttribute("style", "width: 10%; height: 10%;");
       child2.setAttribute("style", "width: 10%; height: 10%;");
   });
})();