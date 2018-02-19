console.clear();

var Person = function(firstName, lastName) {
  
  // These are just local variables
  // In fact, we're just assigning to 
  // the existing local variables, the ones
  // that got created as arguments, 
  // their own values.
  // These are not visible from outside
  // this constructor function.
  firstName = firstName;
  lastName = lastName;
  
  // This, too, is a private function
  printName = function() {
    console.log(firstName + ' ' + lastName);
  }
  
  // This is a method
  this.printFullName = function() {
    printName();
  }
}

var person = new Person("Sathyaish", "Chakravarthy");
console.log(typeof person.printName);
console.log(typeof person.firstName);
console.log(typeof person.lastName);

person.printFullName();