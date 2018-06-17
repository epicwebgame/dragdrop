var Parent = function() {
    this.a = 1;
};

var parent = new Parent();

// undefined, no such property on object literals.
// This is perhaps more of a limitation of the API
// rather than a characteristic of object literals.
// Functions have it, not object literals. However, 
// every object does have a prototype.
console.log(parent.prototype);

// getPrototypeOf reads the [[Prototype]] or the __proto__
// property of the object, and every object has that.
// However, since the prototype has not been set for
// the Person class, this object created by using the 
// Person constructor function will have a prototype
// of {} (i.e. Object.prototype) because every object 
// has Object.prototype as its prototype by default, 
// unless it was explicitly created with a 
// var obj = Object.create(null);
console.log(Object.getPrototypeOf(parent));

// {}. For the same reason as in 
// the case of Object.getPrototypeOf(parent).
console.log(Parent.prototype);