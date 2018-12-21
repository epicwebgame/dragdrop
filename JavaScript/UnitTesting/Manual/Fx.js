var numTestsRun = 0;
var numPassed = 0;
var numFailed = 0;

module.exports.assert = function assert(condition, message, expectedValue, actualValue) {
    var testName = assert.caller.name || "";
    if (testName.startsWith("test_")) {
        numTestsRun++;
    }

    if (!condition) {
        numFailed++;
        message = message || "";
        if (!!expectedValue && !!actualValue) {
            console.log(`Test #${numTestsRun} ${testName} failed. Expected Value: ${expectedValue}. Actual Value: ${actualValue}. ${message}`);
        } else {
            console.log(`Test #${numTestsRun} ${testName} failed: ${message}`);
        }
    } else {
        numPassed++;
        console.log(`Test #${numTestsRun} ${testName} passed.`);
    }
}

module.exports.printStats = function printStats() {
    console.log(`\nTests run: ${numTestsRun}`);
    console.log(`Passed: ${numPassed}`);
    console.log(`Failed: ${numFailed}`);
}

module.exports.getThisFunctionName = function getThisFunctionName() {
    return getThisFunctionName.caller.name;
}