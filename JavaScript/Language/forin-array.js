// See: http://stackoverflow.com/questions/40316800/why-do-i-get-a-function-is-undefined-even-though-i-added-the-function-to-the-c
// Permalink: http://stackoverflow.com/q/40316800/303685

// Also see: http://stackoverflow.com/questions/40316981/how-to-return-all-properties-and-their-values-of-an-object-including-iterable-on
// Permalink: http://stackoverflow.com/q/40316981/303685

console.clear();

var array = [ 'Apples', 'Oranges', , 'Pear', ];

array.first = function()
{
  var len = this.length;
  
  if (len === 0) throw new Error("Array empty");
  
  return this[0];
}

Array.prototype.last = function()
{
  var len = this.length;
  if (len === 0) throw new Error("Empty array");
  return this[len - 1];
}


console.log("========================")
for(prop in array)
  console.log(prop + " = " + array[prop].toString());

console.log("========================")

try
  {
    var first = array.first();
    console.log("first = " + first.toString());
  }
catch(e)
  {
    console.log(e.message);
  }

try
  {
    var last = array.last();
    console.log("last  = " + last.toString());
  }
catch(e)
  {
    console.log(e.message);
  }


console.log("========================")
var newArray = [ 'a', 'b', 'c' ];

for(prop in newArray)
  console.log(prop + " = " + newArray[prop].toString());

console.log("========================")

try
  {
    var first = newArray.first();
    console.log("first = " + first.toString());
  }
catch(e)
  {
    console.log(e.message);
  }

try
  {
    var last = newArray.last();
    console.log("last  = " + last.toString());
  }
catch(e)
  {
    console.log(e.message);
  }

