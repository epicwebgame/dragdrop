I am making this example to answer this question for myself.

Do AJAX requests made to a domain include the HttpOnly cookies they received from that domain earlier?

For example, if a user clicks "Login" and that makes an AJAX request to the server, and upon successful login, the server returns an authentication cookie, does every subsequent AJAX request to that same domain automatically include that authentication cookie or does it need to be set explicitly in the call to the ajax method?