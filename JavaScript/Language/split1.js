// See my Stack Overflow question:
// http://stackoverflow.com/questions/41459284/how-may-i-split-my-javascript-classes-across-multiple-files-and-yet-have-them-be/41459343?noredirect=1#comment70125072_41459343
// Permalink: http://stackoverflow.com/q/41459284/303685

var Automobiles = Automobiles || {};

Automobiles.wheel = function() {
	document.writeln(this.constructor);
	console.log(this.constructor);
};