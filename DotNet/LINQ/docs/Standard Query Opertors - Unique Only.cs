public static class Enumerable
{
    public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);
    
	public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    
	public static bool Any<TSource>(this IEnumerable<TSource> source);
    
	public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source);
    
	public static decimal Average(this IEnumerable<decimal> source);
    
	public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source);
    
	public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
    
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);
    
    public static int Count<TSource>(this IEnumerable<TSource> source);
    
    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source);
    
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source);
    
    public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index);
    
	public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index);
	
    public static IEnumerable<TResult> Empty<TResult>();
    
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);    
    
    public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    
    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source);    
    
    public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);
    
    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
    
    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector);
    
    public static TSource Last<TSource>(this IEnumerable<TSource> source);
    
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source);
    
    public static long LongCount<TSource>(this IEnumerable<TSource> source);
    
    public static decimal Max(this IEnumerable<decimal> source);
    
	public static double Min(this IEnumerable<double> source);
    
    public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source);
    
    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
    public static IEnumerable<int> Range(int start, int count);
    
    public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count);
    
    public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source);
    
    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
    
    public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
    
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
    
    public static TSource Single<TSource>(this IEnumerable<TSource> source);
    
    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source);
    
    public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);
    
    public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    
	public static decimal Sum(this IEnumerable<decimal> source);
    
	public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count);
    
	public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    
    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
    
    public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source);
	
    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
	public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source);
    
    public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
    
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
    
	public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    
    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector);
}