import doo from "./util.js";
import * as contact from "./contact.js";
import * as about from "./about.js";
require("../content/site.css");

"use strict";

(function() {
    var message = "Index";
    doo(message);
    contact.contactMe(message);
    about.aboutMe(message);
})();