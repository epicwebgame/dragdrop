$(document).ready(function() {
    $("button").click(addFingerPrintToList);
    addFingerPrintToList();
});

function addFingerPrintToList() {
    var options = {
        excludes: {
            // Unreliable on Windows, see https://github.com/Valve/fingerprintjs2/issues/375
            'enumerateDevices': true,
            // devicePixelRatio depends on browser zoom, and it's impossible to detect browser zoom
            'pixelRatio': true,
            // DNT depends on incognito mode for some browsers (Chrome) and it's impossible to detect incognito mode
            'doNotTrack': true,
            // uses js fonts already
            'fontsFlash': true, 
            
            'userAgent': true
          },
    };

    var d1 = new Date();

    Fingerprint2.get(options, function(components) {
        var values = components.map(kvp => kvp.value).join();
        var fingerPrint = Fingerprint2.x64hash128(values, 31);

        var d2 = new Date();
        var t = d2 - d1;

        console.log(components);
        var li = `<li>${fingerPrint} (${t} ms)</li>`;
        $("ol").append(li);
    });
}