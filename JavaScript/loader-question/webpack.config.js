var path = require("path");

module.exports = {
    mode: "development",
    entry: {
        // amd: path.resolve(__dirname, "amd.js"),
        es6modules: path.resolve(__dirname, "es6modules.js"),
        commonjs: path.resolve(__dirname, "commonjs.js")
    },
    output: {
        filename: "dist/[name].js",
        path: path.resolve(__dirname)
    }
}