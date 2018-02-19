console.clear();


var o = {
  that : this,
  
  // Can an object refer to itself
  // while it is being declared?
  printThat() {
    console.log(o.that);
  },
  
  print : function(that) {
    console.log(that);
  },
  
  printThis : function() { 
    console.log(this);
  },
  
  whatsThis : function(something) {
    this.something = something;
    
    console.log(this);
    
    this.printThis = function() {
      console.log(this);
    };
  }
};


o.print(o.that);
o.printThat();
console.log(o.that);
o.printThis();

o.whatsThis("Hello");

/* Gives an error
o.whatsThis.printThis();
Exception: TypeError: o.whatsThis.printThis is not 
a function
*/

var wt = new o.whatsThis("Something");
wt.printThis();