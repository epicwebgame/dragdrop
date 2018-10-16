const path = require("path");

// How to use source maps, css, sass
module.exports = {
    mode: "production",
    entry: {
        index: path.resolve(__dirname, "scripts/index.js"),
        contact: path.resolve(__dirname, "scripts/contact.js"),
        about: path.resolve(__dirname, "scripts/about.js")
    }, 
    output: {
        filename: "[name].js",
        path: path.resolve(__dirname, "dist")
    }
};