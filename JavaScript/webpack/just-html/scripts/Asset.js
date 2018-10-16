import AssetValueChangedEvent from "./AssetValueChangedEvent";
import AssetGroup from "./AssetGroup";

/**
 * 
 * @param {string} name 
 * @param {Number} value 
 * @param {AssetGroup} parent 
 */
export default function Asset(name, value, parent) {

    this.validateInput(name, value, parent);
    this.name = name;
    this.value = value;
    this.parent = parent;
    this.valueChangedListeners = [];

    function onValueChanged(oldValue, newValue) {
        var difference = newValue - oldValue;
        this.fireValueChangedEventListeners(this.name, this.parent, oldValue, newValue, difference);
    };

    function fireValueChangedEventListeners(name, parent, oldValue, newValue, difference) {
        var len = this.valueChangedListeners.length;
        for(let i = 0; i < len; i++) {
            this.valueChangedListeners[i].call(this, 
                new AssetValueChangedEvent(name, parent, oldValue, newValue, difference));
        }
    };

    function validateInput(name, value, parent) {
        if (!isValidName(name)) {
            throw new Error("Invalid argument 'name'. Must be non-empty string.");
        }
    
        if (!isValidValue(value)) {
            throw new Error("Invalid argument 'value'. Must be a numeric.");
        }
    
        if (!isValidParent(parent)) {
            throw new Error("Invalid argument 'parent'. Must be an instance of AssetGroup.");
        }
    };

    function isValidName() {
        if (typeof name !== "string") {
            return false;
        }

        if (name.trim().length === 0) {
            return false;
        }

        return true;
    };

    function isValidValue(value) {
        if (typeof value === "number") {
            return true;
        }

        return !isNaN(value);
    };

    function isValidParent(parent) {
        return (parent !== undefined 
            && parent instanceof AssetGroup);
    };

    Object.defineProperty(this, "name", {
        get: function() {
            return this.name;
        },
        set: function(name) {
            if (!isValidName(name)) {
                throw new Error("Invalid argument 'name'. Must be non-empty string.");
            }
            this.name = name;
        }
    });

    Object.defineProperty(this, "value", {
        get: function() {
            return this.value;
        },
        set: function(value) {
            if (!isValidValue(value)) {
                throw new Error("Invalid argument 'value'. Must be a numeric.");
            }
            var oldValue = this.value;
            this.value = value;
            onValueChanged(oldValue, this.value);
        }
    });

    Object.defineProperty(this, "parent", {
        get: function() {
            return this.parent;
        },
        set: function(parent) {
            if (!isValidParent(parent)) {
                throw new Error("Invalid argument 'parent'. Must be an instance of AssetGroup.");
            }
            this.parent = parent;
        }
    });
};


Asset.prototype.addEventListener = function(eventName, listener) {
    if (eventName !== "valueChanged") {
        return false;
    }

    if (!(listener instanceof Function)) {
        throw new Error("Invalid value provided for Asset.valueChanged event listener. Function expected.");
    }

    this.valueChangedListeners.push(listener);
};

Asset.prototype.removeEventListener = function(eventName, listener) {
    if (eventName !== "valueChanged") {
        return false;
    }

    for(let i = 0; i < this.valueChangedListeners.length; i++) {
        if (this.valueChangedListeners[i] === listener) {
            this.valueChangedListeners.splice(i, 1);
            return;
        }
    }
};