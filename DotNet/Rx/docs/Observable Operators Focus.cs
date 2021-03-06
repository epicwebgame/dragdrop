public static class Observable
{
    // Of the 83 new operators
	
	// I have some vague idea about these, so go over these thoroughly and test by
	// writing some code
	public static IObservable<TSource> Amb<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
	public static IObservable<IList<TSource>> Buffer<TSource, TBufferClosing>(this IObservable<TSource> source...);
	public static IObservable<IList<TSource>> CombineLatest<TSource>(params IObservable<TSource>[] sources);
	public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
	public static IObservable<TSource> Dematerialize<TSource>(this IObservable<Notification<TSource>> source);
    public static IObservable<TSource> DistinctUntilChanged<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector);
	public static IObservable<TSource> FirstAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<TSource> FirstOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
	public static IObservable<long> Interval(TimeSpan period, IScheduler scheduler);
    public static IObservable<TSource> LastAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
    public static IObservable<TSource> LastOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
	public static IObservable<Notification<TSource>> Materialize<TSource>(this IObservable<TSource> source);
	public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources);
	public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source, int retryCount);
	public static IObservable<TAccumulate> Scan<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed...);
	public static IObservable<Unit> Start(Action action, IScheduler scheduler);
    public static IObservable<Unit> StartAsync(Func<Task> actionAsync);
    public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, IEnumerable<TSource> values);
    public static IObservable<TSource> Synchronize<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<IList<TSource>> TakeLastBuffer<TSource>(this IObservable<TSource> source, int count);
    public static IObservable<TSource> TakeUntil<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other);
    public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
    public static IObservable<TResult> Throw<TResult>(Exception exception, IScheduler scheduler, TResult witness);
    public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime);
    public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period, IScheduler scheduler);
    public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source, IScheduler scheduler);
    public static TSource Wait<TSource>(this IObservable<TSource> source);
	public static IObservable<IObservable<TSource>> Window<TSource, TWindowClosing>(this IObservable<TSource> source...);
	public static IObservable<TSource> SingleAsync<TSource>(this IObservable<TSource> source);
    public static IObservable<TSource> SingleOrDefaultAsync<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate);
	public static IObservable<TSource> SkipLast<TSource>(this IObservable<TSource> source, TimeSpan duration, IScheduler scheduler);
	
	// These look important, but I have no idea about what they are
	public static IEnumerable<TResult> Collect<TSource, TResult>(this IObservable<TSource> source, Func<TResult> getInitialCollector...);
    public static IObservable<TResult> DeferAsync<TResult>(Func<CancellationToken, Task<IObservable<TResult>>> observableFactoryAsync);
	public static IObservable<TSource> DelaySubscription<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler);
	public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate);
    public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, ...);
    public static IObservable<TSource> IgnoreElements<TSource>(this IObservable<TSource> source);
	public static IEnumerable<TSource> Latest<TSource>(this IObservable<TSource> source);
	public static IEnumerable<TSource> MostRecent<TSource>(this IObservable<TSource> source, TSource initialValue);
	public static IConnectableObservable<TResult> Multicast<TSource, TResult>(this IObservable<TSource> source, ISubject<TSource, TResult> subject);
	public static IObservable<TResult> Never<TResult>(TResult witness);
    public static IEnumerable<TSource> Next<TSource>(this IObservable<TSource> source);
	public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>...);
    public static IObservable<TResult> PublishLast<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>...);
	public static IObservable<TSource> RefCount<TSource>(this IConnectableObservable<TSource> source);
    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>...);
	public static AsyncSubject<TSource> RunAsync<TSource>(this IObservable<TSource> source, CancellationToken cancellationToken);
    public static IObservable<TSource> Sample<TSource, TSample>(this IObservable<TSource> source, IObservable<TSample> sampler);
	
	
	
	// Skim over. Don't use or show.
	public static IObservable<IList<TSource>> MaxBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector...);    
    public static IObservable<IList<TSource>> MinBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector...);
	
	
	
	// Remaining ones I will study later
	public static Pattern<TLeft, TRight> And<TLeft, TRight>(this IObservable<TLeft> left, IObservable<TRight> right);
	public static IObservable<TResult> Case<TValue, TResult>(Func<TValue> selector, IDictionary<TValue, IObservable<TResult>> sources, IScheduler scheduler);
	public static IEnumerable<IList<TSource>> Chunkify<TSource>(this IObservable<TSource> source);
	public static Plan<TResult> Then<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);
	public static IObservable<TResult> When<TResult>(params Plan<TResult>[] plans);
    
	
	
	// These look like language constructs. Just skim over them and mention them.
	// Don't demo their use.
	public static IObservable<TSource> Catch<TSource>(this IEnumerable<IObservable<TSource>> sources);
	public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted)    
	public static IObservable<TSource> DoWhile<TSource>(this IObservable<TSource> source, Func<bool> condition);
	public static IObservable<TSource> Finally<TSource>(this IObservable<TSource> source, Action finallyAction);
    public static IObservable<TResult> For<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IObservable<TResult>> resultSelector);
    public static void ForEach<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext);
    public static Task ForEachAsync<TSource>(this IObservable<TSource> source, Action<TSource, int> onNext, CancellationToken cancellationToken);
	public static IObservable<TResult> If<TResult>(Func<bool> condition, IObservable<TResult> thenSource, IScheduler scheduler);
	public static IObservable<TSource> OnErrorResumeNext<TSource>(this IObservable<TSource> first, IObservable<TSource> second);
	public static IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler);
	public static IObservable<TSource> Switch<TSource>(this IObservable<IObservable<TSource>> sources);
	public static IObservable<TResult> Using<TResult, TResource>(Func<TResource> resourceFactory, Func<TResource, IObservable<TResult>> observableFactory);
	public static IObservable<TSource> While<TSource>(Func<bool> condition, IObservable<TSource> source);
	

	// Go over these thoroughly
	public static IObservable<TSource> AsObservable<TSource>(this IObservable<TSource> source);
	public static IObservable<TResult> Create<TResult>(Func<IObserver<TResult>, IDisposable> subscribe);
	public static IObservable<TResult> FromAsync<TResult>(Func<Task<TResult>> functionAsync);
    public static Func<IObservable<Unit>> FromAsyncPattern(Func<AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end);
    public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler);
    public static IObservable<EventPattern<object>> FromEventPattern(Action<EventHandler> addHandler, Action<EventHandler> removeHandler);
    public static AsyncSubject<TSource> GetAwaiter<TSource>(this IConnectableObservable<TSource> source);
	public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, SynchronizationContext context);
    public static IDisposable Subscribe<TSource>(this IEnumerable<TSource> source, IObserver<TSource> observer);
	public static Func<TArg1, IObservable<Unit>> ToAsync<TArg1>(this Action<TArg1> action);
    public static IEventSource<TSource> ToEvent<TSource>(this IObservable<TSource> source);
    public static IEventPatternSource<TEventArgs> ToEventPattern<TEventArgs>(this IObservable<EventPattern<TEventArgs>> source);
    public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source, IScheduler scheduler);
}
}

public static class Observable
{
    
	// 2 house-keeping or administrative methods
	public static IEnumerator<TSource> GetEnumerator<TSource>(this IObservable<TSource> source);
	public static IEnumerable<TSource> ToEnumerable<TSource>(this IObservable<TSource> source);
}