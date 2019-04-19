import googleOAuth2Config from "./google.config.js";

$(document).ready(function() {

    try {
        var url = window.location.href;
        
        if (/access_token=/.test(url)) {
            getAndDisplayUserDataAsync(url, googleOAuth2Config);
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

function showError(message) {
    $("#signInLink").hide();
    $("#welcomeMessage").hide();

    let s = message || "Something went wrong and that's all I know!";

    let errorMessage = $("#errorMessage");
    errorMessage
    .html(s)
    .show();
}

async function getAndDisplayUserDataAsync(url, googleOAuth2Config) {
    let accessToken = getAccessTokenFromUrl(url);
    console.log(`accessToken: ${accessToken}`);
    googleOAuth2Config.setAccessToken(accessToken);
    
    let user = await googleOAuth2Config.getUserAsync();

    showWelcomeMessage(user);
}

function getAccessTokenFromUrl(url) {
    let keyFragment = "access_token=";
    let startIndexOfKey;
    startIndexOfKey = url.indexOf(keyFragment);
    
    if (startIndexOfKey === -1) {
        console.log("No access token returned by the Google authorization server.");
        throw "Sorry, something went wrong and it's not your fault. Please try again in a few hours.";
    }

    let startIndex = startIndexOfKey + keyFragment.length;
    let endIndex = url.length - 1;

    for(let i = startIndex; i < url.length; i++) {
        if (url[i] === "&") {
            endIndex = i - 1;
            break;
        }
    }

    let accessToken = url.substr(startIndex, (endIndex - startIndex) + 1);

    return accessToken;
}

function showWelcomeMessage(user) {
    $("#signInLink").hide();
    $("#errorMessage").hide();

    let welcomeMessage = $("#welcomeMessage");
    welcomeMessage
    .html(`Welcome, <span title = "${user.displayName}"><a href = "mailto:${user.emails[0].value}">${user.name.givenName}</a></span>!`)
    .show();
}