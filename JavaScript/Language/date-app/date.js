var fourthJuly = "4/7/2018";
var usFormatDate = "2/30/2018";
var indianFormatDate = "30/2/2018";
var invalidDate1 = "32/1/2018";
var invalidDate2 = "1/32/2018";

var dates = [
  fourthJuly, 
  usFormatDate,
  indianFormatDate,
  invalidDate1,
  invalidDate2
];

function printDate(s) {
  
  try {
    var d = new Date(Date.parse(s));
    console.log("Input string: " + s);
    console.log("Date String: " + d.toDateString());
    console.log("ISO String: " + d.toISOString());
    console.log("GMT String: " + d.toGMTString());
    console.log("JSON: " + d.toJSON());
    console.log("Locale Date String: " + d.toLocaleDateString());
    console.log("Locale String: " + d.toLocaleString());
    console.log("Locale Time String: " + d.toLocaleTimeString());
    console.log("Source: " + d.toSource());
    console.log("String: " + d.toString());
    
    // Not supported by most browsers at this tiime, 
    // i.e. 28t December 2018
    console.log("Locale Format: " + d.toLocaleFormat());
    
  } catch(error) {
    console.log(error);
  } finally {
    console.log("\n"); 
  }
}

function printDates(dates) {
  console.log("\n");
  if (dates && dates.length > 0) {
    dates.forEach(date => printDate(date));
  }
}

console.clear();
printDates(dates);