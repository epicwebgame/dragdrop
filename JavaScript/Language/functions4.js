console.clear();

function camelCaseName() {
  
  this.declaredProperty = "declared";
  
  console.log(this.constructor.name);
};

console.log(camelCaseName);
console.log(typeof camelCaseName);
camelCaseName.extraProperty = "foo";
camelCaseName.prototype.prototypedProperty = "from prototype";

camelCaseName();
console.log(camelCaseName.declaredProperty);
console.log(camelCaseName.extraProperty);
console.log(camelCaseName.prototypedProperty);

console.log('---------------------');

var ctor = new camelCaseName();
console.log(ctor);
console.log(typeof ctor);
console.log(ctor.declaredProperty);
console.log(ctor.extraProperty);
console.log(ctor.prototypedProperty);
ctor.prototypedProperty = "Overridden";
console.log(ctor.prototypedProperty);

console.log('---------------------');

var ctor2 = new camelCaseName();
console.log(ctor2.declaredProperty);
console.log(ctor2.extraProperty);
console.log(ctor2.prototypedProperty);