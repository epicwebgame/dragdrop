// Variants of the module pattern, just thinking on paper

// As shown by Travis Tidwell in "JavaScript Essentials (Revised)"
// https://www.youtube.com/watch?v=HbgRFH9BAy0

var alert = (function() {
	var messages = [];
	
	return {
		add : function(message) {
			messages.push(message);
		},
		
		log : function() {
			console.log(messages);
		}
	};
})();

console.clear();
alert.add("Hello");
alert.add("There");
alert.log();