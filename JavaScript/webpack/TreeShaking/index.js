// I am doing this example to explain tree-shaking
// to someone in response to their Quora question.
// See my answer here (permalink): http://qr.ae/TUGLWK
// Question Title: In ES, does ‘import *’ affect tree shaking and/or code splitting?
// Transient link: https://www.quora.com/In-ES-does-import-affect-tree-shaking-and-or-code-splitting/answer/Sathyaish-Chakravarthy

import * as foobar from "./foobar.js";

(function() {
    foobar.contact("Sathyaish", "Chakravarthy", "Software Development", "Sathyaish@gmail.com");
})();