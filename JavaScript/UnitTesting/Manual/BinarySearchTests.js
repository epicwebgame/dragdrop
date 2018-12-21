var binarySearch = require("./BinarySearch");
var fx = require("./Fx");

function test_1() {
    var lis = [
        { innerText: "Axis Bank" }, 
        { innerText: "Frogs" }, 
        { innerText: "God" }, 
        { innerText: "Godzilla" }, 
        { innerText: "HDFC Bank" }, 
        { innerText: "Helium" }, 
        { innerText: "Romeo" }, 
        { innerText: "Sunday" }, 
        { innerText: "Zebra" }
    ];
    var expectedResult = 7;
    var result = binarySearch.binarySearch(lis, "Shortage", 0, lis.length - 1);
    console.log(fx.getThisFunctionName(), expectedResult, result);
    fx.assert(result === expectedResult);
}

test_1();