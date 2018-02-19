/*

See:

How to know an object's type?
http://stackoverflow.com/questions/40318217/how-to-know-an-objects-type
http://stackoverflow.com/q/40318217/303685

Are objects instantiated from these two constructor functions of the same type?
http://stackoverflow.com/questions/40318265/are-objects-instantiated-from-these-two-constructor-functions-of-the-same-type
http://stackoverflow.com/q/40318265/303685
*/


var Person = function(name)
{
	this.name = name;
};

var joe = new Person("Joe Bloggs");

console.log(typeof joe);
console.log(joe.constructor);
console.log(joe && joe.constructor);
console.log(joe && joe.constructor && joe.constructor.name);

==========================================

var Person = function(name)
{
	this.name = name;
	
	return this;
};

var joe = new Person("Joe Bloggs");

console.log(typeof joe);
console.log(joe.constructor);
console.log(joe && joe.constructor);
console.log(joe && joe.constructor && joe.constructor.name);
