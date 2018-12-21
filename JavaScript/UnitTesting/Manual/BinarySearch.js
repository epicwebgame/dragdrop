var comparer = require("./Comparer");

module.exports.binarySearch = function binarySearch(lis, itemText, from, to) {

    var diff = to - from;
    if (diff > 0 && diff <= 1) {
        let result = comparer.compareStrings(itemText, lis[to].innerText);
        return (result < 0) ? from: to;
    }

    let midpoint = from + parseInt(diff / 2, 10);
    let result = comparer.compareStrings(itemText, lis[midpoint].innerText);

    if (result < 0) {
        return module.exports.binarySearch(lis, itemText, from, midpoint - 1);
    } else if (result > 0) {
        return module.exports.binarySearch(lis, itemText, midpoint + 1, to);
    } else {
        return midpoint;
    }
}

module.exports.getInsertionIndex = function getInsertionIndex($targetList, itemText) {
    let lis = $targetList.children("li");
    let len = lis.length;
    let midpoint = parseInt((0 + (len - 1)) / 2, 10);

    if (len === 0) return 0;
    var result = comparer.compareStrings(itemText, lis[midpoint].innerText);
    if (len === 1) return (result < 0) ? 0 : 1;

    if (result < 0) {
        // itemText is smaller / lesser than the current mid-point
        return module.exports.binarySearch(lis, itemText, 0, midpoint - 1);
    } else if (result > 0) {
        // itemText is larger / greater than the current mid-point
        return module.exports.binarySearch(lis, itemText, midpoint + 1, len - 1);
    } else {
        // itemText is equal to the current mid-point
        return midpoint;
    }
}