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
for(var i = 0; i < array.length; i++)
  console.log(array[i]);

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

for(var i = 0; i < newArray.length; i++)
  console.log(newArray[i]);

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