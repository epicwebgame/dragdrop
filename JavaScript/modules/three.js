import * as foo from "./foo.js";
import * as two from "./two.js";

console.log("I am three.js");
console.log(`foo.message read from three.js: ${foo.message}`);

console.log(`one.js => message from two.js: ${two.message}`);

console.log(`three.js => \
window.howManyTimesFooInvoked: ${window.howManyTimesFooInvoked}`);
