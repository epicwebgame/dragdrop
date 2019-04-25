function printErrorToConsole(error) {
    let s = "";

    if (!error) {
        s += "No error info available.";
        return;
    }

    var props = [
        "statusText",
        "textStatus",
        "message",
        "error_message",
        "errorMessage",
        "response",
        "responseText", 
        "responseJSON",
        "stack"];

    if (typeof error === "object") {
        s += error;
        s += "; ";
        s += `error.constructor.name = ${error.constructor.name}, Properties: `;

        for (let prop in error) {
            if (typeof error[prop] !== "function") {
                s += `${prop} = ${error[prop]}, `;
            }
        }

        if (error.constructor.name.indexOf("Error") >= 0) {
            for (let prop in props) {
                if (prop in error) {
                    s += `${prop} = ${error[prop]}, `;
                }
            }
        }

        s = s.trim();
        if (s[s.length - 1] === ",") {
            s = s.substring(s, s.length - 1);
        }

    } else {
        s += `typeof error = ${typeof error}, `;
        s += `error.toString(): ${error.toString()}`;
    }

    let e = { details: s, epochTime: Date.now() };

    try {
        console.log(s);
    } catch (error) {
        console.log("Could not log error to console.");
    }
}

function createSessionCookie(key, value, httpOnly, path) {
    try {
        path = path || "/";

        let newCookie = `${key}=${value}`;

        if (httpOnly) {
            newCookie += "; HttpOnly";
        }
        if (path) {
            newCookie += `; Path=${path}`;
        }

        document.cookie = newCookie;
        return true;
    }
    catch (error) {
        printErrorToConsole(`Unable to create session cookie with key '${key}'.`);
        printErrorToConsole(error);
        return false;
    }
}

function createPersistentCookie(key, value, httpOnly, path, ageInSeconds) {
    try {
        path = path || "/";

        let secondsInTwoDays = 60 * 60 * 24 * 2;
        ageInSeconds = ageInSeconds || secondsInTwoDays;
        let expiry = new Date();
        expiry.setTime(Date.now() + (1000 * ageInSeconds));
        let expiryString = expiry.toUTCString();

        let newCookie = `${key}=${value};expires=${expiryString}`;

        if (httpOnly) {
            newCookie += "; HttpOnly";
        }
        if (path) {
            newCookie += `; Path=${path}`;
        }

        document.cookie = newCookie;
        return true;
    }
    catch (error) {
        printErrorToConsole(`Unable to create persistent cookie with key '${key}'.`);
        printErrorToConsole(error);
        return false;
    }
}

function getCookieValue(key) {
    var name = key + "=";

    var cookies = document.cookie.split(';');

    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];

        // Trim any leading space
        while (cookie.charAt(0) === ' ') {
            cookie = cookie.substring(1);
        }

        if (cookie.indexOf(name) === 0) {
            return cookie.substring(name.length, cookie.length);
        }
    }

    return;
}

function deleteCookie(key) {
    return createPersistentCookie(key, "", false, "/", -1);
}

function getAllCookies() {
    if (!document.cookie) return undefined;
    return document.cookie.split(";").map(function(value) {
        return value.trim();
    });
}