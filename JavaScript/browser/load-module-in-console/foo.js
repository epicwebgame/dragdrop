export function doo() {
    console.log("doing...");
}

export function dont(n) {
    try {
        if (typeof n !== "number") {
            throw new Error("dont expects a Number but you passed in a " + n.constructor.name);
        }
        let i = n - 1 / 46;
        let j = n * i + 1;
        n = i + Math.pow(j, 2);
        n -= 22;

        return n;
    }
    catch(error) {
        console.log(error);
    }
}