public static class Observable
{
    // Fields
    private static IQueryLanguage s_impl;

    // cctor
    static Observable();
	
	// Operators
    public static IObservable<TSource> Aggregate<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator);
    
	
	public static IObservable<bool> All<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TSource> Amb<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    
	
	public static Pattern<TLeft, TRight> And<TLeft, TRight>(this IObservable<TLeft> left, IObservable<TRight> right);
    
	
	public static IObservable<bool> Any<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	public static IObservable<TSource> AsObservable<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<double?> Average<TSource>(this IObservable<TSource> source, Func<TSource, int?> selector);
    
	
	public static IObservable<IList<TSource>> Buffer<TSource, TBufferClosing>(this IObservable<TSource> source, Func<IObservable<TBufferClosing>> bufferClosingSelector);
    
	
	public static IObservable<TResult> Case<TValue, TResult>(Func<TValue> selector, IDictionary<TValue, IObservable<TResult>> sources, IScheduler scheduler);
    
	
	public static IObservable<TResult> Cast<TResult>(this IObservable<object> source);
    
	public static IObservable<TSource> Catch<TSource>(this IEnumerable<IObservable<TSource>> sources);
    public static IObservable<TSource> Catch<TSource, TException>(this IObservable<TSource> source, Func<TException, IObservable<TSource>> handler) where TException: Exception;
    
	
	public static IEnumerable<IList<TSource>> Chunkify<TSource>(this IObservable<TSource> source);
    
	
	public static IEnumerable<TResult> Collect<TSource, TResult>(this IObservable<TSource> source, Func<TResult> getInitialCollector, Func<TResult, TSource, TResult> merge, Func<TResult, TResult> getNewCollector);
    
	
	public static IObservable<IList<TSource>> CombineLatest<TSource>(params IObservable<TSource>[] sources);
    
	
	public static IObservable<TSource> Concat<TSource>(this IEnumerable<IObservable<TSource>> sources);
    
	public static IObservable<bool> Contains<TSource>(this IObservable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
    
	
	public static IObservable<int> Count<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, IDisposable> subscribe);
    
	
	public static IObservable<TSource> DefaultIfEmpty<TSource>(this IObservable<TSource> source, TSource defaultValue);
    
	
	public static IObservable<TResult> DeferAsync<TResult>(Func<CancellationToken, Task<IObservable<TResult>>> observableFactoryAsync);
    
	
	public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    
	
	public static IObservable<TSource> DelaySubscription<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    
	
	public static IObservable<TSource> Dematerialize<TSource>(this IObservable<Notification<TSource>> source);
    
	
	public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    
	
	public static IObservable<TSource> DistinctUntilChanged<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
    
	
	public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted);
    
	
	public static IObservable<TSource> DoWhile<TSource>(this IObservable<TSource> source, Func<bool> condition);
    
	
	public static IObservable<TSource> ElementAt<TSource>(this IObservable<TSource> source, int index);
    
	public static IObservable<TSource> ElementAtOrDefault<TSource>(this IObservable<TSource> source, int index);
    
	
	public static IObservable<TResult> Empty<TResult>(IScheduler scheduler, TResult witness);
    
	
	public static IObservable<TSource> Finally<TSource>(this IObservable<TSource> source, Action finallyAction);
    
	
	[Obsolete("This blocking operation is no longer supported. Instead, use the async version in combination with C# and Visual Basic async/await support. In case you need a blocking operation, use Wait or convert the resulting observable sequence to a Task object and block. See http://go.microsoft.com/fwlink/?LinkID=260866 for more information.")]
    public static TSource First<TSource>(this IObservable<TSource> source);
    
	
	
	public static IObservable<TSource> FirstAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	[Obsolete]
	public static TSource FirstOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TSource> FirstOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<TResult> For<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IObservable<TResult>> resultSelector);
    
	
	
	[Obsolete]
    public static void ForEach<TSource>(this IObservable<TSource> source, Action<TSource> onNext);
    public static void ForEach<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext);
    
	
	public static Task ForEachAsync<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext, CancellationToken cancellationToken);
    
	
	public static IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync);
    
	
	
	[Obsolete]
    public static Func<IObservable<Unit>> FromAsyncPattern(Func<AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    
	
	public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler);
    
	
	public static IObservable<EventPattern<object>> FromEventPattern(Action<EventHandler> addHandler, Action<EventHandler> removeHandler);
    
	
	public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector);
    
	
	public static AsyncSubject<TSource> GetAwaiter<TSource>(this IObservable<TSource> source);
    public static AsyncSubject<TSource> GetAwaiter<TSource>(this IConnectableObservable<TSource> source);
    
	public static IEnumerator<TSource> GetEnumerator<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
    
	
	public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector);
    
	
	public static IObservable<TResult> GroupJoin<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, IObservable<TLeftDuration>> leftDurationSelector, Func<TRight, IObservable<TRightDuration>> rightDurationSelector, Func<TLeft, IObservable<TRight>, TResult> resultSelector);
    
	
	public static IObservable<TResult> If<TResult>(Func<bool> condition, IObservable<TResult> thenSource, IScheduler scheduler);
    
	
	public static IObservable<TSource> IgnoreElements<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<long> Interval(TimeSpan period, IScheduler scheduler);
    
	
	public static IObservable<bool> IsEmpty<TSource>(this IObservable<TSource> source);
    
	public static IObservable<TResult> Join<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, IObservable<TLeftDuration>> leftDurationSelector, Func<TRight, IObservable<TRightDuration>> rightDurationSelector, Func<TLeft, TRight, TResult> resultSelector);
    
	
	
	[Obsolete]
    public static TSource Last<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<TSource> LastAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	[Obsolete]
    public static TSource LastOrDefault<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<TSource> LastOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IEnumerable<TSource> Latest<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<long> LongCount<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	public static IObservable<Notification<TSource>> Materialize<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<decimal?> Max(this IObservable<decimal?> source);
    
	
	public static IObservable<IList<TSource>> MaxBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
    
	
	
	public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources);
    
	
	
	public static IObservable<decimal> Min(this IObservable<decimal> source);
    
	
	public static IObservable<IList<TSource>> MinBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
    
	
	
	public static IEnumerable<TSource> MostRecent<TSource>(this IObservable<TSource> source, TSource initialValue);
    
	
	
	public static IConnectableObservable<TResult> Multicast<TSource, TResult>(this IObservable<TSource> source, ISubject<TSource, TResult> subject);
	
	
	public static IObservable<TResult> Never<TResult>(TResult witness);
    
	
	
	public static IEnumerable<TSource> Next<TSource>(this IObservable<TSource> source);
    
	
	
	public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, SynchronizationContext context);
    
	
	public static IObservable<TResult> OfType<TResult>(this IObservable<object> source);
    
	
	public static IObservable<TSource> OnErrorResumeNext<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
    
	
	public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TSource initialValue);
    
	
	
	public static IObservable<TResult> PublishLast<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector);
    
	
	
	public static IObservable<int> Range(int start, int count, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> RefCount<TSource>(this IConnectableObservable<TSource> source);
    
	
	
	public static IObservable<TSource> Repeat<TSource>(this IObservable<TSource> source, int repeatCount);
    public static IObservable<TResult> Repeat<TResult>(TResult value, int repeatCount, IScheduler scheduler);
    
	
	
	public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, TimeSpan window, IScheduler scheduler);
    
	
	
	
	public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source, int retryCount);
    
	
	
	public static IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler);
    
	
	
	public static AsyncSubject<TSource> RunAsync<TSource>(this IObservable<TSource> source, CancellationToken cancellationToken);
    public static AsyncSubject<TSource> RunAsync<TSource>(this IConnectableObservable<TSource> source, CancellationToken cancellationToken);
    
	
	
	public static IObservable<TSource> Sample<TSource, TSample>(this IObservable<TSource> source, IObservable<TSample> sampler);
    
	
	
	public static IObservable<TAccumulate> Scan<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator);
    
	
	
	public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, TResult> selector);
    
	
	
	public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
    
	
	
	public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IObservable<TSource> second, IEqualityComparer<TSource> comparer);
    
	
	
	
	[Obsolete]
    public static TSource Single<TSource>(this IObservable<TSource> source);
    
	
	
	public static IObservable<TSource> SingleAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> SingleAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	
	[Obsolete]
    public static TSource SingleOrDefault<TSource>(this IObservable<TSource> source);
    
	
	
	public static IObservable<TSource> SingleOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    
	
	
	
	public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> SkipLast<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
    
	
	
	public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
    
	
	
	public static IObservable<Unit> Start(Action action, IScheduler scheduler);
    
	
	
	public static IObservable<Unit> StartAsync(Func<Task> actionAsync);
    
	
	
	public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, IEnumerable<TSource> values);
    
	
	
	public static IDisposable Subscribe<TSource>(this IEnumerable<TSource> source, IObserver<TSource> observer);
    
	
	public static IObservable<decimal?> Sum(this IObservable<decimal?> source);
    
	
	
	public static IObservable<TSource> Switch<TSource>(this IObservable<IObservable<TSource>> sources);
    
	
	
	public static IObservable<TSource> Synchronize<TSource>(this IObservable<TSource> source);
    
	
	
	
	public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, int count);
    
	
	
	public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, int count);
    
	
	
	
	public static IObservable<IList<TSource>> TakeLastBuffer<TSource>(this IObservable<TSource> source, int count);
    
	
	public static IObservable<TSource> TakeUntil<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other);
    
	
	public static IObservable<TSource> TakeWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
    
	
	public static Plan<TResult> Then<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);
    
	
	
	public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    
	
	
	public static IObservable<TResult> Throw<TResult>(Exception exception, IScheduler scheduler, TResult witness);
    
	
	public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    
	
	public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime);
    
	
	
	public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period, IScheduler scheduler);
    
	
	
	
	public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    
	
	public static IObservable<TSource[]> ToArray<TSource>(this IObservable<TSource> source);
    
	
	
	
	public static Func<TArg1, IObservable<Unit>> ToAsync<TArg1>(this Action<TArg1> action);
    
	
	
	
	public static IObservable<IDictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
	
	
	public static IEnumerable<TSource> ToEnumerable<TSource>(this IObservable<TSource> source);
    
	
	public static IEventSource<TSource> ToEvent<TSource>(this IObservable<TSource> source);
    
	
	public static IEventPatternSource<TEventArgs> ToEventPattern<TEventArgs>(this IObservable<EventPattern<TEventArgs>> source);
    
	
	public static IObservable<IList<TSource>> ToList<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
	
	
	public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source, IScheduler scheduler);
    
	
	public static IObservable<TResult> Using<TResult, TResource>(Func<TResource> resourceFactory, Func<TResource, IObservable<TResult>> observableFactory) where TResource: IDisposable;
	
	
	public static TSource Wait<TSource>(this IObservable<TSource> source);
    
	
	public static IObservable<TResult> When<TResult>(params Plan<TResult>[] plans);
    
	
	
	
	public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate);
    
	
	
	public static IObservable<TSource> While<TSource>(Func<bool> condition, IObservable<TSource> source);
    
	
	public static IObservable<IObservable<TSource>> Window<TSource, TWindowClosing>(this IObservable<TSource> source, Func<IObservable<TWindowClosing>> windowClosingSelector);
    
	
	
	public static IObservable<IList<TSource>> Zip<TSource>(this IEnumerable<IObservable<TSource>> sources);
}