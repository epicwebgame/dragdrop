## Attributes

Since the same attribute may apply to more than one element, and there are some attributes that may be applied to *any* element, we categorize attributes in our heads in the following manner:

1. Event Handlers: All event handlers may be specified as attributes. For e.g. `onclick`. The list of all possible event handlers is a moving target because each new API introduces its own events, and hence we'll just have to concede in our failure to produce such an exhaustive list of attributes that fall under the category of event handlers.

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

### Deprecated attributes

Some of these attributes controlled presentation, which, in the spirit of HTML5, must be left to CSS only. Hence, these attributes have been removed from HTML5. They are not allowed in HTML5.

| S.No. | Attribute | Elements it applied to | Meaning of the attribute | Interesting links you got? |
| ---- | ---------- | ---------------------- | ------------------------ | --------------------------------|
| 1. | rev | link, a | Like the `rel` attribute, the `rev` attribute also specifies the relationship between the current and the linked document.<br /><br />I suppose it was introduced callously to represent *the reverse or reciprocal of a relationship* but it turned out to be a superfluous, nonsensical nuisance that confused more than served any real purpose.<br /><br />For e.g. <br />`<link rel = "parent" href = "theChildDocument.html" />`<br /><br />was supposed to indicate that the current document was the parent of the `theChildDocument.html` document.<br /><br />That begs the questions -- what does being the parent of an HTML document mean? Clearly, the intent and the relationship are ill-defined. | [How To Use The Rev Attribute](http://www.cardinalpath.com/how-to-use-the-rev-attribute/) |
| 2. | charset | link, a |  |  |
| 3. | shape | a |  |  |
| 4. | coords | a | | |
| 5. | longdesc | img, iframe | | |
| 6. | target | link | | |
| 7. | nohref | area | | | 
| 8. | profile | head | | | 
| 9. | version | html | | | 
| 10. | name | img | | | 
| 11. | scheme | meta | | |
| 12. | archive | object | | | 
| 13. | classid | object | | | 
| 14. | codebase | object | | | 
| 15. | codetype | object | | | 
| 16. | declare | object | | | 
| 17. | standby | object | | | 
| 18. | valuetype | param | | | 
| 19. | type | param | | | 
| 20. | axis | td, t | | |
| 21. | abbr | td, t | | |
| 22. | scope | td | | | 
| 23. | align | caption, iframe, img, input, object, legend, table, hr, div, h1, h2, h3, h4, h5, h6, p, col, colgroup, tbody, td, tfoot, th, thead, tr | | |
| 24. | alink | body | | | 
| 25. | link | body | | | 
| 26. | vlink | body | | | 
| 27. | text | body | | | 
| 28. | background | body | | | 
| 29. | bgcolor | table, tr, td, th, body | | |
| 30. | border | table, object | | | |
| 31. | cellpadding | table | | | | 
| 32. | cellspacing | table | | | | 
| 33. | char | col, colgroup, tbody, td, tfoot, th, thead, tr | | | |
| 34. | charoff | col, colgroup, tbody, td, tfoot, th, thead, tr | | | |
| 35. | clear | br | | | | 
| 36. | compact | dl, menu, ol, ul | | | | 
| 37. | frame | table | | | | 
| 38. | frameborder |  iframe | | | | 
| 39. | hspace | img, object | | | | 
| 40. | vspace |  img, object | | | | 
| 41. | marginheight | iframe | | | | 
| 42. | marginwidth | iframe | | | | 
| 43. | noshade | hr | | | | 
| 44. | nowrap | td, th | | | | 
| 45. | rules | table | | | | 
| 46. | scrolling | iframe | | | | 
| 47. | size | hr | | | | 
| 48. | type | li, ol, ul | | | | 
| 49. | valign | col, colgroup, tbody, td, tfoot, th, thead, tr | | | | 
| 50. | width | hr, table, td, th, col, colgroup, pre | | | | 

### Attributes that can be used in HTML5

| S.No | Attribute | Elements it can be used with | Meaning of the attribute | Links | 
| ---- | --------- | -------------------------- | ---------------------------| ----- |
| 1. | accept | form, input | | |
| 2. | accept-charset | | | |
| 3. | accesskey | | | | 
| 4. | action | | | | 
| 5. | align | | | | 
| 6. | alt | | | | 
| 7. | async | | | | 
| 8. | autocapitalize | | | | 
| 9. | autocomplete | | | | 
| 10. | autofocus | | | | 
| 11. | autoplay | | | | 
| 12. | bgcolor | | | | 
| 13. | border | | | | 
| 14. | buffered | | | | 
| 15. | challenge | | | | 
| 16. | charset | | | | 
| 17. | checked | | | | 
| 18. | cite | | | | 
| 19. | class | | | | 
| 20. | code | | | | 
| 21. | codebase | | | | 
| 22. | color | | | | 
| 23. | cols | | | | 
| 24. | colspan | | | | 
| 25. | content | | | | 
| 26. | contenteditable | | | | 
| 27. | contextmenu | | | | 
| 28. | controls | | | | 
| 29. | coords | | | | 
| 30. | crossorigin | | | | 
| 31. | data | | | | 
| 32. | data-* | | | | 
| 33. | datetime | | | | 
| 34. | default | | | | 
| 35. | defer | | | | 
| 36. | dir | | | | 
| 37. | dirname | | | | 
| 38. | disabled | | | | 
| 39. | download | | | | 
| 40. | draggable | | | | 
| 41. | dropzone | | | | 
| 42. | enctype | | | | 
| 43. | for | | | | 
| 44. | form | | | | 
| 45. | formaction | | | | 
| 46. | header | | | | 
| 47. | height | | | | 
| 48. | hidden | | | | 
| 49. | high | | | | 
| 50. | href | | | | 
| 51. | hreflang | | | | 
| 52. | http-equiv | | | | 
| 53. | icon | | | | 
| 54. | id | | | | 
| 55. | integrity | | | | 
| 56. | ismap | | | | 
| 57. | itemprop | | | | 
| 58. | keytype | | | | 
| 59. | kind | | | | 
| 60. | label | | | | 
| 61. | lang | | | | 
| 62. | language | | | | 
| 63. | list | | | | 
| 64. | loop | | | | 
| 65. | low | | | | 
| 66. | manifest | | | | 
| 67. | max | | | | 
| 68. | maxlength | | | | 
| 69. | minlength | | | | 
| 70. | media | | | | 
| 71. | method | | | | 
| 72. | min | | | | 
| 73. | multiple | | | | 
| 74. | muted | | | | 
| 75. | name | | | | 
| 76. | novalidate | | | | 
| 77. | open | | | | 
| 78. | optimum | | | | 
| 79. | pattern | | | | 
| 80. | ping | | | | 
| 81. | placeholder | | | | 
| 82. | poster | | | | 
| 83. | preload | | | | 
| 84. | radiogroup | | | | 
| 85. | readonly | | | | 
| 86. | rel | | | | 
| 87. | required | | | | 
| 88. | reversed | | | | 
| 89. | rows | | | | 
| 90. | rowspan | | | | 
| 91. | sandbox | | | | 
| 92. | scope | | | | 
| 93. | scoped | | | | 
| 94. | seamless | | | | 
| 95. | selected | | | | 
| 96. | shape | | | | 
| 97. | size | | | | 
| 98. | sizes | | | | 
| 99. | slot | | | | 
| 100. | span | | | | 
| 101. | spellcheck | | | | 
| 102. | src | | | | 
| 103. | srcdoc | | | | 
| 104.| srclang | | | | 
| 105. | srcset | | | | 
| 106. | start | | | | 
| 107. | step | | | | 
| 108. | style | | | | 
| 109. | summary | | | | 
| 110. | tabindex | | | | 
| 111. | target | | | | 
| 112. | title | | | | 
| 113. | type | | | | 
| 114. | usemap | | | | 
| 115. | value | | | | 
| 116. | width | | | | 
| 117. | wrap | | | | 

