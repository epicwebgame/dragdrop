// Common JS / webpack
// How does this work when jQuery does not have a module.exports?
// Is it because webpack's module loader also looks for AMD style modules?
// require("jquery");

var $ = require("./jquery");

$("h1").html("Hello from CommonJS implementation in Webpack");