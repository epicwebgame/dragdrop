import * as foo from "./foo.js";

export let message = "Message from two.js";

console.log(`foo.message read from two.js: ${foo.message}`);

console.log(`two.js => \
window.howManyTimesFooInvoked: ${window.howManyTimesFooInvoked}`);
