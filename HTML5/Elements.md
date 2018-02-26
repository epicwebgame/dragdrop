## Elements

There is an [HTML element reference on the MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Element) that classifies elements based on function. However, I am classifying them as *what existed earlier*, *what was added* and *what was removed*, and then a long list of *all that there is now,* because such a classification helps my brain take an inventory of the entire gamut, label and store information and concepts better.

## At a glance
The listing below indicates that there were 108 elements prior to the advent of HTML5. 15 of these were removed, 93 retained, and a new 31 added. Thus making the total number of elements now valid in HTML5 to be 124.

![alt text](https://raw.githubusercontent.com/Sathyaish/Practice/master/HTML5/images/Breakup-Elements.png "A break-up of the number of HTML elements that existed before, were deprecated and newly introduced by HTML5, thus arriving at the total number of elements in use in HTML5.")

### Elements that existed in HTML4 and were brought into HTML5
This list does not include the elements that have been deprecated by HTML5. Therefore, the total number of elements that existed prior to HTML5 are these 93 plus the deprecated 15 listed in a following section. That is 108 elements.

| S.No. | Element | Explanation |
| ---- | -------- | ----------- |
| 1. | a | | |
| 2. | [abbr]() | <p>Represents an abbreviation or acronym and optionally provides a full description for it. If present, the `title` attribute must contain this full description and nothing else.</p><p>For e.g.</p><p> `<abbr title = "Laugh out Loud">LOL</abbr>`</p>  | |
| 3. | [address]() |<p>Indicates that the enclosed HTML provides contact information for a person or people, or for an organization.</p><p>The contact information provided by an `<address>` element's contents can take whatever form is appropriate for the context, and may include any type of contact information is needed, such as physical address, URL, email address, phone number, social media handle, geographic coordinates, and so forth. It should include the name of the person, people, or organization to which the contact information refers.</p><p>`<address>` can be used in a variety of contexts, such as providing a business's contact information in the page header, or indicating the author of an article by including an `<address>` element within the `<article>`</p>.| |
| 4. | [area]() | Defines a hot-spot region on an image and optionally associates it with a hyperlink text. It can only be used within a `<map>` element.| |
| 5. | b | Makes the text bold. It's called the **Bring Attention To** lement or something in HTML parlance. | |
| 6. | [base]() | Specifies the base URL to be used for all relative URL's in the document. There can only be on such in a document. And it may be read by using the `document.baseURI` property in JavaScript. | |
| 7. | [bdo]() | Bi-directional text override. Will render text in the direction / orientation you choose. For e.g. rtl (Right to left) will display the text from right to left, as if the string were reversed. | |
| 8. | [bgsound]() | Internet explorer only. Not a standard element. May be removed any time in the future. IE lets you play a sound file while you're looking at the page. Use the `<audio>` element instead. | |
| 9. | [blink]() | Non-standard. Can be removed anytime. Causes text to blink. | |
| 10. | blockquote | | |
| 11. | body | | |
| 12. | [br]() | | |
| 13. | [button]() | | |
| 14. | [caption]() | Specifies the ttile or caption of a table, and if used, is always the first child of the table element. | |
| 15. | cite | | |
| 16. | code | | |
| 17. | col | | |
| 18. | colgroup | | |
| 19. | content | | |
| 20. | dd | | |
| 21. | del | | |
| 22. | dfn | | |
| 23. | dialog | | |
| 24. | div | | |
| 25. | dl | | |
| 26. | dt | | |
| 27. | element | | |
| 28. | em | | |
| 29. | fieldset | | |
| 30. | form | | |
| 31. | h1 | | |
| 32. | head | | |
| 33. | hr | | |
| 34. | html | | |
| 35. | i | | |
| 36. | iframe | | |
| 37. | image | | |
| 38. | img | | |
| 39. | input | | |
| 40. | ins | | |
| 41. | kbd | | |
| 42. | label | | |
| 43. | legend | | |
| 44. | li | | |
| 45. | link | | |
| 46. | listing | | |
| 47. | main | | |
| 48. | map | | |
| 49. | marquee | | |
| 50. | menu | | |
| 51. | menuitem | | |
| 52. | meta | | |
| 53. | multicol | | |
| 54. | nextid | | |
| 55. | nobr | | |
| 56. | noembed | | |
| 57. | noscript | | |
| 58. | object | | |
| 59. | ol | | |
| 60. | optgroup | | |
| 61. | option | | |
| 62. | p | | |
| 63. | param | | |
| 64. | picture | | |
| 65. | plaintext | | |
| 66. | pre | | |
| 67. | q | | |
| 68. | rtc | | |
| 69. | samp | | |
| 70. | script | | |
| 71. | select | | |
| 72. | shadow | | |
| 73. | slot | | |
| 74. | small | | |
| 75. | spacer | | |
| 76. | span | | |
| 77. | strong | | |
| 78. | style | | |
| 79. | sub | | |
| 80. | sup | | |
| 81. | table | | |
| 82. | tbody | | |
| 83. | td | | |
| 84. | template | | |
| 85. | textarea | | |
| 86. | tfoot | | |
| 87. | th | | |
| 88. | thead | | |
| 89. | title | | |
| 90. | tr | | |
| 91. | ul | | |
| 92. | var | | |
| 93. | xmp | | |

### Elements deprecated by HTML5
| S.No. | Element | Explanation |
| ---- | -------- | ----------- |
| 1. | acronym | | |
| 2. | applet | | |
| 3. | basefont | | |
| 4. | big | | |
| 5. | center | | |
| 6. | dir | | |
| 7. | font | | |
| 8. | frame | | |
| 9. | frameset | | |
| 10. | isindex | | |
| 11. | noframes | | |
| 12. | s | | |
| 13. | strike | | |
| 14. | tt | | |
| 15. | u | | |

### New HTML5 tags / elements
| S.No. | Element | Explanation |
| ---- | -------- | ----------- |
| 1. | article | | |
| 2. | aside | | |
| 3. | audio | | |
| 4. | bdi | | |
| 5. | canvas | | |
| 6. | command | | |
| 7. | data | | |
| 8. | datalist | | |
| 9. | details | | |
| 10. | embed | | |
| 11. | figcaption | | |
| 12. | figure | | |
| 13. | footer | | |
| 14. | header | | |
| 15. | hgroup | | |
| 16. | keygen | | |
| 17. | mark | | |
| 18. | meter | | |
| 19. | nav | | |
| 20. | output | | |
| 21. | progress | | |
| 22. | rp | | |
| 23. | rt | | |
| 24. | rubyv | | |
| 25. | section | | |
| 26. | source | | |
| 27. | summary | | |
| 28. | time | | |
| 29. | track | | |
| 30. | video | | |
| 31. | wbr | | |

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
