public static class ThreadPool
{
    public static void GetAvailableThreads(out int workerThreads, out int completionPortThreads);
    public static void GetMaxThreads(out int workerThreads, out int completionPortThreads);
    public static void GetMinThreads(out int workerThreads, out int completionPortThreads);
    public static bool SetMaxThreads(int workerThreads, int completionPortThreads);
    public static bool SetMinThreads(int workerThreads, int completionPortThreads);
    
	
	public static bool QueueUserWorkItem(WaitCallback callBack, object state);
	public static bool UnsafeQueueUserWorkItem(WaitCallback callBack, object state);
    
	public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce);
    public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce);
}