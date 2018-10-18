import doo from "./util.js";
import css from "../content/site.css";

export function aboutMe(message) {
    console.log(`aboutMe says: ${message}`);
}

var message = "About";

(function() {
    doo(message);
})();