console.clear();

var friend = 
    {
      firstName : 'Sathyaish',
      lastName: 'Chakravarthy',
      occupation: 'Software Developer',
      
      print: function()
      {
        console.log(this.firstName + " " + this.lastName + " === " + this.occupation);
      }
    };

var Person = function(firstName, lastName, occupation)
{
  this.firstName = firstName;
  this.lastName = lastName;
  this.occupation = occupation;
  
  this.getName = function()
  {
    return this.firstName + " " + this.lastName;
  }
}

Person.prototype.toString = function()
{
  return this.getName() + " --> " + this.occupation;
};

var person = new Person("Sathyaish", "Chakravarthy", "Software Architect");

for(prop in friend)
  console.log(prop);

console.log("==================");

for(prop in person)
  console.log(prop);