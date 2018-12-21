var comparer = require("./Comparer");
var fx = require("./Fx");

// test compare strings
// CASE-INSENSITIVE
// Async < Ball
// Ball < Zebra
// Bharat > Ball
// Sathyaish > Chakravarthy
// 123 < 423
// a123 < a456
// abc == Abc
// ABC == abc
// D == d

// CASE-INSENSITIVE
// Async < Ball
function test_Async_LessThan_Ball() {
    var result = comparer.compareStrings("Async", "Ball");
    fx.assert(result < 0);
}

// CASE-INSENSITIVE
// Ball < Zebra
function test_Ball_LessThan_Zebra() {
    var result = comparer.compareStrings("Ball", "Zebra");
    fx.assert(result < 0);
}

// CASE-INSENSITIVE
// Bharat > Ball
function test_Bharat_GreaterThan_Ball() {
    var result = comparer.compareStrings("Bharat", "Ball");
    fx.assert(result > 0);
}

// CASE-INSENSITIVE
// Sathyaish > Chakravarthy
function test_Sathyaish_GreaterThan_Chakravarthy() {
    var result = comparer.compareStrings("Sathyaish", "Chakravarthy");
    fx.assert(result > 0);
}

// CASE-INSENSITIVE
// 123 < 423
function test_123_LessThan_423() {
    var result = comparer.compareStrings("123", "423");
    fx.assert(result < 0);
}

// CASE-INSENSITIVE
// a123 < a456
function test_a123_LessThan_a456() {
    var result = comparer.compareStrings("a123", "a456");
    fx.assert(result < 0);
}

// CASE-INSENSITIVE
// abc == Abc
function test_abc_EqualTo_Abc() {
    var result = comparer.compareStrings("abc", "Abc");
    fx.assert(result === 0);
}

// CASE-INSENSITIVE
// ABC == abc
function test_ABC_EqualTo_abc() {
    var result = comparer.compareStrings("ABC", "abc");
    fx.assert(result === 0);
}

// CASE-INSENSITIVE
// D == d
function test_D_EqualTo_d() {
    var result = comparer.compareStrings("D", "d");
    fx.assert(result === 0);
}


// test compare strings
// CASE-INSENSITIVE
// Async < Ball
// Ball < Zebra
// Bharat > Ball
// Sathyaish > Chakravarthy
// 123 < 423
// a123 < a456
// abc == Abc
// ABC == abc
// D == d
test_Async_LessThan_Ball();
test_Ball_LessThan_Zebra();
test_Bharat_GreaterThan_Ball();
test_Sathyaish_GreaterThan_Chakravarthy();
test_123_LessThan_423();
test_a123_LessThan_a456();
test_abc_EqualTo_Abc();
test_ABC_EqualTo_abc();
test_D_EqualTo_d();

fx.printStats();