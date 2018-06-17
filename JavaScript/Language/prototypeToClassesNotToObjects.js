
// Classes, and not objects, have a prototype property
// So, you add to the prototype object of the class name
// and not to an obj.prototype.

console.clear();

function Foo() {
  
};

Foo.prototype.inherited = "Property inherited from prototype";

console.log(Foo.inherited);
console.log((new Foo()).inherited);


console.log('-------------------');

var obj = { };
obj.prototype.inherited = "Property inherited from prototype";
console.log(obj.inherited);