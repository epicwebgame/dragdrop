[DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskDebugView)), DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}"), __DynamicallyInvokable, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
public class Task : IThreadPoolWorkItem, IAsyncResult, IDisposable
{
    // Methods
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action action);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action action, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action action, TaskCreationOptions creationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action<object> action, object state);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action<object> action, object state, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action<object> action, object state, TaskCreationOptions creationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
    [__DynamicallyInvokable]
    public ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task> continuationAction);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task> continuationAction, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task> continuationAction, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task> continuationAction, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task, object> continuationAction, object state);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task, object> continuationAction, object state, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task, object> continuationAction, object state, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task, object> continuationAction, object state, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TResult> ContinueWith<TResult>(Func<Task, object, TResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [__DynamicallyInvokable]
    public static Task Delay(int millisecondsDelay);
    [__DynamicallyInvokable]
    public static Task Delay(TimeSpan delay);
    [__DynamicallyInvokable]
    public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public static Task Delay(TimeSpan delay, CancellationToken cancellationToken);
    public void Dispose();
    protected virtual void Dispose(bool disposing);
    [__DynamicallyInvokable]
    public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public static Task FromCanceled(CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public static Task<TResult> FromException<TResult>(Exception exception);
    [__DynamicallyInvokable]
    public static Task FromException(Exception exception);
    [__DynamicallyInvokable]
    public static Task<TResult> FromResult<TResult>(TResult result);
    [__DynamicallyInvokable]
    public TaskAwaiter GetAwaiter();
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public static Task<TResult> Run<TResult>(Func<TResult> function);
    [__DynamicallyInvokable]
    public static Task<TResult> Run<TResult>(Func<Task<TResult>> function);
    [__DynamicallyInvokable]
    public static Task Run(Func<Task> function);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public static Task Run(Action action);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public static Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public static Task Run(Func<Task> function, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public static Task Run(Action action, CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public static Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public void RunSynchronously();
    [__DynamicallyInvokable]
    public void RunSynchronously(TaskScheduler scheduler);
    [__DynamicallyInvokable]
    public void Start();
    [__DynamicallyInvokable]
    public void Start(TaskScheduler scheduler);
    [__DynamicallyInvokable]
    public void Wait();
    [__DynamicallyInvokable]
    public bool Wait(int millisecondsTimeout);
    [__DynamicallyInvokable]
    public void Wait(CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public bool Wait(TimeSpan timeout);
    [__DynamicallyInvokable]
    public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static void WaitAll(params Task[] tasks);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static bool WaitAll(Task[] tasks, int millisecondsTimeout);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static void WaitAll(Task[] tasks, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static bool WaitAll(Task[] tasks, TimeSpan timeout);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static bool WaitAll(Task[] tasks, int millisecondsTimeout, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static int WaitAny(params Task[] tasks);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static int WaitAny(Task[] tasks, int millisecondsTimeout);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static int WaitAny(Task[] tasks, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static int WaitAny(Task[] tasks, TimeSpan timeout);
    [MethodImpl(MethodImplOptions.NoOptimization), __DynamicallyInvokable]
    public static int WaitAny(Task[] tasks, int millisecondsTimeout, CancellationToken cancellationToken);
    [__DynamicallyInvokable]
    public static Task WhenAll(params Task[] tasks);
    [__DynamicallyInvokable]
    public static Task WhenAll(IEnumerable<Task> tasks);
    [__DynamicallyInvokable]
    public static Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks);
    [__DynamicallyInvokable]
    public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);
    [__DynamicallyInvokable]
    public static Task<Task> WhenAny(params Task[] tasks);
    [__DynamicallyInvokable]
    public static Task<Task<TResult>> WhenAny<TResult>(IEnumerable<Task<TResult>> tasks);
    [__DynamicallyInvokable]
    public static Task<Task> WhenAny(IEnumerable<Task> tasks);
    [__DynamicallyInvokable]
    public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);
    [__DynamicallyInvokable]
    public static YieldAwaitable Yield();

    // Properties
    [__DynamicallyInvokable]
    public object AsyncState { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public static Task CompletedTask { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public TaskCreationOptions CreationOptions { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public static int? CurrentId { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public AggregateException Exception { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public static TaskFactory Factory { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public int Id { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public bool IsCanceled { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public bool IsCompleted { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public bool IsFaulted { [__DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public TaskStatus Status { [__DynamicallyInvokable] get; }
}