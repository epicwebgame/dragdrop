var Friend = function(firstName, lastName)
{
	this.firstName = ko.observable(firstName);
	this.lastName = ko.observable(lastName);
	
	return this;
}
var model = 
{
	friend : new Friend('Sathyaish', 'Chakravarthy')
}

ko.applyBindings(model);