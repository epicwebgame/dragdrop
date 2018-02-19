[__DynamicallyInvokable, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
public static class ThreadPool
{
    // Methods
    [SecuritySafeCritical, Obsolete("ThreadPool.BindHandle(IntPtr) has been deprecated.  Please use ThreadPool.BindHandle(SafeHandle) instead.", false), SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
    public static bool BindHandle(IntPtr osHandle);
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
    public static bool BindHandle(SafeHandle osHandle);
    [SecuritySafeCritical]
    public static void GetAvailableThreads(out int workerThreads, out int completionPortThreads);
    [SecuritySafeCritical]
    public static void GetMaxThreads(out int workerThreads, out int completionPortThreads);
    [SecuritySafeCritical]
    public static void GetMinThreads(out int workerThreads, out int completionPortThreads);
    [MethodImpl(MethodImplOptions.NoInlining), SecuritySafeCritical, __DynamicallyInvokable]
    public static bool QueueUserWorkItem(WaitCallback callBack);
    [MethodImpl(MethodImplOptions.NoInlining), SecuritySafeCritical, __DynamicallyInvokable]
    public static bool QueueUserWorkItem(WaitCallback callBack, object state);
    [MethodImpl(MethodImplOptions.NoInlining), SecuritySafeCritical]
    public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce);
    [MethodImpl(MethodImplOptions.NoInlining), SecuritySafeCritical]
    public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce);
    [MethodImpl(MethodImplOptions.NoInlining), SecuritySafeCritical]
    public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce);
    [MethodImpl(MethodImplOptions.NoInlining), SecuritySafeCritical, CLSCompliant(false)]
    public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce);
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public static bool SetMaxThreads(int workerThreads, int completionPortThreads);
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public static bool SetMinThreads(int workerThreads, int completionPortThreads);
    [SecurityCritical, CLSCompliant(false)]
    public static unsafe bool UnsafeQueueNativeOverlapped(NativeOverlapped* overlapped);
    [MethodImpl(MethodImplOptions.NoInlining), SecurityCritical]
    public static bool UnsafeQueueUserWorkItem(WaitCallback callBack, object state);
    [MethodImpl(MethodImplOptions.NoInlining), SecurityCritical]
    public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce);
    [MethodImpl(MethodImplOptions.NoInlining), SecurityCritical]
    public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce);
    [MethodImpl(MethodImplOptions.NoInlining), SecurityCritical]
    public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce);
    [MethodImpl(MethodImplOptions.NoInlining), SecurityCritical, CLSCompliant(false)]
    public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce);
}

 
Expand Methods
 
