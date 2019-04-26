import * as foo from "./foo.js";

export let message = "Message from module two.";

console.log("foo.message invoked from module two: " + foo.message);

console.log(`two => window.fooModuleInvokedHowManyTimes: \
${window.fooModuleInvokedHowManyTimes}, \
window.fooInitializedHowManyTimes: ${window.fooInitializedHowManyTimes}`);