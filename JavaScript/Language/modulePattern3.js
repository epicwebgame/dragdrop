// Variants of the module pattern, just thinking on paper

var Page1 = function() {	
	return {
		url : window.location.href
	};
};

function Page2() {
	
	return {
		url : window.location.href
	};
}

var page1 = new Page1();
var page2 = Page2();

console.clear();
// should be false
console.log(page1 instanceof Page1);
console.log(page1.url);

// should also be false
console.log(page2 instanceof Page2);
console.log(page2.url);

console.log(typeof page1);
console.log(typeof page2);

console.log(page1.constructor.name);
console.log(page2.constructor.name);

console.log(Page1.constructor.name);
console.log(Page2.constructor.name);

console.log(Page1.prototype.constructor.name);
console.log(Page2.prototype.constructor.name);