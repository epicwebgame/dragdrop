import * as foo from "./foo.js";
import * as two from "./two.js";

console.log("I am one.js");
console.log(`foo.message read from one.js: ${foo.message}`);

console.log(`one.js => message from two.js: ${two.message}`);

console.log(`foo.js => \
window.howManyTimesFooInvoked: ${window.howManyTimesFooInvoked}`);
