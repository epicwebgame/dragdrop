Array
Hashtable
Set
Hashset
Map
Dictionary
Tuple
.NET Core's Span<T>
Stack
Queue
Linked List
Doubly Linked List
Circular Linked List
Tree, Binary Tree, Binary Search Tree, AVL Tree, Balanced Tree, Balanced AVL Tree. Binary Search Tree vs. the binary search technique using an array
Tries
Heap
Graph? Graph vs. tree / trie / heap?


Cyclic Buffer

Stream?


Sort algorithms:
Quick sort
Insertion sort
Merge sort
Bubble sort
Heap sort
Counting sort


Are there also searching algorithms?



DFS, BFS?


When and why would I use one DS over another? One algorithm over another?


float
Unicode
Under the hood of DateTime and Timespan



Operations on any data structure:
Insert an element
Insert it at a certain location in the structure (start, end, nth, or at a place determined by the data structure after considering the data)
Remove an element
Remove an element that right now sits at a certain location in the structure (start, end, nth, or at a place determined by the data structure after considering the data)
Look for an item / Search / Find an item from within a data structure
Update (combination of search, remove and insert)


Currying
Tail recursion
Call tail optimization


Little Endian, Big Endian
Two's Complements, one's complement, how does my OS store this?

How to make Powershell terminal and even the cmd terminal display unicode characters? The Hindi file names display gibberish.


Does a node in a heap have only two children -- left and right -- or can it have any number of them?
When an why would I use a heap? Both insertion and look-up are tedious. There's no guarantee a node will be on a given path until you search the entire heap.


The last I left today, I was thinking about the pain and the differences between a tree and a heap, and a binary search tree. BST is turning out to be a very nice thing in every scenario -- insert, look up, whatever -- compared to anything else I know of, i.e. an array, i.e. implementing binary search on a sorted array. I was also thinking about how the .NET GC heaps might have been implemented. They seem like an array looking at them in windbg, but it doesn't make sense for them to be arrays because resizing an array would mean moving everything on that heap on which the array resides.