function Foo() {
  console.log(this);
  
  this.bar = function () {
    console.log(this);
    
    this.gar = function () {
      console.log(this);
    };
  }
};

console.clear();

// Foo();
var foo = new Foo();
foo.bar();

console.clear();

var foo  = new Foo();
var bar = new foo.bar();
var gar = new bar.gar();

console.clear();
bar.gar();