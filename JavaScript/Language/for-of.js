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
for(var prop of array)
  console.log(prop);

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

for(var prop of newArray)
  console.log(prop);

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

