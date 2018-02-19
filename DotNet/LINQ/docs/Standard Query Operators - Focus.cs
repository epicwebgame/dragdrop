// Aggregate
public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);    

// Conversion
public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source);

// Equality
public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);


// Generation
public static IEnumerable<TResult> Empty<TResult>();

// Grouping
public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);

public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector);

// Ordering
// Just for fun, implement OrderBy, ThenBy and OrderByDescending and ThenByDescending. Find out what the IOrderedEnumerable<T> looks like and does and do that. Write about it.

// Partitioning
public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);
public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count);
public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);


// Projection and flattening
public static IEnumerable<TResult> SelectMany...

// Quantifier
public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);

// I don't know what this is for
public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector);


find out how a big integer (System.Numerics.BigInteger) is implemented (it's there in reflector) and write an article about it and submit it to the MSDN. If they are not interested, don't give up, submit it to another magazine (Dobbs or something), keep trying submissions on prestigious .NET websites. If no one takes up on it, publish it on my own website. That'll be a good start, plus that will give me some credibility for work as well. -- Developer Fusion magazine (Jon Skeet has written some articles for them)
https://visualstudiomagazine.com/articles/2011/01/25/biginteger.aspx (Visual Studio Magazine as well)


see the System.Linq.Lookup<TKey, TSource> class and read its full implementation. Write about it.

Learn what this type of a nested / twisted query means:
from foo in bar
from gar in har
where ...
select ...
It is a cartesian product like:
foreach(var foo in bar)
	foreach(var gar in har)
		...
		
Learn about those 'let' variable declaration clauses that appear within LINQ queries

Learn how to write joins and complicated joins in the query expression syntax

Learn how to write nested queries

Learn how to write large, complicated queries. Make up problems and try to solve them. May be read a book on LINQ and do everything that's in it.