this.model = 
{
	friend : 
	{
		firstName : 'Sathyaish',
		lastName : 'Chakravarthy'
	}
};
	
var ThisDocument = function()
{
	this.init = function()
	{
		wire(window, "load", wireElementHandlers);
	};
	
	function wire(element, eventName, listener)
	{
		var ie = document.all ? true : false;
		
		if (!element) throw new Error("Element " + element + " not found.");
		
		if (ie)
		{
			element.attachEvent("on" + eventName, listener);
		}
		else
		{
			element.addEventListener(eventName, listener, false);
		}
	};

	
	function wireElementHandlers()
	{
		var btnUpdateName = document.getElementById('btnUpdateName');
		wire(btnUpdateName, "click", changeName);
		
		ko.applyBindings(model);
	};
	
	function changeName(event)
	{
		var firstName = document.getElementById('txtNewFirstName').value;
		var lastName = document.getElementById('txtNewLastName').value;
		
		model.friend.firstName = firstName;
		model.friend.lastName = lastName;
	};
};

var thisDocument = new ThisDocument();
thisDocument.init();