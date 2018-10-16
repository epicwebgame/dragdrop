/**
 * 
 * @param {string} name 
 * @param {AssetGroup} parentAssetGroup 
 * @param {Number} oldValue 
 * @param {Number} newValue 
 * @param {Number} difference
 */
export default function AssetValueChangedEvent(name, parentAssetGroup, oldValue, newValue, difference) {

    if (typeof name !== "string" 
    || name.trim().length == 0) {
        throw new Error("Invalid argument 'name'.");
    }

    if (!(parentAssetGroup instanceof AssetGroup)) {
        throw new Error("Invalid argument 'parentAssetGroup'. Must be of type AssetGroup.");
    }

    if (!isNaN(oldValue)) {
        throw new Error("Invalid argument 'oldValue'. Must be numeric.");
    }

    if (!isNaN(newValue)) {
        throw new Error("Invalid argument 'newValue'. Must be numeric.");
    }

    if (!isNaN(difference)) {
        throw new Error("Invalid argument 'difference'. Must be numeric.");
    }

    this.name = name;
    this.parentAssetGroup = parentAssetGroup;
    this.oldValue = oldValue;
    this.newValue = newValue;
    this.difference = difference;
}