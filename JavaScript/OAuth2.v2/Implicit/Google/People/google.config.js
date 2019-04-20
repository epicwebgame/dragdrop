import { OAuth2Config } from "./config.js";

export default new OAuth2Config(
    "", 
    "https://localhost", 
    "https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email", 
    "abcd",
    "token", 
    "https://accounts.google.com/o/oauth2/v2/auth", 
    "https://www.googleapis.com/plus/v1/people/me?", 
    "emails/value, displayName, name(givenName, familyName)");