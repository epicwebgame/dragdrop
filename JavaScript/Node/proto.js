var foo = { fooProp: 'foo' };

var Bar = function(s) {
    this.s = s;
};

var bar = new Bar();

var biz = Object.create(foo);

console.log('\n');

// I am not sure what this is for
console.log('obj.prototype:');
console.log(foo.prototype);
console.log(Bar.prototype);
console.log(bar.prototype);
console.log(biz.prototype);

console.log('\n');

// What is the prototype of this object
// Reveals the internal [[Prototype]] property
// of the object.
console.log('Object.getPrototypeOf(obj):');
console.log(Object.getPrototypeOf(foo));
console.log(Object.getPrototypeOf(Bar));
console.log(Object.getPrototypeOf(bar));
console.log(Object.getPrototypeOf(biz));

console.log('\n');

// Deprecated and must use Object.getPrototypeOf(o)
// instead. Returns "what object was initially the
// prototype of this one when it was first created."
// Must test this separately.
console.log('obj.__proto__:');
console.log(foo.__proto__);
console.log(Bar.__proto__);
console.log(bar.__proto__);
console.log(biz.__proto__);

console.log('\n');

console.log('obj.constructor:');
console.log(foo.constructor);
console.log(Bar.constructor);
console.log(bar.constructor);
console.log(biz.constructor);

console.log('\n');

console.log('typeof obj:');
console.log(typeof foo);
console.log(typeof Bar);
console.log(typeof bar);
console.log(typeof biz);

console.log('\n');