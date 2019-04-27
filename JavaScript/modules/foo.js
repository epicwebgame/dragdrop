"use strict";

export let message = "Message from foo.js";
console.log("Started reading foo.js");

if (!window.howManyTimesFooInvoked) {
    window.howManyTimesFooInvoked = 0;
}

window.howManyTimesFooInvoked++;

console.log(`foo.js => \
window.howManyTimesFooInvoked: ${window.howManyTimesFooInvoked}`);

let initialized = false;

if (!initialized) {
    let expensiveOperationResut = 
    runMyExpensiveOperation();
    
    initialized = true;
}
