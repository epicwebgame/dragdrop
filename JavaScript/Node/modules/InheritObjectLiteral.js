var reflection = require('./reflection');

var group = {

    name: 'Not set',

    total: function() {
    }
};

Object.defineProperty(group, 
    'nonEnumerablePropertyOfGroup', {
       value: 0,
       enumerable: false 
    });

var assets = {}; // Object.create(group);
assets.prototype = group;
assets.foo = 0;
Object.defineProperty(assets, 
    'nonEnumerablePropertyOfAssets', {
        value: 0,
        enumerable: false
    });

console.log('\nPROGRAM OUTPUT:\n');

reflection.forIn(assets, 'assets');
reflection.objectKeys(assets, 'assets');
reflection.printOwnProperties(assets, 'assets');
reflection.printOwnAndInheritedProperties(assets, 'assets');
reflection.printPropertyValueTree(assets, 'assets');
reflection.printPrototype(assets, 'assets');

console.log('-------------------------------------\n');

reflection.forIn(group, 'group');
reflection.objectKeys(group, 'group');
reflection.printOwnProperties(group, 'group');
reflection.printOwnAndInheritedProperties(group, 'group');
reflection.printPropertyValueTree(group, 'group');
reflection.printPrototype(group, 'group');

console.log('\nEND OF PROGRAM OUTPUT\n');