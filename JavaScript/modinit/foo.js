"use strict";

export let message = "Message from module foo";

console.log("Started reading module foo");
if (!window.fooModuleInvokedHowManyTimes) {
    window.fooModuleInvokedHowManyTimes = 0;
}
window.fooModuleInvokedHowManyTimes++;

let initialized = false;
if (!initialized) {
    console.log("Initializing foo.");
    
    if (!window.fooInitializedHowManyTimes) {
        window.fooInitializedHowManyTimes = 0;
    }

    window.fooInitializedHowManyTimes++;
    initialized = true;
}

console.log(`foo => window.fooModuleInvokedHowManyTimes: \
${window.fooModuleInvokedHowManyTimes}, \
window.fooInitializedHowManyTimes: ${window.fooInitializedHowManyTimes}`);