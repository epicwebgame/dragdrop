# HTML5

My first impressions are:
1. Cor, it's vast! The landscape is vast! It tries to be everything.

2. I am having to spend a great deal of effort in assimilating information from different sources into categories because of the inconsistent taxonomy used in different places. For e.g. the [Event Reference](https://developer.mozilla.org/en-US/docs/Web/Events) page on the MDN (Mozilla Developer Network) lists 69 classes of events in the left-bar, the [Web API](https://developer.mozilla.org/en-US/docs/WebAPI) page on MDN classifies all API into 30-some categories, while this [HTML Guide on the MDN](https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5) presents the same information differently in a different number and manner of categories. Other places on the Internet add to the confusion with their individual taxonomies.

3. But there's good news, it looks like. This is going to be fun. The future. It's fun and scary what capabilities are being added to the browser and who knows why -- to serve what ends?

## So, what's the big whoop about HTML5! What did you learn?
HTML4 and its predecessors had just elements and attributes. If you needed something else, you wrote JavaScript and some CSS. JavaScript is a tiny language with a tiny core. To do anything fancy like play video, render raster graphics, drag and drop, store large amounts of data on the client, get a user's geo-location, you had to twist an arm, use an ActiveX component, applet or Flash or Silverlight or some such, or it was just not possible and you had to give up and do that server side. HTML5 now introduces many native capabilities into the client/browser that can be invoked with a combination of new HTML tags, attributes and some JavaScript. So, HTML5 is not just HTML. It is just HTML but they're refering to a very few new HTML tags and attributes, plus lots of new JavaScript API as HTML5. Because it is too much and tries to do a lot, its specification has been broken down into many smaller ones, each focusing on an individual feature, and they're calling the whole conglomerate with the name HTML5.

These are the new things HTML5 brings:
1. Introduces new [tags](https://github.com/Sathyaish/Practice/blob/master/HTML5/Elements.md),and removes or deprecates some old tags.
2. Introduces new [input control types](https://github.com/Sathyaish/Practice/blob/master/HTML5/InputControlTypes.md).
3. Introduces new [attributes](https://github.com/Sathyaish/Practice/blob/master/HTML5/Attributes.md), and removes or deprecates some.
4. Introduces a JavaScript API, that is, new objects, functions and events, for developers to call into the many newly introduced features. Some of these new features have their own separate specifications.

So, HTML5 == Lots of JavaScript + a few new tags and attributes.

![alt text](https://raw.githubusercontent.com/Sathyaish/Practice/master/HTML5/images/ThereforeHTML5Is.png "Therefore, HTML5 is the addition of lots of new features to the browser, manifested as some new tags and attributes and lots of JavaScript API.")

## New Features / Capabilities Introduced Into the Browser
With all of these tags and attributes and JavaScript API, it adds the following new capabilities to the browser:
1. New semantic markup
2. Canvas
3. Audio and video
4. Web Audio
5. Form improvements. This is also what is being refered to by the name **Web Forms 2.0**.
6. &lt;iframe&gt; improvements.
7. CORS
8. Drag and drop
9. MathML
10. File API, FileWriter
11. Geo location
12. Microdata
13. Web SQL
14. IndexDb
15. Web Storage - local storage, session storage
16. SVG
17. Web Cryptography
18. Web RTC
19. WebVTT
20. Web messaging
21. Web Workers
22. Server Side Events
23. Web Components
24. Web Sockets
25. The Web Socket Protocol

Besides this, there's some new modules that are something to look forward to and watch (there were more but I found them boring or just fluff so I have ommited them):

26. HTML + RDFa
27. Shadow DOM
28. Web Intents
29. Polyglot markup
30. HTML Editing API
31. HTML Media Capture
32. Media Capture & Streams
33. Media Fragment URI's
34. Media Source Extensions
25. Encrypted Media Extensions

Not all of the above merits my immediate interest.

What happened to Promises? Where is that? I didn't find that in my first comb-through.

## The other moving parts, modules and extensions of HTML5 and what they mean

## Links
1. An HTML tag and attribute [reference](https://developer.mozilla.org/en-US/docs/Web/HTML) that includes HTML5 stuff. You get there by going to the MDN home page, selecting **References and Guides** menu item from the top navigation bar **-> more docs...**, and from that page, the hyperlink **HTML**. Then you look at the **References** section in the left bar, and under it the sections **HTML elements**, **Global attributes** and **Input types**.  

2. The [HTML5](https://en.wikipedia.org/wiki/HTML5) page on the Wikipedia.

3. Dr. Leslie F. Sikos' HTML [stuff](http://www.lesliesikos.com/html5-became-a-standard-html-5-1-and-html-5-2-on-the-way/), [the](http://www.lesliesikos.com/html5/) [good](https://www.lesliesikos.com/what-are-the-differences-between-html5-and-html-5-1/) stuff.

4. The [WHATWG HTML living document for developers](https://html.spec.whatwg.org/dev/).

5. A simple, fucking stupid and happy [tutorial on HTML5](https://www.tutorialspoint.com/html5/index.htm) from Tutorials Point -- HTML for the happy and stupid people who hold jobs they shouldn't.

6. The [HTML5](https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5) page on MDN. You get there by typing **HTML5** in Google.

7. [The Ultimate HTML5 Cheatsheet](https://www.wpkube.com/html5-cheat-sheet/) from WPKube.com.

8. HTML5 [Event Reference](https://developer.mozilla.org/en-US/docs/Web/Events)

9. HTML5 [Tag Reference on Tutorials Point](https://www.tutorialspoint.com/html5/html5_tags.htm), [deprecated tags](https://www.tutorialspoint.com/html5/html5_deprecated_tags.htm), [new tags](https://www.tutorialspoint.com/html5/html5_new_tags.htm)

10. HTML5 [Quick Guide on Tutorials Point](https://www.tutorialspoint.com/html5/html5_quick_guide.htm) -- a good summary, mostly what you'd want if you wanted to see it all at a glance.

11. List of [HTML5 Events](https://www.tutorialspoint.com/html5/html5_events.htm) on Tutorials Point. The same is also available on the [Quick Guide](https://www.tutorialspoint.com/html5/html5_quick_guide.htm) page listed above.

12. A list of the Web API's introduced with HTML5, [classified by category](https://developer.mozilla.org/en-US/docs/WebAPI), and [alphabetically classified](https://developer.mozilla.org/en-US/docs/Web/API).
