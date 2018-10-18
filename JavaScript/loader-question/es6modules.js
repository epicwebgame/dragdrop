// How does this work when jQuery does not export any symbol
// It just returns the jQuery object using the AMD pattern.
// Does the ES 6 specification mandate that module loaders
// look for AMD as well as Common JS (module.exports) modules?

// import $ from "./jQuery"

import $ from "./jquery-3.3.1.js";

$("h1").html("Hello from ES 6 module");