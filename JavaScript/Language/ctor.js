
// See http://stackoverflow.com/questions/40277418/declaring-a-property-inside-a-constructor-function
// Permalink: http://stackoverflow.com/q/40277418/303685

var Person = function(firstName, lastName)
{
  
  this.firstName = firstName;
  this.lastName = lastName;
  
  this.getName = function() {
    return this.firstName + ' ' + this.lastName;
  };
};

var person = new Person('Joe', 'Bloggs');

console.log(person.getName());