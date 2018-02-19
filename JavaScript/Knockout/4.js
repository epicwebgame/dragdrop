var Friend = function(firstName, lastName)
{
	this.firstName = ko.observable(firstName);
	this.lastName = ko.observable(lastName);
	
	this.fullName = ko.computed(function()
	{
		return this.firstName() + " " + this.lastName();
	}, this);
	
	return this;
}
var model = 
{
	friend : new Friend('Sathyaish', 'Chakravarthy')
}

ko.applyBindings(model);