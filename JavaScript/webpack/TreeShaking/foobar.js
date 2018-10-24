export var contact = function(firstName, lastName, department, email) {
    console.log("contact");
    let random = parseInt(Math.random() * 10, 10);
    let name = makeFullName(firstName, lastName);
    let message = `You have previously tried to contact \
${name} in the ${department} department at their email address \
${email} ${random} time(s). That's about all the times you can \
contact someone.`;

    console.log(message);
};

export var makeFullName = function(firstName, lastName) {
    console.log("makeFullName");
    if (typeof firstName === "string" && firstName.trim().length > 0) {
        if (typeof(lastName === "string" && lastName.trim().length > 0)) {
            return `${firstName} ${lastName}`;
        }
    }
};

export var sayHello = function(firstName, lastName) {
    console.log("sayHello");
    let name = makeFullName(firstName, lastName);
    console.log(`Hello, ${name}. How do you do?`);
};