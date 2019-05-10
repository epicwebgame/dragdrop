/* I discovered this on my website for the privacy bar and
thought I should let everyone know.

So, I made a video about this titled, "Beware: the Storage API functions always return truthy values," available 
on YouTube at https://youtu.be/gcW2HwRL9xo

*/

$(document).ready(function() {

    let importantMessageShown = localStorage.getItem("importantMessageShown");

    if (!importantMessageShown) {
        showImportantMessage();
        localStorage.setItem("importantMessageShown", "true");
    }

    $("#clearImportantMessageFlag").click(function() {
        localStorage.setItem("importantMessageShown", "false");
    });
    
    $("#clearImportantMessageFlagCorrectly").click(function() {
        localStorage.removeItem("importantMessageShown");
    });
});


function showImportantMessage() {
    $(".importantMessage").slideDown(2000);
}