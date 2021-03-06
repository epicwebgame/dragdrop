## Notes

### Attribute selectors
[input]
[input=val]
[input~=val]
[input|=val]
[input^=val]
[input$=val]
[input*=val]
[input operator val i] (case insensitive comparison)

### Simple selectors
Class selector
ID selector
Element selector

### Universal selector

### Combinators
Comma -- (A, B) this and that, this or that, applies to all these items
Space -- (A B) descendent / ancestor any number of levels deep
Direct child -- (A > B) (greater than sign)
Next Sibling -- (A + B)
Following sibling (A ~ B)

### Normal layout flow (width and height by default)

### Margin Collapsing

### The box model and changing its default characteristics

### Pseudo elements

### Pseudo classes

### CSS OM (CSS DOM)

### Transforms
* rotate()
   * rotateX()
   * rotateY()
   * rotateZ()
   * rotate3d()
* skew()
   * skewX()
   * skewY()
* scale()
   * scaleX()
   * scaleY()
   * scaleZ()
   * scale3d()
* translate()
   * translateX()
   * translateY()
   * translateZ()
   * translate3d()
* matrix()
   * matrix3d()
* perspective()

### Filters (they're not very nice; not half as nice as if you did them in an image editor. The blur and drop-shadow are kind of better, but the others are just too crude in that they have very little dynamic range.)
1. blur()
2. brightness()
3. saturate()
4. hue-rotate()
5. opacity()
6. contrast()
7. sepia()
8. grayscale()
9. invert()
10. drop-shadow()


### Main stuff:
Box shadows
Text shadows
Transforms (see above)
Filters (see above)
Animations (@keyframes)
Vendor based thingies
Background and its related properties (clip, origin, size, etc.)
Border and its various kinds (including having a border made out of a picture)
Border radius
Blend modes
Text-clip-to-background or clip background only to text, whatever that thing is: looks like "A Most Violent Year" train thing.
Web fonts, esp. layered fonts
rbga (alpha channel transparency) vs. setting opacity on the whole element (not that nice)
positioning -- static (default), relative, absolute, fixed
z-index
float
CSS tables
flex (flexbox)
CSS Grid frameworks and the native CSS Grid (that's still up and coming)
::before and ::after to add nice layers on top and then cut or slice through them to create interesting mirages (look at her https://www.youtube.com/watch?v=_7KSmXXf-S4)

Those global values -- inherit, reset, unset, initial, etc.
calc()
clip-path (see Mandy Michael's video "CSS Effects" and her Codepens @mandy_kerr, see it in the diagonal "Fracture")
column-count (very interesting, see my Stack Overflow question: [Creating a two-columnar magazine layout with CSS](https://stackoverflow.com/questions/50549041/creating-a-two-columnar-magazine-layout-with-css) Permalink: https://stackoverflow.com/q/50549041/303685
CSS Shapes and shape-outside. See https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Shapes/Overview_of_CSS_Shapes.
What the hell is this? https://developer.mozilla.org/en-US/docs/Web/CSS/Value_definition_syntax I got here also from the <basic_shape> article.

Media Queries
@supports vs. modernizr
CSS variables

How do I cut diagonally across a piece of text? (look at her https://www.youtube.com/watch?v=_7KSmXXf-S4)


### Exercises to try

1. Center text within a div, both horizontally and vertically.

2. Center a div on a page horizontally. Vertically.

3. Center a div within a div, horizontally and vertically.

4. Sticky footer.

5. [How do I horizontally center a div that has the main content between two empty divs?](https://stackoverflow.com/q/47540255/303685)

6. [Get a textbox to fill 100% of the width of its container div](https://stackoverflow.com/q/47325134/303685)

7. Try some gradient colors. Try to create a vignette with gradients.

8. Diagonal "Fractured" that @mandy_kerr (Mandy Michael) did in that CSS Text Effects video.

9. 2 column magazine layout with a picture in the center.

10. 3 column magazine layout with a picture in the center.

11. 2 column layout with a picture in the center and a section in the middle covering 80% of the page width displaying a blurb or slogan from the article text as if to highlight the main point of the article, like they do in magazine articles.

12. 2 column layout with a picture in the center and a section in the middle covering 80% of the page width displaying a blurb or slogan from the article text as if to highlight the main point of the article, like they do in magazine articles.

13. All of the text-effects that Mandy Michael did in her talk, do them without looking on your own.

*. My Stack Overflow Questions

*. Another 5 CSS tagged questions from Stack Overflow.

14. clip-path: circle, inset, polygon. Try to make a triangle.

15. border radius

16. box-shadows

17. text-shadows

18. shape-outside

19. What good is modernizr for? See how it works. @supports replaces it, it seems?

20. filters

21. Transforms, esp. perspective. Try and make that 3d cube.

22. animations

23. Web fonts

24. Make a border out of a picture.

25. Make your own CSS grid, just one.

26. calc()

27. column-count

28. media queries

29. 3 column layout with a picture in the center and a section in the middle covering 80% of the page width displaying a blurb or slogan from the article text as if to highlight the main point of the article, like they do in magazine articles:
a) column-count
b) Web fonts
c) text-shadows
d) calc()

30. Try some gradient colors. Try to create a vignette with gradients.
border radius
box-shadows

31. @supports
Make a border out of a picture.
animations

32. All of the text-effects that Mandy Michael did in her talk, do them without looking on your own.

33. My Stack Overflow Questions

34. Another 5 CSS tagged questions from Stack Overflow.
