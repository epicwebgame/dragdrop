function Foo() {
	console.log(this.constructor.name);
	return this;
}

function Bar() {
	console.log(this.constructor.name);
};

function Gar() {
	
	console.log(this.constructor.name);
	
	return {
		name: "Gar"
	};
};

console.clear();
var foo = new Foo();
var bar = new Bar();
var gar = new Gar();

console.log(foo instanceof Foo);
console.log(bar instanceof Bar);

// false, because the ctor Gar() does not return itself
// but returns a different object
console.log(gar instanceof Gar);