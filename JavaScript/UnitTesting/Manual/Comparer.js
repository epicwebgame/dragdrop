module.exports.compareNumbers = function compareNumbers(first, second) {
    if (first === second) {
        return 0;
    } else if (first > second) {
        return 1;
    } else {
        return -1;
    }
}

module.exports.compareStrings = function compareStrings(first, second, caseSensitive = false) {
    let fLen = first.length;
    let sLen = second.length;
    let len = (fLen < sLen) ? fLen : sLen;
    let equal = false;

    for (let i = 0; i < len; i++) {
        let f = caseSensitive ? first[i] : first[i].toUpperCase();
        let s = caseSensitive ? second[i] : second[i].toUpperCase();

        if (f === s) {
            equal = true;
            continue;
        } else if (f > s) {
            equal = false;
            return 1;
        } else {
            equal = false;
            return -1;
        }
    }

    return (equal && module.exports.compareNumbers(fLen, sLen));
}