document.addEventListener("DOMContentLoaded", setup);

function setup() {
    let gmtNowElement = document.getElementById("gmtNow");
    gmtNowElement.innerHTML = (new Date()).toUTCString();

    window.setInterval(updateCurrentTimeAndAuthCookieExpiryStatus, 1000);

    document.getElementById("makeARequestToServer").addEventListener("click", makeARequestToTheServerClickEventHandler, false);
    document.getElementById("tellServerToDeleteCookie").addEventListener("click", tellServerToDeleteCookieClickEventHandler, false);
}

function makeARequestToTheServerClickEventHandler() {
    let cookieValueElement = document.getElementById("cookieValue");
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/Home/Whatever", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onload = function (event) {
        displayAuthCookieValue(cookieValueElement);
    };
    xhr.send();
}

function tellServerToDeleteCookieClickEventHandler() {
    let cookieValueElement = document.getElementById("cookieValue");
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/Home/DeleteAuthCookie", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onload = function (event) {
        displayAuthCookieValue(cookieValueElement);
    };
    xhr.send();
}

function updateCurrentTimeAndAuthCookieExpiryStatus() {
    displayCurrentTimeInGMT();
    displayAuthCookieValue();
}

function displayCurrentTimeInGMT() {
    let gmtNowElement = document.getElementById("gmtNow");
    if (gmtNowElement) {
        let now = new Date();
        gmtNowElement.innerHTML = now.toUTCString();
    }
}

function displayAuthCookieValue() {
    let authCookieValue = getCookieValue("AUTH");
    let cookieValueElement = document.getElementById("cookieValue");
    let expiresElement = document.getElementById("expires");

    if (authCookieValue) {
        let expiryEpochTime = authCookieValue * 1000;
        let expiryDateObject = new Date(expiryEpochTime);
        cookieValueElement.innerText = expiryDateObject.toUTCString();

        if (expiryEpochTime <= Date.now()) {
            cookieValueElement.addClass("expired").removeClass("alive");
            expiresElement.style.display = "none";
        } else {
            cookieValueElement.addClass("alive").removeClass("expired");
            expiresElement.style.display = "";
        }
    } else {
        expiresElement.style.display = "none";
        cookieValueElement.removeClass("alive").addClass("expired");
        cookieValueElement.innerText = "No such cookie exists";
    }
}

function getCookie(name) {
    let cookiesString = document.cookie;

    if (!cookiesString) return;

    let allCookies = cookiesString.split(";");
    let numCookies = allCookies.length;
    if (numCookies > 0) {
        for (let i = 0; i < numCookies; i++) {
            let cookie = allCookies[i];
            while (cookie.charAt(0) === ' ') {
                cookie = cookie.substring(1);
            }

            if (cookie.indexOf(name) === 0) {
                return cookie;
            }
        }
    }
}

function getCookieValue(key) {
    let cookie = getCookie(key);
    if (cookie) {
        return cookie.substring(key.length + 1, cookie.length);
    }
}

HTMLElement.prototype.hasClass = function hasClass(className) {
    return (` ${this.className} `.replace(/[\n\t\r]/g, " ").indexOf(className) > -1);
};

HTMLElement.prototype.addClass = function addClass(className) {
    if (!this.hasClass(className)) {
        this.className += ` ${className} `;
    }

    return this;
};

HTMLElement.prototype.removeClass = function removeClass(className) {
    if (this.classList.contains(className)) {
        this.classList.remove(className);
    }

    return this;
};