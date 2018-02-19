[DebuggerTypeProxy(typeof(SystemThreadingTasks_FutureDebugView<>)), DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}, Result = {DebuggerDisplayResultDescription}"), __DynamicallyInvokable, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
public class Task<TResult> : Task
{
    // Methods
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<TResult> function);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<TResult> function, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<TResult> function, TaskCreationOptions creationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<object, TResult> function, object state);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<object, TResult> function, object state, TaskCreationOptions creationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
    [__DynamicallyInvokable]
    public ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>> continuationAction);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [MethodImpl(MethodImplOptions.NoInlining), __DynamicallyInvokable]
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    [__DynamicallyInvokable]
    public TaskAwaiter<TResult> GetAwaiter();

    // Properties
    [__DynamicallyInvokable]
    public static TaskFactory<TResult> Factory { [__DynamicallyInvokable] get; }
    [DebuggerBrowsable(DebuggerBrowsableState.Never), __DynamicallyInvokable]
    public TResult Result { [__DynamicallyInvokable] get; }
}