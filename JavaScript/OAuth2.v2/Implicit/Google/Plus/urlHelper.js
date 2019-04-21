"use strict";

export function getValueOfQueryStringParameter(url, parameterName) {
    let keyFragment = `${parameterName}=`;
    let startIndexOfKey;
    startIndexOfKey = url.indexOf(keyFragment);
    
    if (startIndexOfKey === -1) {
        return;
    }

    let startIndex = startIndexOfKey + keyFragment.length;
    let endIndex = url.length - 1;

    for(let i = startIndex; i < url.length; i++) {
        if (url[i] === "&") {
            endIndex = i - 1;
            break;
        }
    }

    if (startIndex >= endIndex) return "";

    let value = url.substr(startIndex, (endIndex - startIndex) + 1);

    return value;
}