public static class Observable
{
    // 37 Operators that were there even on IEnumerable<T> but have been changed to return IObservable<T>
    public static IObservable<TSource> Aggregate<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator);
    public static IObservable<bool> All<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<bool> Any<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
	public static IObservable<double?> Average<TSource>(this IObservable<TSource> source, Func<TSource, int?> selector);
	public static IObservable<TResult> Cast<TResult>(this IObservable<object> source);
	public static IObservable<TSource> Concat<TSource>(this IEnumerable<IObservable<TSource>> sources);
	public static IObservable<bool> Contains<TSource>(this IObservable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
    public static IObservable<int> Count<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<TSource> DefaultIfEmpty<TSource>(this IObservable<TSource> source, TSource defaultValue);
    public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<TSource> ElementAt<TSource>(this IObservable<TSource> source, int index);
	public static IObservable<TSource> ElementAtOrDefault<TSource>(this IObservable<TSource> source, int index);
    public static IObservable<TResult> Empty<TResult>(IScheduler scheduler, TResult witness);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
	public static IObservable<TResult> GroupJoin<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, ...);
	public static IObservable<bool> IsEmpty<TSource>(this IObservable<TSource> source);
	public static IObservable<TResult> Join<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left...);
    public static IObservable<long> LongCount<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
	public static IObservable<decimal?> Max(this IObservable<decimal?> source);
	public static IObservable<decimal> Min(this IObservable<decimal> source);
    public static IObservable<TResult> OfType<TResult>(this IObservable<object> source);
	public static IObservable<int> Range(int start, int count, IScheduler scheduler);
	public static IObservable<TSource> Repeat<TSource>(this IObservable<TSource> source, int repeatCount);
    public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, TResult> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
    public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IObservable<TSource> second, IEqualityComparer<TSource> comparer);
    public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
	public static IObservable<decimal?> Sum(this IObservable<decimal?> source);
	public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<TSource> TakeWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
	public static IObservable<TSource[]> ToArray<TSource>(this IObservable<TSource> source);
	public static IObservable<IDictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
	public static IObservable<IList<TSource>> ToList<TSource>(this IObservable<TSource> source);
    public static IObservable<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
	public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
	public static IObservable<IList<TSource>> Zip<TSource>(this IEnumerable<IObservable<TSource>> sources);

	// 6 more operators that were on IEnumerable but that block and are greedy
	public static TSource First<TSource>(this IObservable<TSource> source);
	public static TSource FirstOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);	
	public static TSource Last<TSource>(this IObservable<TSource> source);
    public static TSource LastOrDefault<TSource>(this IObservable<TSource> source);
	public static TSource Single<TSource>(this IObservable<TSource> source);
    public static TSource SingleOrDefault<TSource>(this IObservable<TSource> source);
    
	// 2 house-keeping or administrative methods
	public static IEnumerator<TSource> GetEnumerator<TSource>(this IObservable<TSource> source);
	public static IEnumerable<TSource> ToEnumerable<TSource>(this IObservable<TSource> source);
}