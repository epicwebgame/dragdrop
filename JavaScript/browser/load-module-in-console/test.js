import * as foo from "./foo.js";

(function() {
    foo.doo();

    for(let i = 1; i < 10000; i++) {
        let j = Math.pow(i, 7) - 24 + (1000 * 40/i);
    }
})();