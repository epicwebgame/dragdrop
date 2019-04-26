import * as foo from "./foo.js";

import * as two from "./two.js";

"use strict";

console.log("foo.message invoked from module one: " + foo.message);
console.log("two.message invoked from module one: " + two.message);

console.log(`one => window.fooModuleInvokedHowManyTimes: \
${window.fooModuleInvokedHowManyTimes}, \
window.fooInitializedHowManyTimes: ${window.fooInitializedHowManyTimes}`);