public static IEnumerable<TResult> SelectMany<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, IEnumerable<TResult>> selector);
	
	
public static IEnumerable<TResult> SelectMany<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, int, IEnumerable<TResult>> selector);
	
	
public static IEnumerable<TResult> SelectMany<TOuter, TInner, TResult>(
    this IEnumerable<TOuter> source,
    Func<TOuter, IEnumerable<TInner>> selector,
    Func<TOuter, TInner, TResult> resultSelector);
	
	
public static IEnumerable<TResult> SelectMany<TOuter, TInner, TResult>(
    this IEnumerable<TOuter> source,
    Func<TOuter, int, IEnumerable<TInner>> selector,
    Func<TOuter, TInner, TResult> resultSelector);