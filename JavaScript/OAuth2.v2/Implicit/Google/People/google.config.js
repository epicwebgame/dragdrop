import { OAuth2Config } from "./config.js";

export default new OAuth2Config(
    "194202915345-ed5lfkautflgkkqqdjta9r24d9afmdsc.apps.googleusercontent.com", 
    "https://localhost/Implicit/Google/People/", 
    "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile", 
    "abcd",
    "token", 
    "https://accounts.google.com/o/oauth2/v2/auth", 
    "https://people.googleapis.com/v1/people/me?personFields=names%2CemailAddresses", 
    "emailAddresses/value,names(displayName,familyName,givenName)");