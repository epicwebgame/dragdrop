public class Task<TResult> : Task
{
    public Task(Func<TResult> function);    
    public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
    
    public ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);
    
	public Task ContinueWith(Action<Task<TResult>> continuationAction);
    public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
    
    public TaskAwaiter<TResult> GetAwaiter();

    public static TaskFactory<TResult> Factory {  get; }
    public TResult Result {  get; }
}