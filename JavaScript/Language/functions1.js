/*

See:

How to know an object's type?
http://stackoverflow.com/questions/40318217/how-to-know-an-objects-type
http://stackoverflow.com/q/40318217/303685

Are objects instantiated from these two constructor functions of the same type?
http://stackoverflow.com/questions/40318265/are-objects-instantiated-from-these-two-constructor-functions-of-the-same-type
http://stackoverflow.com/q/40318265/303685
*/

console.clear();

console.log("==================================");

var Person = function PersonClass(firstName, lastName)
{
  this.firstName = firstName;
  this.lastName = lastName;
};

var joeBloggs = new Person("Joe", "Bloggs");
var maryJane = Person("Mary", "Jane");

try
{
	console.log('typeof PersonClass: ' + typeof PersonClass);	
}
catch(e)
{
	console.log('typeof PersonClass: ' + e.message);	
}

console.log('typeof Person: ' + typeof Person);
console.log('Person: ' + Person);
console.log('Person.toString(): ' + Person.toString());
console.log('typeof joeBloggs: ' + typeof joeBloggs);
console.log('joeBloggs.toString(): ' + joeBloggs.toString());
console.log('typeof maryJane: ' + typeof maryJane);
console.log('joeBloggs instanceof Person: ' + (joeBloggs instanceof Person));
console.log('joeBloggs.prototype: ' + joeBloggs.prototype);
console.log('Person.prototype: ' + Person.prototype);

try
{
	console.log('PersonClass.prototype: ' + PersonClass.prototype);	
}
catch(e)
{
	console.log('PersonClass.prototype: ' + e.message);
}

try
{
	console.log('joeBlogs instanceof PersonClass: ' + (joeBloggs instanceof PersonClass));
}
catch(e)
{
	console.log('joeBlogs instanceof PersonClass: ' + e.message);
}

console.log("==================================")


var Employee = function(id, name)
{
  this.id = id;
  this.name = name;
  
  return this;
}

var sathyaish = new Employee(1, "Sathyaish Chakravarthy");

console.log('typeof Employee: ' + typeof Employee);
console.log('Employee: ' + Employee);
console.log('typeof sathyaish: ' + typeof sathyaish);
console.log('sathyaish: ' + sathyaish);
console.log('sathyaish instanceof Employee: ' + sathyaish instanceof Employee);

console.log("==================================");


var foo = function() { }
console.log('typeof foo: ' + typeof foo);

var bar = new function() { };
console.log(typeof bar);

console.log("==================================");