import * as foo from "./foo.js";

console.log("I am four.js");
console.log(`foo.message read from four.js: ${foo.message}`);

console.log(`four.js => \
window.howManyTimesFooInvoked: ${window.howManyTimesFooInvoked}`);
