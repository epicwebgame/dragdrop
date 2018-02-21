# HTML5

My first impressions are:
1. Cor, it's vast! The landscape is vast! It tries to be everything.

2. I am having to spend a great deal of effort in assimilating information from different sources into categories because of the inconsistent taxonomy used in different places. For e.g. the [Event Reference](https://developer.mozilla.org/en-US/docs/Web/Events) page on the MDN (Mozilla Developer Network) lists 69 classes of events in the left-bar, the [Web API](https://developer.mozilla.org/en-US/docs/WebAPI) page on MDN classifies all API into 30-some categories, while this [HTML Guide on the MDN](https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5) presents the same information differently in a different number and manner of categories. Other places on the Internet add to the confusion with their individual taxonomies.

3. But there's good news, it looks like. This is going to be fun. The future. It's fun and scary what capabilities are being added to the browser and who knows why -- to serve what ends?

## So, what's the big whoop about HTML5! What did you learn?
HTML4 and its predecessors had just elements and attributes. If you needed something else, you wrote JavaScript and some CSS. JavaScript is a tiny language with a tiny core. To do anything fancy like play video, render raster graphics, drag and drop, store large amounts of data on the client, get a user's geo-location, you had to twist an arm, use an ActiveX component, applet or Flash or Silverlight or some such, or it was just not possible and you had to give up and do that server side. HTML5 now introduces many native capabilities into the client/browser that can be invoked with a combination of new HTML tags, attributes and some JavaScript. So, HTML5 is not just HTML. It is just HTML but they're refering to a very few new HTML tags and attributes, plus lots of new JavaScript API as HTML5. Because it is too much and tries to do a lot, its specification has been broken down into many smaller ones, each focusing on an individual feature, and they're calling the whole conglomerate with the name HTML5.

These are the new things HTML5 brings:
1. Some new tags
2. Some new attributes
3. Removes or deprecates some tags
4. Adds these new features as sometimes separate specifications. Without exception, all these are introduced by the introduction of new JavaScript API, i.e. objects and events. A minority of them also have accompanying HTML tags and elements.

So, HTML5 == Lots of JavaScript + a few new tags and attributes.

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

## Elements

There is an [HTML element reference on the MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Element) that classifies elements based on function.

### New HTML5 tags / elements
1. article
2. aside
3. audio
4. bdi
5. canvas
6. command
7. data
8. datalist
9. details
10. embed
11. figcaption
12. figure
13. footer
14. header
15. hgroup
16. keygen
17. mark
18. meter
19. nav
20. output
21. progress
22. rp
23. rt
24. ruby
25. section
26. source
27. summary
28. time
29. track
30. video
31. wbr

### Elements deprecated by HTML5
1. acronym
2. applet
3. basefont
4. big
5. center
6. dir
7. font
8. frame
9. frameset
10. isindex
11. noframes
12. s
13. strike
14. tt
15. u

### Elements that existed in HTML4 and were brought into HTML5
1. a
2. abbr
3. address
4. area
5. b
6. base
7. bdo
8. bgsound
9. blink
10. blockquote
11. body
12. br
13. button
14. caption
15. cite
16. code
17. col
18. colgroup
19. content
20. dd
21. del
22. dfn
23. dialog
24. div
25. dl
26. dt
27. element
28. em
29. fieldset
30. form
31. h1
32. head
33. hr
34. html
35. i
36. iframe
37. image
38. img
39. input
40. ins
41. kbd
42. label
43. legend
44. li
45. link
46. listing
47. main
48. map
49. marquee
50. menu
51. menuitem
52. meta
53. multicol
54. nextid
55. nobr
56. noembed
57. noscript
58. object
59. ol
60. optgroup
61. option
62. p
63. param
64. picture
65. plaintext
66. pre
67. q
68. rtc
69. samp
70. script
71. select
72. shadow
73. slot
74. small
75. spacer
76. span
77. strong
78. style
79. sub
80. sup
81. table
82. tbody
83. td
84. template
85. textarea
86. tfoot
87. th
88. thead
89. title
90. tr
91. ul
92. var
93. xmp

### Therefore, all the tags / elements now available in HTML5 are:
1. a
2. abbr
3. address
4. area
5. article
6. aside
7. audio
8. b
9. base
10. bdi
11. bdo
12. bgsound
13. blink
14. blockquote
15. body
16. br
17. button
18. canvas
19. caption
20. cite
21. code
22. col
23. colgroup
24. command
25. content
26. data
27. datalist
28. dd
29. del
30. details
31. dfn
32. dialog
33. div
34. dl
35. dt
36. element
37. em
38. embed
39. fieldset
40. figcaption
41. figure
42. footer
43. form
44. h1
45. head
46. header
47. hgroup
48. hr
49. html
50. i
51. iframe
52. image
53. img
54. input
55. ins
56. kbd
57. keygen
58. label
59. legend
60. li
61. link
62. listing
63. main
64. map
65. mark
66. marquee
67. menu
68. menuitem
69. meta
70. meter
71. multicol
72. nav
73. nextid
74. nobr
75. noembed
76. noscript
77. object
78. ol
79. optgroup
80. option
81. output
82. p
83. param
84. picture
85. plaintext
86. pre
87. progress
88. q
89. rp
90. rt
91. rtc
92. ruby
93. samp
94. script
95. section
96. select
97. shadow
98. slot
99. small
100. source
101. spacer
102. span
103. strong
104. style
105. sub
106. summary
107. sup
108. table
109. tbody
110. td
111. template
112. textarea
113. tfoot
114. th
115. thead
116. time
117. title
118. tr
119. track
120. ul
121. var
122. video
123. wbr
124. xmp

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


## Attributes

Since the same attribute may apply to more than one element, and there are some attributes that may be applied to *any* element, we categorize attributes in our heads in the following manner:

1. Event Handlers: All event handlers may be specified as attributes. For e.g. `onclick`. The list of all possible event handlers is a moving target, and hence we'll just have to concede in our failure to produce such an exhaustive list of attributes that fall under the category of event handlers.

2. Global attributes: Attributes that can be applied to *any* element. For e.g. `id`. Fortunately, this list of mangeably finite and we'll list them here.

3. Deprecated attributes: Attributes that existed before HTML5 but now have been deprecated. We'll list them below with the names of the elements that each of the attribute applies to, and the meaning of the attribute in that context.

4. Valid attributes in HTML5: It is difficult to tabulate which of the attributes existed earlier that have been adopted by HTML5 and which ones have been newly introduced by HTML5 itself. Though the **Differences from HTML 4.01 and XHTML 1.x** section of the [HTML5 page on the Wikipedia](https://en.wikipedia.org/wiki/HTML5) posits that the `charset` attribute (on `meta element)` and the `async` attribute (on the `script` element) are the newly introduced attributes, the brevity and the lack of organization of the content on that page incline one to consider that as more of a passing remark than an exhaustive taxonomical one. The page isn't trying to be an inventory of changes, anyway. In sum therefore, I can't find such information readily available and I am not sure if such an exercise of categorization would merit the time investment. So, we'll just acquiesce with [the wall](https://www.shmoop.com/notes-from-underground/2-2-4-stone-wall-symbol.html) we've hit here and list all the attributes that stand valid for use in HTML5 without worrying about which of them existed earlier and which ones were added in HTML5.

### Global attributes
1. accesskey
2. autocapitalize
3. class
4. contenteditable
5. contextmenu
6. dir
7. draggable
8. dropzone
9. hidden
10. id
11. is
12. itemid
13. itemprop
14. itemref
15. itemscope
16. itemtype
17. lang
18. slot
19. spellcheck
20. style
21. tabindex
22. title
23. translate

#### data-* attributes
In addition to the above 23, we may add custom attributes that begin with the word *data-* and the browser will ignore them. Our code may choose to react to their presence.

#### Custom attributes 
We may also add custom attributes to any HTML element and they will be ignored by the browser and we may react to them in our code as we please.

#### aria-*
Finally, attributes that begin with the word *aria-* add accessibility to the web application. ARIA is an acronym that stands for [Accessible Rich Internet Applications](https://developer.mozilla.org/en-US/docs/Web/Accessibility/ARIA).

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
