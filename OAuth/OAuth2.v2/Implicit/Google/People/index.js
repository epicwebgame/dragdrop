import googleOAuth2Config from "./google.config.js";
import * as urlHelper from "./urlHelper.js";

$(document).ready(async function() {

    try {
        var url = window.location.href;
        
        if (/access_token=/.test(url)) {
            await showWelcomeMessage(url, googleOAuth2Config);
        } else {
            showSignInLink();
        }
    }
    catch(error) {
        showError(error);
    }
});

function showSignInLink() {
    $("#signInLink")
    .attr("href", googleOAuth2Config.authorizationServerUrl)
    .show();
}

function showError(error) {
    $("#signInLink").hide();
    $("#welcomeMessage").hide();

    let message = "Something went wrong and that's all I know!";

    if (typeof error === "string" && error.trim() !== "") {
        message = error;
    } else if (typeof error === "object") {
        if (error.constructor.name.indexOf("Error") >= 0) {
            message = error.message;
        } else {
            message = error.toString();
        }
    }
    
    let errorMessage = $("#errorMessage");
    errorMessage
    .html(message)
    .show();
}

async function showWelcomeMessage(url, googleOAuth2Config) {

    if (!xsrfStateValid(url, googleOAuth2Config)) {
        console.log("The XSRF state parameter did not match. The request may have been tampered with.");
        throw new Error(`Your communication with the server may not be secure. \
        Are you browsing the Internet from a public place? \
        Like an airport or a cafe or a library or a hotel room or a friend's house? \
        It is recommended that you stop browsing this website from this place.`);
    }

    let accessToken = getAccessTokenFromUrl(url);
    console.log(`accessToken: ${accessToken}`);
    googleOAuth2Config.setAccessToken(accessToken);
    
    let user = await googleOAuth2Config.getUserAsync();

    $("#signInLink").hide();
    $("#errorMessage").hide();

    let welcomeMessage = $("#welcomeMessage");
    welcomeMessage
    .html(`Welcome, <span title = "${user.displayName}"><a href = "mailto:${user.email}">${user.givenName}</a></span>!`)
    .show();
}

function getAccessTokenFromUrl(url) {
    let accessToken = urlHelper.getValueOfQueryStringParameter(url, "access_token");
    
    if (!accessToken || accessToken === "") {
        console.log("No access token returned by the Google authorization server.");
        throw new Error("Sorry, something went wrong and it's not your fault. Please try again in a few hours.");
    }

    return accessToken;
}

function xsrfStateValid(url, googleOAuth2Config) {

    if (!googleOAuth2Config.state || googleOAuth2Config.state === "") {
        return true;
    }

    let state = getStateFromUrl(url);
    
    if (!state || state === "") {
        return false;
    }

    return state === googleOAuth2Config.state;
}

function getStateFromUrl(url) {
    let state = urlHelper.getValueOfQueryStringParameter(url, "state");

    return state;
}