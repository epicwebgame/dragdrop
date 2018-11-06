## Questions

This is the list of questions I have about MS Build without knowing it first. I usually make this list when I start learning a technology.

1. Question: How do I foreach over something?

2. How do I re-use a task in another?

3. How do I re-use one target from another?

4. Can a task depend on another?

5. Can a target depend on another?

6. How can I execute more than one target?

7. How can I execute all the targets defined in an MS Build file in the sequence they are declared without having to specify all the target names on the CLI or in an RSP file? Is there a short-hand such as /t:* (this doesn't work)?

8. Refer to / import / include a portion from another external build file?

9. Import / include only a portion of an external file into this one?

10. Can the import be used to import any kind of a file or just MS Build / XML files / XML files that conform to the MS Build schema?

11. How can I define a target / task execution sequence where tasks have a dependency on other tasks or targets have a dependency on another task?

12. How do I do an if construct?

13. How do I create my own custom tasks?

14. Are target and/or tasks hoisted? In other words, can I refer to a task or target before it appears in the file?

15. What is the scope of variables / property groups / item groups? Can I refer to a variable declared in another file I am referencing?

16. What happens if a task or target fails? Does execution of the MS Build program stop reporting a build failure? Or does execution of the next target or task continue and the build is reported to have failed listing the tasks and/or targets that failed and the ones that succeeded? Or does the execution carry on regardless and report build success with a few task or target failures? How can I mimic all the three behaviors?

17. How does a task or target return a value? How is this value referenced else where? What kinds of values may be returned? Complex objects also? How?

18. How do I evaluate an expression inside an MS Build file? Is there a syntax for:
(i) Concatenating strings?
(ii) Arithmetic operations
(iii) Casting from one data type to another? Is there type-strictness? What all data types are available? Dates and times? How are booleans evaluated?

19. Can the flow-of-execution be rolled back if a task or target fails? Can I make complex scenarios such as: if A and B fail, roll back, otherwise if A and C fail, carry on, but if A and B and C fail, don't rollback, just abort.

20. What if you access a property that doesn't exist? Does it fail the build or does it just report empty contents?

21. What if you access a conditional property whose condition evaluates to false? Does it fail the build or does it just report empty contents?


## Tasks

1. Catalog all in-built tasks

2. Learn all CLI switches

3. Study the source code of a Task.

4. Study the source of ItemGroup.

5. Study the source of the Main program that accepts the CLI switches.

6. Just study the whole source just for fun. I see that they've broken down the stuff into too many assemblies that comes close to what is normally done in lousy enterprises.

7. Think of the tasks I'd generally want to use in programming:
Read from and write to a file. Synchronously. Asynchronously also?
Make an HTTP request of any kind and receive data synchronously or asynchronously, as a string or a prepared object or as a stream.
Read from and write to a stream.
Read from and write to the registry.
Move, delete, rename, and create files and folders. Set permissions on file system objects.
If construct 
For loop