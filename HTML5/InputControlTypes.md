## Input Control Types

### Input control types that were available in HTML4
1. button
2. checkbox
3. file
4. hidden
5. image
6. password
7. radio
8. reset
9. submit
10. text

### New input control types added in HTML5
1. date
2. datetime-local
3. datetime
4. month
5. time
6. week
7. email
8. url
9. search
10. number
11. range
12. tel
13. color

According to [the HTML5 reference on the MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input), the `datetime` input type has been deprecated in HTML5. It reads as follows:

> datetime: HTML5 A control for entering a date and 
> time (hour, minute, second, and fraction of a second) 
> based on UTC time zone. This feature has been removed 
> from WHATWG HTML.

### Therefore, now all the input types available in HTML5 are:
1. button
2. checkbox
3. color
4. date
5. datetime-local
6. email
7. file
8. hidden
9. image
10. month
11. number
12. password
13. radio
14. range
15. reset
16. search
17. submit
18. tel
19. text
20. time
21. url
22. week
23. datetime (deprecated)

### Analysis
After doing [this example on input control types](https://github.com/Sathyaish/Practice/blob/master/HTML5/examples/inputControlTypes.html) and reading the MDN, it appears that most HTML5 controls, esp. the ones that relate to time, are not well-supported on all browsers yet. So it is best to use a library like [jQuery UI](https://jqueryui.com/) [datepicker](https://jqueryui.com/datepicker/) or [timepicker](http://timepicker.co/) or somethingelse or make your own.
