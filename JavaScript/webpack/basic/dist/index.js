!function(t){var n={};function e(o){if(n[o])return n[o].exports;var r=n[o]={i:o,l:!1,exports:{}};return t[o].call(r.exports,r,r.exports,e),r.l=!0,r.exports}e.m=t,e.c=n,e.d=function(t,n,o){e.o(t,n)||Object.defineProperty(t,n,{enumerable:!0,get:o})},e.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},e.t=function(t,n){if(1&n&&(t=e(t)),8&n)return t;if(4&n&&"object"==typeof t&&t&&t.__esModule)return t;var o=Object.create(null);if(e.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:t}),2&n&&"string"!=typeof t)for(var r in t)e.d(o,r,function(n){return t[n]}.bind(null,r));return o},e.n=function(t){var n=t&&t.__esModule?function(){return t.default}:function(){return t};return e.d(n,"a",n),n},e.o=function(t,n){return Object.prototype.hasOwnProperty.call(t,n)},e.p="",e(e.s=3)}([function(t,n,e){"use strict";function o(t){var n=document.getElementById("content");!function(t){console.info(t)}(t),function(t,n){t.innerHTML=n}(n,t)}e.d(n,"a",function(){return o})},function(t,n,e){"use strict";e.r(n),e.d(n,"contactMe",function(){return r});var o=e(0);function r(t){console.log(`contactMe says: ${t}`)}Object(o.a)("Contact")},function(t,n,e){"use strict";e.r(n),e.d(n,"aboutMe",function(){return r});var o=e(0);function r(t){console.log(`aboutMe says: ${t}`)}Object(o.a)("About")},function(t,n,e){"use strict";e.r(n);var o=e(0),r=e(1),u=e(2);Object(o.a)("Index"),r.contactMe("Index"),u.aboutMe("Index")}]);