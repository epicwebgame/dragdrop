console.log();

var parent = {
    a : 1
};

var child1 = Object.create(parent);

console.log(Object.getPrototypeOf(child1));
console.log(child1.a);

parent.a = 3;

console.log(child1.a);
console.log(Object.getPrototypeOf(child1).a);

var child2 = Object.create(parent);
console.log(child2.a);

child2.a = 4;
Object.getPrototypeOf(child2).a = 5;

console.log();
console.log(parent.a);
console.log(child1.a);
console.log(child2.a);

