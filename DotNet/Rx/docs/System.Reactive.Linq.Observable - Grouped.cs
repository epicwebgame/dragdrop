public static class Observable
{
    // Fields
    private static IQueryLanguage s_impl;

    // cctor
    static Observable();
	
	// Operators
    public static IObservable<TSource> Aggregate<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator);
    public static IObservable<TAccumulate> Aggregate<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator);
    public static IObservable<TResult> Aggregate<TSource, TAccumulate, TResult>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, TResult> resultSelector);
    
	
	public static IObservable<bool> All<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TSource> Amb<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TSource> Amb<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<TSource> Amb<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    
	
	public static Pattern<TLeft, TRight> And<TLeft, TRight>(this IObservable<TLeft> left, IObservable<TRight> right);
    
	
	public static IObservable<bool> Any<TSource>(this IObservable<TSource> source);
    public static IObservable<bool> Any<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	public static IObservable<TSource> AsObservable<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<decimal?> Average(this IObservable<decimal?> source);
    public static IObservable<double?> Average(this IObservable<int?> source);
    public static IObservable<decimal> Average(this IObservable<decimal> source);
    public static IObservable<double> Average(this IObservable<double> source);
    public static IObservable<double> Average(this IObservable<int> source);
    public static IObservable<double?> Average(this IObservable<double?> source);
    public static IObservable<double> Average(this IObservable<long> source);
    public static IObservable<double?> Average(this IObservable<long?> source);
    public static IObservable<float?> Average(this IObservable<float?> source);
    public static IObservable<float> Average(this IObservable<float> source);
    public static IObservable<decimal?> Average<TSource>(this IObservable<TSource> source, Func<TSource, decimal?> selector);
    public static IObservable<double?> Average<TSource>(this IObservable<TSource> source, Func<TSource, double?> selector);
    public static IObservable<double?> Average<TSource>(this IObservable<TSource> source, Func<TSource, int?> selector);
    public static IObservable<double> Average<TSource>(this IObservable<TSource> source, Func<TSource, int> selector);
    public static IObservable<double?> Average<TSource>(this IObservable<TSource> source, Func<TSource, long?> selector);
    public static IObservable<decimal> Average<TSource>(this IObservable<TSource> source, Func<TSource, decimal> selector);
    public static IObservable<float?> Average<TSource>(this IObservable<TSource> source, Func<TSource, float?> selector);
    public static IObservable<double> Average<TSource>(this IObservable<TSource> source, Func<TSource, double> selector);
    public static IObservable<double> Average<TSource>(this IObservable<TSource> source, Func<TSource, long> selector);
    public static IObservable<float> Average<TSource>(this IObservable<TSource> source, Func<TSource, float> selector);
    
	
	public static IObservable<IList<TSource>> Buffer<TSource, TBufferClosing>(this IObservable<TSource> source, Func<IObservable<TBufferClosing>> bufferClosingSelector);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<IList<TSource>> Buffer<TSource, TBufferBoundary>(this IObservable<TSource> source, IObservable<TBufferBoundary> bufferBoundaries);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan);
    public static IObservable<IList<TSource>> Buffer<TSource, TBufferOpening, TBufferClosing>(this IObservable<TSource> source, IObservable<TBufferOpening> bufferOpenings, Func<TBufferOpening, IObservable<TBufferClosing>> bufferClosingSelector);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, int count, int skip);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, IScheduler scheduler);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count, IScheduler scheduler);
    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift, IScheduler scheduler);
    
	
	public static IObservable<TResult> Case<TValue, TResult>(Func<TValue> selector, IDictionary<TValue, IObservable<TResult>> sources);
    public static IObservable<TResult> Case<TValue, TResult>(Func<TValue> selector, IDictionary<TValue, IObservable<TResult>> sources, IObservable<TResult> defaultSource);
    public static IObservable<TResult> Case<TValue, TResult>(Func<TValue> selector, IDictionary<TValue, IObservable<TResult>> sources, IScheduler scheduler);
    
	
	public static IObservable<TResult> Cast<TResult>(this IObservable<object> source);
    
	public static IObservable<TSource> Catch<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TSource> Catch<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<TSource> Catch<TSource, TException>(this IObservable<TSource> source, Func<TException, IObservable<TSource>> handler) where TException: Exception;
    public static IObservable<TSource> Catch<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    
	
	public static IEnumerable<IList<TSource>> Chunkify<TSource>(this IObservable<TSource> source);
    
	
	public static IEnumerable<TResult> Collect<TSource, TResult>(this IObservable<TSource> source, Func<TResult> newCollector, Func<TResult, TSource, TResult> merge);
    public static IEnumerable<TResult> Collect<TSource, TResult>(this IObservable<TSource> source, Func<TResult> getInitialCollector, Func<TResult, TSource, TResult> merge, Func<TResult, TResult> getNewCollector);
    
	
	public static IObservable<IList<TSource>> CombineLatest<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<IList<TSource>> CombineLatest<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TResult> CombineLatest<TSource, TResult>(this IEnumerable<IObservable<TSource>> sources, Func<IList<TSource>, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TResult>(this IObservable<TSource1> first, IObservable<TSource2> second, Func<TSource1, TSource2, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, Func<TSource1, TSource2, TSource3, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, Func<TSource1, TSource2, TSource3, TSource4, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, IObservable<TSource14> source14, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, IObservable<TSource14> source14, IObservable<TSource15> source15, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TResult> resultSelector);
    public static IObservable<TResult> CombineLatest<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, IObservable<TSource14> source14, IObservable<TSource15> source15, IObservable<TSource16> source16, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16, TResult> resultSelector);
    
	
	public static IObservable<TSource> Concat<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TSource> Concat<TSource>(this IObservable<IObservable<TSource>> sources);
    public static IObservable<TSource> Concat<TSource>(this IObservable<Task<TSource>> sources);
    public static IObservable<TSource> Concat<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<TSource> Concat<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    
	
	public static IObservable<bool> Contains<TSource>(this IObservable<TSource> source, TSource value);
    public static IObservable<bool> Contains<TSource>(this IObservable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
    
	
	public static IObservable<int> Count<TSource>(this IObservable<TSource> source);
    public static IObservable<int> Count<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, IDisposable> subscribe);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, Task<Action>> subscribeAsync);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, Task<IDisposable>> subscribeAsync);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, Action> subscribe);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, Task> subscribeAsync);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, CancellationToken, Task<Action>> subscribeAsync);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, CancellationToken, Task<IDisposable>> subscribeAsync);
    public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, CancellationToken, Task> subscribeAsync);
    
	
	public static IObservable<TSource> DefaultIfEmpty<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> DefaultIfEmpty<TSource>(this IObservable<TSource> source, TSource defaultValue);
    
	
	public static IObservable<TResult> Defer<TResult>(Func<IObservable<TResult>> observableFactory);
    public static IObservable<TResult> Defer<TResult>(Func<Task<IObservable<TResult>>> observableFactoryAsync);
    public static IObservable<TResult> DeferAsync<TResult>(Func<CancellationToken, Task<IObservable<TResult>>> observableFactoryAsync);
    
	
	public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime);
    public static IObservable<TSource> Delay<TSource, TDelay>(this IObservable<TSource> source, Func<TSource, IObservable<TDelay>> delayDurationSelector);
    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime);
    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IScheduler scheduler);
    public static IObservable<TSource> Delay<TSource, TDelay>(this IObservable<TSource> source, IObservable<TDelay> subscriptionDelay, Func<TSource, IObservable<TDelay>> delayDurationSelector);
    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    
	
	public static IObservable<TSource> DelaySubscription<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime);
    public static IObservable<TSource> DelaySubscription<TSource>(this IObservable<TSource> source, TimeSpan dueTime);
    public static IObservable<TSource> DelaySubscription<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IScheduler scheduler);
    public static IObservable<TSource> DelaySubscription<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    
	
	public static IObservable<TSource> Dematerialize<TSource>(this IObservable<Notification<TSource>> source);
    
	
	public static IObservable<TSource> Distinct<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> Distinct<TSource>(this IObservable<TSource> source, IEqualityComparer<TSource> comparer);
    public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    
	
	public static IObservable<TSource> DistinctUntilChanged<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> DistinctUntilChanged<TSource>(this IObservable<TSource> source, IEqualityComparer<TSource> comparer);
    public static IObservable<TSource> DistinctUntilChanged<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<TSource> DistinctUntilChanged<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    
	
	public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext);
    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, IObserver<TSource> observer);
    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action onCompleted);
    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action<Exception> onError);
    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted);
    
	
	public static IObservable<TSource> DoWhile<TSource>(this IObservable<TSource> source, Func<bool> condition);
    
	
	public static IObservable<TSource> ElementAt<TSource>(this IObservable<TSource> source, int index);
    
	public static IObservable<TSource> ElementAtOrDefault<TSource>(this IObservable<TSource> source, int index);
    
	
	public static IObservable<TResult> Empty<TResult>();
    public static IObservable<TResult> Empty<TResult>(TResult witness);
    public static IObservable<TResult> Empty<TResult>(IScheduler scheduler);
    public static IObservable<TResult> Empty<TResult>(IScheduler scheduler, TResult witness);
    
	
	public static IObservable<TSource> Finally<TSource>(this IObservable<TSource> source, Action finallyAction);
    
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource First<TSource>(this IObservable<TSource> source);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource First<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	public static IObservable<TSource> FirstAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> FirstAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource FirstOrDefault<TSource>(this IObservable<TSource> source);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource FirstOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TSource> FirstOrDefaultAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> FirstOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TResult> For<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IObservable<TResult>> resultSelector);
    
	
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static void ForEach<TSource>(this IObservable<TSource> source, Action<TSource> onNext);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static void ForEach<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext);
    
	
	
	public static Task ForEachAsync<TSource>(this IObservable<TSource> source, Action<TSource> onNext);
    public static Task ForEachAsync<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext);
    public static Task ForEachAsync<TSource>(this IObservable<TSource> source, Action<TSource> onNext, CancellationToken cancellationToken);
    public static Task ForEachAsync<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext, CancellationToken cancellationToken);
    
	
	public static IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync);
    public static IObservable<Unit> FromAsync(Func<Task> actionAsync);
    public static IObservable<Unit> FromAsync(Func<CancellationToken, Task> actionAsync);
    public static IObservable<TResult> FromAsync<TResult>(Func<CancellationToken, Task<TResult>> functionAsync);
    
	
	
	[Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<IObservable<Unit>> FromAsyncPattern(Func<AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<IObservable<TResult>> FromAsyncPattern<TResult>(Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, IObservable<Unit>> FromAsyncPattern<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, IObservable<TResult>> FromAsyncPattern<TArg1, TResult>(Func<TArg1, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TResult>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, IObservable<Unit>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    [Obsolete("This conversion is no longer supported. Replace use of the Begin/End asynchronous method pair with a new Task-based async method, and convert the result using ToObservable. If no Task-based async method is available, use Task.Factory.FromAsync to obtain a Task object. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, IObservable<TResult>> FromAsyncPattern<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end);
    
	
	
	
	public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler);
    public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler);
    public static IObservable<TEventArgs> FromEvent<TEventArgs>(Action<Action<TEventArgs>> addHandler, Action<Action<TEventArgs>> removeHandler);
    public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler);
    public static IObservable<TEventArgs> FromEvent<TEventArgs>(Action<Action<TEventArgs>> addHandler, Action<Action<TEventArgs>> removeHandler, IScheduler scheduler);
    public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler, IScheduler scheduler);
    public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler);
    public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler);
    
	
	
	public static IObservable<EventPattern<object>> FromEventPattern(Action<EventHandler> addHandler, Action<EventHandler> removeHandler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler);
    public static IObservable<EventPattern<TSender, TEventArgs>> FromEventPattern<TDelegate, TSender, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler);
    public static IObservable<EventPattern<object>> FromEventPattern(object target, string eventName);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(object target, string eventName);
    public static IObservable<EventPattern<TSender, TEventArgs>> FromEventPattern<TSender, TEventArgs>(object target, string eventName);
    public static IObservable<EventPattern<object>> FromEventPattern(Type type, string eventName);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Type type, string eventName);
    public static IObservable<EventPattern<TSender, TEventArgs>> FromEventPattern<TSender, TEventArgs>(Type type, string eventName);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler);
    public static IObservable<EventPattern<object>> FromEventPattern(Action<EventHandler> addHandler, Action<EventHandler> removeHandler, IScheduler scheduler);
    public static IObservable<EventPattern<TSender, TEventArgs>> FromEventPattern<TDelegate, TSender, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler, IScheduler scheduler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Func<EventHandler<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(object target, string eventName, IScheduler scheduler);
    public static IObservable<EventPattern<object>> FromEventPattern(object target, string eventName, IScheduler scheduler);
    public static IObservable<EventPattern<TSender, TEventArgs>> FromEventPattern<TSender, TEventArgs>(object target, string eventName, IScheduler scheduler);
    public static IObservable<EventPattern<object>> FromEventPattern(Type type, string eventName, IScheduler scheduler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Type type, string eventName, IScheduler scheduler);
    public static IObservable<EventPattern<TSender, TEventArgs>> FromEventPattern<TSender, TEventArgs>(Type type, string eventName, IScheduler scheduler);
    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Func<EventHandler<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler);
    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector);
    
	
	
	public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, DateTimeOffset> timeSelector);
    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, TimeSpan> timeSelector);
    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, IScheduler scheduler);
    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, DateTimeOffset> timeSelector, IScheduler scheduler);
    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, TimeSpan> timeSelector, IScheduler scheduler);
    
	
	public static AsyncSubject<TSource> GetAwaiter<TSource>(this IObservable<TSource> source);
    public static AsyncSubject<TSource> GetAwaiter<TSource>(this IConnectableObservable<TSource> source);
    
	public static IEnumerator<TSource> GetEnumerator<TSource>(this IObservable<TSource> source);
    
	public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, int capacity);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, int capacity);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, int capacity, IEqualityComparer<TKey> comparer);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, int capacity, IEqualityComparer<TKey> comparer);
    
	
	public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupByUntil<TSource, TKey, TElement, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<IGroupedObservable<TKey, TElement>, IObservable<TDuration>> durationSelector);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector, IEqualityComparer<TKey> comparer);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector, int capacity);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupByUntil<TSource, TKey, TElement, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<IGroupedObservable<TKey, TElement>, IObservable<TDuration>> durationSelector, int capacity);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector, int capacity, IEqualityComparer<TKey> comparer);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupByUntil<TSource, TKey, TElement, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<IGroupedObservable<TKey, TElement>, IObservable<TDuration>> durationSelector, IEqualityComparer<TKey> comparer);
    public static IObservable<IGroupedObservable<TKey, TElement>> GroupByUntil<TSource, TKey, TElement, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<IGroupedObservable<TKey, TElement>, IObservable<TDuration>> durationSelector, int capacity, IEqualityComparer<TKey> comparer);
    
	
	public static IObservable<TResult> GroupJoin<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, IObservable<TLeftDuration>> leftDurationSelector, Func<TRight, IObservable<TRightDuration>> rightDurationSelector, Func<TLeft, IObservable<TRight>, TResult> resultSelector);
    
	
	
	public static IObservable<TResult> If<TResult>(Func<bool> condition, IObservable<TResult> thenSource);
    public static IObservable<TResult> If<TResult>(Func<bool> condition, IObservable<TResult> thenSource, IObservable<TResult> elseSource);
    public static IObservable<TResult> If<TResult>(Func<bool> condition, IObservable<TResult> thenSource, IScheduler scheduler);
    
	
	public static IObservable<TSource> IgnoreElements<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<long> Interval(TimeSpan period);
    public static IObservable<long> Interval(TimeSpan period, IScheduler scheduler);
    
	
	public static IObservable<bool> IsEmpty<TSource>(this IObservable<TSource> source);
    public static IObservable<TResult> Join<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, IObservable<TLeftDuration>> leftDurationSelector, Func<TRight, IObservable<TRightDuration>> rightDurationSelector, Func<TLeft, TRight, TResult> resultSelector);
    
	
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource Last<TSource>(this IObservable<TSource> source);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource Last<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TSource> LastAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> LastAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource LastOrDefault<TSource>(this IObservable<TSource> source);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource LastOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	public static IObservable<TSource> LastOrDefaultAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> LastOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IEnumerable<TSource> Latest<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<long> LongCount<TSource>(this IObservable<TSource> source);
    public static IObservable<long> LongCount<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<Notification<TSource>> Materialize<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<decimal?> Max(this IObservable<decimal?> source);
    public static IObservable<double?> Max(this IObservable<double?> source);
    public static IObservable<decimal> Max(this IObservable<decimal> source);
    public static IObservable<double> Max(this IObservable<double> source);
    public static IObservable<TSource> Max<TSource>(this IObservable<TSource> source);
    public static IObservable<int> Max(this IObservable<int> source);
    public static IObservable<long> Max(this IObservable<long> source);
    public static IObservable<int?> Max(this IObservable<int?> source);
    public static IObservable<long?> Max(this IObservable<long?> source);
    public static IObservable<float?> Max(this IObservable<float?> source);
    public static IObservable<float> Max(this IObservable<float> source);
    public static IObservable<TSource> Max<TSource>(this IObservable<TSource> source, IComparer<TSource> comparer);
    public static IObservable<int?> Max<TSource>(this IObservable<TSource> source, Func<TSource, int?> selector);
    public static IObservable<TResult> Max<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);
    public static IObservable<decimal> Max<TSource>(this IObservable<TSource> source, Func<TSource, decimal> selector);
    public static IObservable<double> Max<TSource>(this IObservable<TSource> source, Func<TSource, double> selector);
    public static IObservable<long?> Max<TSource>(this IObservable<TSource> source, Func<TSource, long?> selector);
    public static IObservable<int> Max<TSource>(this IObservable<TSource> source, Func<TSource, int> selector);
    public static IObservable<decimal?> Max<TSource>(this IObservable<TSource> source, Func<TSource, decimal?> selector);
    public static IObservable<double?> Max<TSource>(this IObservable<TSource> source, Func<TSource, double?> selector);
    public static IObservable<float?> Max<TSource>(this IObservable<TSource> source, Func<TSource, float?> selector);
    public static IObservable<long> Max<TSource>(this IObservable<TSource> source, Func<TSource, long> selector);
    public static IObservable<float> Max<TSource>(this IObservable<TSource> source, Func<TSource, float> selector);
    public static IObservable<TResult> Max<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer);
    
	
	public static IObservable<IList<TSource>> MaxBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<IList<TSource>> MaxBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
    
	
	
	public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TSource> Merge<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<TSource> Merge<TSource>(this IObservable<IObservable<TSource>> sources);
    public static IObservable<TSource> Merge<TSource>(this IObservable<Task<TSource>> sources);
    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, int maxConcurrent);
    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, IScheduler scheduler);
    public static IObservable<TSource> Merge<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    public static IObservable<TSource> Merge<TSource>(this IObservable<IObservable<TSource>> sources, int maxConcurrent);
    public static IObservable<TSource> Merge<TSource>(IScheduler scheduler, params IObservable<TSource>[] sources);
    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, int maxConcurrent, IScheduler scheduler);
    public static IObservable<TSource> Merge<TSource>(this IObservable<TSource> first, IObservable<TSource> second, IScheduler scheduler);
    
	
	
	
	
	public static IObservable<decimal> Min(this IObservable<decimal> source);
    public static IObservable<double?> Min(this IObservable<double?> source);
    public static IObservable<float?> Min(this IObservable<float?> source);
    public static IObservable<double> Min(this IObservable<double> source);
    public static IObservable<decimal?> Min(this IObservable<decimal?> source);
    public static IObservable<int?> Min(this IObservable<int?> source);
    public static IObservable<TSource> Min<TSource>(this IObservable<TSource> source);
    public static IObservable<long?> Min(this IObservable<long?> source);
    public static IObservable<int> Min(this IObservable<int> source);
    public static IObservable<long> Min(this IObservable<long> source);
    public static IObservable<float> Min(this IObservable<float> source);
    public static IObservable<TSource> Min<TSource>(this IObservable<TSource> source, IComparer<TSource> comparer);
    public static IObservable<TResult> Min<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);
    public static IObservable<double?> Min<TSource>(this IObservable<TSource> source, Func<TSource, double?> selector);
    public static IObservable<double> Min<TSource>(this IObservable<TSource> source, Func<TSource, double> selector);
    public static IObservable<int> Min<TSource>(this IObservable<TSource> source, Func<TSource, int> selector);
    public static IObservable<decimal?> Min<TSource>(this IObservable<TSource> source, Func<TSource, decimal?> selector);
    public static IObservable<decimal> Min<TSource>(this IObservable<TSource> source, Func<TSource, decimal> selector);
    public static IObservable<long> Min<TSource>(this IObservable<TSource> source, Func<TSource, long> selector);
    public static IObservable<int?> Min<TSource>(this IObservable<TSource> source, Func<TSource, int?> selector);
    public static IObservable<long?> Min<TSource>(this IObservable<TSource> source, Func<TSource, long?> selector);
    public static IObservable<float?> Min<TSource>(this IObservable<TSource> source, Func<TSource, float?> selector);
    public static IObservable<float> Min<TSource>(this IObservable<TSource> source, Func<TSource, float> selector);
    public static IObservable<TResult> Min<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer);
    
	
	
	public static IObservable<IList<TSource>> MinBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<IList<TSource>> MinBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
    
	
	
	public static IEnumerable<TSource> MostRecent<TSource>(this IObservable<TSource> source, TSource initialValue);
    
	
	
	public static IConnectableObservable<TResult> Multicast<TSource, TResult>(this IObservable<TSource> source, ISubject<TSource, TResult> subject);
    public static IObservable<TResult> Multicast<TSource, TIntermediate, TResult>(this IObservable<TSource> source, Func<ISubject<TSource, TIntermediate>> subjectSelector, Func<IObservable<TIntermediate>, IObservable<TResult>> selector);
    
	
	
	public static IObservable<TResult> Never<TResult>();
    public static IObservable<TResult> Never<TResult>(TResult witness);
    
	
	
	public static IEnumerable<TSource> Next<TSource>(this IObservable<TSource> source);
    
	
	
	public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, SynchronizationContext context);
    
	
	public static IObservable<TResult> OfType<TResult>(this IObservable<object> source);
    
	
	public static IObservable<TSource> OnErrorResumeNext<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TSource> OnErrorResumeNext<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<TSource> OnErrorResumeNext<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    
	
	public static IConnectableObservable<TSource> Publish<TSource>(this IObservable<TSource> source);
    public static IConnectableObservable<TSource> Publish<TSource>(this IObservable<TSource> source, TSource initialValue);
    public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector);
    public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TSource initialValue);
    public static IConnectableObservable<TSource> PublishLast<TSource>(this IObservable<TSource> source);
    public static IObservable<TResult> PublishLast<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector);
    
	
	
	public static IObservable<int> Range(int start, int count);
    public static IObservable<int> Range(int start, int count, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> RefCount<TSource>(this IConnectableObservable<TSource> source);
    
	
	
	public static IObservable<TSource> Repeat<TSource>(this IObservable<TSource> source);
    public static IObservable<TResult> Repeat<TResult>(TResult value);
    public static IObservable<TResult> Repeat<TResult>(TResult value, IScheduler scheduler);
    public static IObservable<TSource> Repeat<TSource>(this IObservable<TSource> source, int repeatCount);
    public static IObservable<TResult> Repeat<TResult>(TResult value, int repeatCount);
    public static IObservable<TResult> Repeat<TResult>(TResult value, int repeatCount, IScheduler scheduler);
    
	
	
	public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, TimeSpan window);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, IScheduler scheduler);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TimeSpan window);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize, IScheduler scheduler);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize, TimeSpan window);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, TimeSpan window, IScheduler scheduler);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, IScheduler scheduler);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, TimeSpan window);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TimeSpan window, IScheduler scheduler);
    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize, TimeSpan window, IScheduler scheduler);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, TimeSpan window, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source, int retryCount);
    
	
	
	public static IObservable<TResult> Return<TResult>(TResult value);
    public static IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler);
    
	
	
	public static AsyncSubject<TSource> RunAsync<TSource>(this IObservable<TSource> source, CancellationToken cancellationToken);
    public static AsyncSubject<TSource> RunAsync<TSource>(this IConnectableObservable<TSource> source, CancellationToken cancellationToken);
    
	
	
	public static IObservable<TSource> Sample<TSource, TSample>(this IObservable<TSource> source, IObservable<TSample> sampler);
    public static IObservable<TSource> Sample<TSource>(this IObservable<TSource> source, TimeSpan interval);
    public static IObservable<TSource> Sample<TSource>(this IObservable<TSource> source, TimeSpan interval, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> Scan<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator);
    public static IObservable<TAccumulate> Scan<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator);
    
	
	
	public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);
    public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, TResult> selector);
    
	
	
	public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, Task<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, IObservable<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, Task<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, CancellationToken, Task<TResult>> selector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, CancellationToken, Task<TResult>> selector);
    public static IObservable<TOther> SelectMany<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other);
    public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TTaskResult, TResult>(this IObservable<TSource> source, Func<TSource, Task<TTaskResult>> taskSelector, Func<TSource, TTaskResult, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, int, IObservable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TTaskResult, TResult>(this IObservable<TSource> source, Func<TSource, int, Task<TTaskResult>> taskSelector, Func<TSource, int, TTaskResult, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TTaskResult, TResult>(this IObservable<TSource> source, Func<TSource, CancellationToken, Task<TTaskResult>> taskSelector, Func<TSource, TTaskResult, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TTaskResult, TResult>(this IObservable<TSource> source, Func<TSource, int, CancellationToken, Task<TTaskResult>> taskSelector, Func<TSource, int, TTaskResult, TResult> resultSelector);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> onNext, Func<Exception, IObservable<TResult>> onError, Func<IObservable<TResult>> onCompleted);
    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, IObservable<TResult>> onNext, Func<Exception, IObservable<TResult>> onError, Func<IObservable<TResult>> onCompleted);
    
	
	
	
	public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IEnumerable<TSource> second);
    public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
    public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IObservable<TSource> second, IEqualityComparer<TSource> comparer);
    
	
	
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource Single<TSource>(this IObservable<TSource> source);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource Single<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	public static IObservable<TSource> SingleAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> SingleAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource SingleOrDefault<TSource>(this IObservable<TSource> source);
    [Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource SingleOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	
	public static IObservable<TSource> SingleOrDefaultAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> SingleOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	
	public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, TimeSpan duration);
    public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> SkipLast<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<TSource> SkipLast<TSource>(this IObservable<TSource> source, TimeSpan duration);
    public static IObservable<TSource> SkipLast<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> SkipUntil<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other);
    public static IObservable<TSource> SkipUntil<TSource>(this IObservable<TSource> source, DateTimeOffset startTime);
    public static IObservable<TSource> SkipUntil<TSource>(this IObservable<TSource> source, DateTimeOffset startTime, IScheduler scheduler);
    public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
    
	
	
	public static IObservable<Unit> Start(Action action);
    public static IObservable<TResult> Start<TResult>(Func<TResult> function);
    public static IObservable<TResult> Start<TResult>(Func<TResult> function, IScheduler scheduler);
    public static IObservable<Unit> Start(Action action, IScheduler scheduler);
    
	
	
	public static IObservable<Unit> StartAsync(Func<Task> actionAsync);
    public static IObservable<TResult> StartAsync<TResult>(Func<Task<TResult>> functionAsync);
    public static IObservable<TResult> StartAsync<TResult>(Func<CancellationToken, Task<TResult>> functionAsync);
    public static IObservable<Unit> StartAsync(Func<CancellationToken, Task> actionAsync);
    
	
	
	public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, IEnumerable<TSource> values);
    public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, params TSource[] values);
    public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, IScheduler scheduler, params TSource[] values);
    public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, IScheduler scheduler, IEnumerable<TSource> values);
    
	
	
	public static IDisposable Subscribe<TSource>(this IEnumerable<TSource> source, IObserver<TSource> observer);
    public static IDisposable Subscribe<TSource>(this IEnumerable<TSource> source, IObserver<TSource> observer, IScheduler scheduler);
    public static IObservable<TSource> SubscribeOn<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    public static IObservable<TSource> SubscribeOn<TSource>(this IObservable<TSource> source, SynchronizationContext context);
    
	
	
	public static IObservable<decimal?> Sum(this IObservable<decimal?> source);
    public static IObservable<double?> Sum(this IObservable<double?> source);
    public static IObservable<int?> Sum(this IObservable<int?> source);
    public static IObservable<long?> Sum(this IObservable<long?> source);
    public static IObservable<float?> Sum(this IObservable<float?> source);
    public static IObservable<decimal> Sum(this IObservable<decimal> source);
    public static IObservable<double> Sum(this IObservable<double> source);
    public static IObservable<int> Sum(this IObservable<int> source);
    public static IObservable<long> Sum(this IObservable<long> source);
    public static IObservable<float> Sum(this IObservable<float> source);
    public static IObservable<decimal?> Sum<TSource>(this IObservable<TSource> source, Func<TSource, decimal?> selector);
    public static IObservable<double?> Sum<TSource>(this IObservable<TSource> source, Func<TSource, double?> selector);
    public static IObservable<int?> Sum<TSource>(this IObservable<TSource> source, Func<TSource, int?> selector);
    public static IObservable<long?> Sum<TSource>(this IObservable<TSource> source, Func<TSource, long?> selector);
    public static IObservable<long> Sum<TSource>(this IObservable<TSource> source, Func<TSource, long> selector);
    public static IObservable<double> Sum<TSource>(this IObservable<TSource> source, Func<TSource, double> selector);
    public static IObservable<float?> Sum<TSource>(this IObservable<TSource> source, Func<TSource, float?> selector);
    public static IObservable<decimal> Sum<TSource>(this IObservable<TSource> source, Func<TSource, decimal> selector);
    public static IObservable<int> Sum<TSource>(this IObservable<TSource> source, Func<TSource, int> selector);
    public static IObservable<float> Sum<TSource>(this IObservable<TSource> source, Func<TSource, float> selector);
    
	
	
	
	public static IObservable<TSource> Switch<TSource>(this IObservable<IObservable<TSource>> sources);
    public static IObservable<TSource> Switch<TSource>(this IObservable<Task<TSource>> sources);
    
	
	
	
	public static IObservable<TSource> Synchronize<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> Synchronize<TSource>(this IObservable<TSource> source, object gate);
    
	
	
	
	public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, TimeSpan duration);
    public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, int count, IScheduler scheduler);
    public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, TimeSpan duration);
    public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, int count, IScheduler scheduler);
    public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler timerScheduler, IScheduler loopScheduler);
    
	
	
	
	public static IObservable<IList<TSource>> TakeLastBuffer<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<IList<TSource>> TakeLastBuffer<TSource>(this IObservable<TSource> source, TimeSpan duration);
    public static IObservable<IList<TSource>> TakeLastBuffer<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource> TakeUntil<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other);
    public static IObservable<TSource> TakeUntil<TSource>(this IObservable<TSource> source, DateTimeOffset endTime);
    public static IObservable<TSource> TakeUntil<TSource>(this IObservable<TSource> source, DateTimeOffset endTime, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource> TakeWhile<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<TSource> TakeWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
    
	
	
	
	public static Plan<TResult> Then<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);
    
	
	
	
	public static IObservable<TSource> Throttle<TSource, TThrottle>(this IObservable<TSource> source, Func<TSource, IObservable<TThrottle>> throttleDurationSelector);
    public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime);
    public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    
	
	
	
	public static IObservable<TResult> Throw<TResult>(Exception exception);
    public static IObservable<TResult> Throw<TResult>(Exception exception, IScheduler scheduler);
    public static IObservable<TResult> Throw<TResult>(Exception exception, TResult witness);
    public static IObservable<TResult> Throw<TResult>(Exception exception, IScheduler scheduler, TResult witness);
    
	
	
	
	public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source);
    public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime);
    public static IObservable<TSource> Timeout<TSource, TTimeout>(this IObservable<TSource> source, Func<TSource, IObservable<TTimeout>> timeoutDurationSelector);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime);
    public static IObservable<TSource> Timeout<TSource, TTimeout>(this IObservable<TSource> source, Func<TSource, IObservable<TTimeout>> timeoutDurationSelector, IObservable<TSource> other);
    public static IObservable<TSource> Timeout<TSource, TTimeout>(this IObservable<TSource> source, IObservable<TTimeout> firstTimeout, Func<TSource, IObservable<TTimeout>> timeoutDurationSelector);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IObservable<TSource> other);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IScheduler scheduler);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IObservable<TSource> other);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    public static IObservable<TSource> Timeout<TSource, TTimeout>(this IObservable<TSource> source, IObservable<TTimeout> firstTimeout, Func<TSource, IObservable<TTimeout>> timeoutDurationSelector, IObservable<TSource> other);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IObservable<TSource> other, IScheduler scheduler);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IObservable<TSource> other, IScheduler scheduler);
    
	
	
	
	public static IObservable<long> Timer(DateTimeOffset dueTime);
    public static IObservable<long> Timer(TimeSpan dueTime);
    public static IObservable<long> Timer(DateTimeOffset dueTime, IScheduler scheduler);
    public static IObservable<long> Timer(DateTimeOffset dueTime, TimeSpan period);
    public static IObservable<long> Timer(TimeSpan dueTime, IScheduler scheduler);
    public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period);
    public static IObservable<long> Timer(DateTimeOffset dueTime, TimeSpan period, IScheduler scheduler);
    public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period, IScheduler scheduler);
    
	
	
	
	public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source);
    public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource[]> ToArray<TSource>(this IObservable<TSource> source);
    
	
	
	
	public static Func<TArg1, IObservable<Unit>> ToAsync<TArg1>(this Action<TArg1> action);
    public static Func<TArg1, TArg2, IObservable<Unit>> ToAsync<TArg1, TArg2>(this Action<TArg1, TArg2> action);
    public static Func<TArg1, TArg2, TArg3, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3>(this Action<TArg1, TArg2, TArg3> action);
    public static Func<IObservable<Unit>> ToAsync(this Action action);
    public static Func<TArg1, TArg2, TArg3, TArg4, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4>(this Action<TArg1, TArg2, TArg3, TArg4> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> action);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16> action);
    public static Func<IObservable<TResult>> ToAsync<TResult>(this Func<TResult> function);
    public static Func<TArg1, IObservable<TResult>> ToAsync<TArg1, TResult>(this Func<TArg1, TResult> function);
    public static Func<TArg1, TArg2, IObservable<TResult>> ToAsync<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> function);
    public static Func<TArg1, TArg2, TArg3, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TResult>(this Func<TArg1, TArg2, TArg3, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> function);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> function);
    public static Func<TArg1, IObservable<Unit>> ToAsync<TArg1>(this Action<TArg1> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, IObservable<Unit>> ToAsync<TArg1, TArg2>(this Action<TArg1, TArg2> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3>(this Action<TArg1, TArg2, TArg3> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4>(this Action<TArg1, TArg2, TArg3, TArg4> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, IObservable<Unit>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>(this Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16> action, IScheduler scheduler);
    public static Func<IObservable<TResult>> ToAsync<TResult>(this Func<TResult> function, IScheduler scheduler);
    public static Func<TArg1, IObservable<TResult>> ToAsync<TArg1, TResult>(this Func<TArg1, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, IObservable<TResult>> ToAsync<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TResult>(this Func<TArg1, TArg2, TArg3, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> function, IScheduler scheduler);
    public static Func<IObservable<Unit>> ToAsync(this Action action, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> function, IScheduler scheduler);
    public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, IObservable<TResult>> ToAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> function, IScheduler scheduler);
    
	
	
	
	
	public static IObservable<IDictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<IDictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    public static IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
    public static IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
    
	
	
	
	public static IEnumerable<TSource> ToEnumerable<TSource>(this IObservable<TSource> source);
    
	
	
	
	public static IEventSource<TSource> ToEvent<TSource>(this IObservable<TSource> source);
    public static IEventSource<Unit> ToEvent(this IObservable<Unit> source);
    
	
	
	
	public static IEventPatternSource<TEventArgs> ToEventPattern<TEventArgs>(this IObservable<EventPattern<TEventArgs>> source);
    
	
	
	
	public static IObservable<IList<TSource>> ToList<TSource>(this IObservable<TSource> source);
    
	
	
	
	public static IObservable<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    public static IObservable<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    public static IObservable<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
    public static IObservable<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
    
	
	
	
	public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source);
    public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source, IScheduler scheduler);
    
	
	
	
	public static IObservable<TResult> Using<TResult, TResource>(Func<TResource> resourceFactory, Func<TResource, IObservable<TResult>> observableFactory) where TResource: IDisposable;
    public static IObservable<TResult> Using<TResult, TResource>(Func<CancellationToken, Task<TResource>> resourceFactoryAsync, Func<TResource, CancellationToken, Task<IObservable<TResult>>> observableFactoryAsync) where TResource: IDisposable;
    
	
	
	
	public static TSource Wait<TSource>(this IObservable<TSource> source);
    
	
	
	
	public static IObservable<TResult> When<TResult>(params Plan<TResult>[] plans);
    public static IObservable<TResult> When<TResult>(this IEnumerable<Plan<TResult>> plans);
    
	
	
	
	public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
    
	
	
	
	public static IObservable<TSource> While<TSource>(Func<bool> condition, IObservable<TSource> source);
    
	
	
	
	public static IObservable<IObservable<TSource>> Window<TSource, TWindowClosing>(this IObservable<TSource> source, Func<IObservable<TWindowClosing>> windowClosingSelector);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<IObservable<TSource>> Window<TSource, TWindowBoundary>(this IObservable<TSource> source, IObservable<TWindowBoundary> windowBoundaries);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, int count, int skip);
    public static IObservable<IObservable<TSource>> Window<TSource, TWindowOpening, TWindowClosing>(this IObservable<TSource> source, IObservable<TWindowOpening> windowOpenings, Func<TWindowOpening, IObservable<TWindowClosing>> windowClosingSelector);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, IScheduler scheduler);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count, IScheduler scheduler);
    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift, IScheduler scheduler);
    
	
	
	
	public static IObservable<IList<TSource>> Zip<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<IList<TSource>> Zip<TSource>(params IObservable<TSource>[] sources);
    public static IObservable<TResult> Zip<TSource, TResult>(this IEnumerable<IObservable<TSource>> sources, Func<IList<TSource>, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TResult>(this IObservable<TSource1> first, IEnumerable<TSource2> second, Func<TSource1, TSource2, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TResult>(this IObservable<TSource1> first, IObservable<TSource2> second, Func<TSource1, TSource2, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, Func<TSource1, TSource2, TSource3, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, Func<TSource1, TSource2, TSource3, TSource4, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, IObservable<TSource14> source14, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, IObservable<TSource14> source14, IObservable<TSource15> source15, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TResult> resultSelector);
    public static IObservable<TResult> Zip<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16, TResult>(this IObservable<TSource1> source1, IObservable<TSource2> source2, IObservable<TSource3> source3, IObservable<TSource4> source4, IObservable<TSource5> source5, IObservable<TSource6> source6, IObservable<TSource7> source7, IObservable<TSource8> source8, IObservable<TSource9> source9, IObservable<TSource10> source10, IObservable<TSource11> source11, IObservable<TSource12> source12, IObservable<TSource13> source13, IObservable<TSource14> source14, IObservable<TSource15> source15, IObservable<TSource16> source16, Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16, TResult> resultSelector);
}