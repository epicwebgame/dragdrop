function forIn(o, name) {
    // for...in
    // This method traverses all enumerable properties of 
    // an object and its prototype chain
    if (!name) throw new Error('Argument \'name\' required.');

    if (o) {
        var count = 0;
        console.log(`Printing properties of ${name} using for...in (enumerable properties only, deep):`)

        for(var prop in o) {
            console.log(`\t${++count}. ${prop}`);
        }
    
        console.log('\n');
    }
}

function objectKeys(o, name) {
    // Object.keys(o)
    // This method returns an array with all the own 
    // (not in the prototype chain) enumerable properties' 
    // names ("keys") of an object o.

    if (!name) throw new Error('Argument \'name\' required.');

    if (o) {
        console.log(`Printing Object.keys of ${name} (enumerable only, shallow):`)

        var count = 0;

        Object.keys(o).forEach(function(key) {
            console.log(`\t${++count}. ${key}`);
        });
    
        console.log('\n');
    }
}

function printOwnProperties(o, name) {
    // Object.getOwnPropertyNames(o)
    // This method returns an array containing all own 
    // properties' names (enumerable or not) of an object o.

    if (!name) throw new Error('Argument \'name\' required.');

    if (o) {
        console.log(`Printing Object.getOwnPropertyNames of ${name} (enumerable and non-enumerable, shallow):`)

        var count = 0;

        Object.getOwnPropertyNames(o).forEach(function(key) {
            console.log(`\t${++count}. ${key}`);
        });
    
        console.log('\n');
    }
};

function printOwnAndInheritedProperties(o, name) {

    // for...in already gets properties of an object including
    // those down the prototype chain. However, it gets only
    // the enumerable ones. This method is useful if you want
    // to get both, the enumerable and the non-enumerable ones
    // down the prototype chain.

    if (!name) throw new Error('Argument \'name\' required.');

    var count = 0;

    if (!o) return;

    console.log(`Printing properties of ${name} (enumerable and non-enumerable, deep):`)

    while(o) {
        Object.getOwnPropertyNames(o).forEach(function(key) {
            console.log(`\t${++count}. ${key}`);
        });

        o = Object.getPrototypeOf(o);
    };

    console.log('\n');
};

function printPropertyValueTree(o, name) {

    if (!name) throw new Error('Argument \'name\' required.');

    var count = 0;

    if (!o) return;

    console.log(`Printing properties and their values of ${name} (enumerable and non-enumerable, deep):`)

    while(o) {
        Object.getOwnPropertyNames(o).forEach(function(key) {
            console.log(`\t${++count}. ${key}: ${o[key]}`);
        });

        o = Object.getPrototypeOf(o);
    };

    console.log('\n');
};

function printPrototype(o, name) {

    if (!name) throw new Error('Argument \'name\' required.');

    if (!o) return;

    console.log('\n');
    console.log(`Prototype information for ${name}:`);
    console.log(`Object.getPrototypeOf(${name}) (i.e. the internal [[Prototype]] property: ${Object.getPrototypeOf(o)}`);
    console.log(`${name}.__proto__: ${o.__proto__}`);
    console.log(`${name}.prototype: ${o.prototype}`);
    if (o.prototype) { 
        console.log(`${name}.prototype.__proto__: ${o.prototype.__proto__}`);
        console.log(`${name}.prototype.constructor: ${o.prototype.constructor}`);
    }
    console.log(`${name}.constructor: ${o.constructor}`);
    console.log('\n');
}

module.exports = {
    forIn: forIn,

    objectKeys: objectKeys,

    printOwnProperties: printOwnProperties,

    printOwnAndInheritedProperties: printOwnAndInheritedProperties, 

    printPropertyValueTree: printPropertyValueTree, 

    printPrototype: printPrototype
};