import { User } from "./user.js";

"use strict";

export function OAuth2Config(clientId, 
    redirectUri, 
    scope, 
    state, 
    responseType, 
    authorizationServerUrl, 
    resourceServerUrl, 
    fields, 
    accessToken) {

        this.clientId = clientId;
        this.redirectUri = redirectUri;
        this.scope = scope;
        this.state = state;
        this.responseType = responseType;
        this.fields = fields;
        this.accessToken = accessToken;

        let authroizationUrlParameters = {
            client_id: this.clientId,
            redirect_uri: this.redirectUri,
            scope: this.scope,
            state: this.state,
            response_type: this.responseType
        };

        this.authorizationServerUrl = this.makeUrlWithQueryString(authorizationServerUrl, authroizationUrlParameters);
        this.resourceServerUrl = resourceServerUrl;
};

OAuth2Config.prototype.setAccessToken = function(accessToken) {
    if (!accessToken || accessToken.length === 0) {
        throw new Error("Null or empty access token.");
    }

    this.accessToken = accessToken;
    this.resourceServerUrl = this.makeUrlWithQueryString(this.resourceServerUrl, 
        { 
            access_token: accessToken, 
            fields: this.fields 
        });
};

OAuth2Config.prototype.makeUrlWithQueryString = function(baseUrl, parameters) {

    if (!baseUrl || baseUrl.length === 0) {
        throw new Error("Null argument: baseUrl");
    }

    let s = baseUrl.trim();

    if (!parameters || parameters.length === 0) {
        return s;
    }

    if (s.indexOf("?") === -1)  {
        if (s[s.length - 1] !== "?") {
            s += "?";
        }
    } else {
        if (s[s.length - 1] !== "&") {
            s += "&";
        }
    }
    
    if (typeof parameters === "string") {
        s += parameters;
    } else if (typeof parameters === "object") {
        for(let key in parameters) {
            s += `${key}=${parameters[key]}&`;
        }
    } else {
        throw new Error("Argument 'parameters' must be a string or an object.");
    }

    if (s[s.length - 1] === "&") {
        s = s.substr(0, s.length - 1);
    }

    return s;
};

OAuth2Config.prototype.getUserAsync = async function() {
    try {
        let data = await $.ajax(this.resourceServerUrl);
        if (!data) {
            throw new Error("The server did not return any user data.");
        }
        return new User(
            data.names[0].givenName, 
            data.names[0].familyName, 
            data.names[0].displayName, 
            data.emailAddresses[0].value);
    }
    catch(error) {
        let userFacingMessage = "There was an error getting user information from Google.";
        console.log(`${"There was an error getting user information from Google."} Error: ${error}`);
        throw new Error(userFacingMessage);
    }
};