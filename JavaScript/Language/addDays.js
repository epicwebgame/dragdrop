/* This is a JavaScript Scratchpad.
*
* Enter some JavaScript, then Right Click or choose from the Execute Menu:
* 1. Run to evaluate the selected text (Ctrl+R),
* 2. Inspect to bring up an Object Inspector on the result (Ctrl+I), or,
* 3. Display to insert the result in a comment after the selection. (Ctrl+L)
*/


addDays( 
	{ 
		"query" : 
		{
			"n" : 1
		}
	}, callback);

function addDays(ctx, cb)
{
	try
	{
		var baseDateString = ctx.query.b;
		var numberOfDaysString = ctx.query.n;
		
		var baseDate;
		
		if (baseDateString == null || baseDateString === "today" || baseDateString === "now")
		{
			baseDate = new Date();
		}
		else
		{
			baseDate = parseDate(baseDateString);
		}
		
		var numberOfDays = stringToInt(numberOfDaysString);
		
		if (numberOfDays === NaN)
		{
			cb(error, null);
			return;
		}
		
		var newDate = new Date();
		newDate.setDate(baseDate + numberOfDays);
		
		cb(null, newDate.toString());
	}
	catch(error)
	{
		cb(error, null);
	}
}

function stringToInt(str) {
  var num = parseInt(str);
  if (num == str)
	return num;
  return NaN;
}
	
function callback(error, data)
{
	print(error != null ? error : data);
}

function print(value)
{
	if (typeof console != "undefined")
	{
		console.log(value);
	}
	else if (typeof WScript != "undefined")
	{
		WScript.Echo(value);
	}
	else
	{
	}
}

function parseDate(input)
{
	var parts = input.split('-');
	return new Date(parts[0], parts[1], parts[2]);
}