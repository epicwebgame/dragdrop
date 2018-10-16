import doo from "./util.js";

export function aboutMe(message) {
    console.log(`aboutMe says: ${message}`);
}

var message = "About";

(function() {
    doo(message);
})();