console.clear();

try {
  foo();
  bar();
  gar();
} catch(error) {
  console.log(error);
  if (error instanceof ReferenceError) {
    console.log('The symbol was either not declared or was declared with a block-scope (let or const) but used before its declaration.');
  } else if (error instanceof TypeError) {
    console.log('The symbol was declared with a function expression but was called before its declaration. Function expressions are not hoisted. Only function statements are.');
  };
};

function foo() {
  console.log("foo called.");
};


/* Since function expressions are not 
hoisted, this is equivalent to
var bar;              // bar is declared, so no ReferenceError, but it has the value undefined
bar();                // call
bar = function() { }; // assignment to a function expression
*/
var bar = function() {
  console.log("bar called.");
};