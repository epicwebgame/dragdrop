[ComVisible(true), __DynamicallyInvokable, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
public static class Monitor
{
    // Methods
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical, __DynamicallyInvokable]
    public static extern void Enter(object obj);
    [__DynamicallyInvokable]
    public static void Enter(object obj, ref bool lockTaken);
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), __DynamicallyInvokable]
    public static extern void Exit(object obj);
    [SecuritySafeCritical, __DynamicallyInvokable]
    public static bool IsEntered(object obj);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern bool IsEnteredNative(object obj);
    private static int MillisecondsTimeoutFromTimeSpan(TimeSpan timeout);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern void ObjPulse(object obj);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern void ObjPulseAll(object obj);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern bool ObjWait(bool exitContext, int millisecondsTimeout, object obj);
    [SecuritySafeCritical, __DynamicallyInvokable]
    public static void Pulse(object obj);
    [SecuritySafeCritical, __DynamicallyInvokable]
    public static void PulseAll(object obj);
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical]
    private static extern void ReliableEnter(object obj, ref bool lockTaken);
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical]
    private static extern void ReliableEnterTimeout(object obj, int timeout, ref bool lockTaken);
    private static void ThrowLockTakenException();
    [__DynamicallyInvokable]
    public static bool TryEnter(object obj);
    [__DynamicallyInvokable]
    public static void TryEnter(object obj, ref bool lockTaken);
    [__DynamicallyInvokable]
    public static bool TryEnter(object obj, int millisecondsTimeout);
    [__DynamicallyInvokable]
    public static bool TryEnter(object obj, TimeSpan timeout);
    [__DynamicallyInvokable]
    public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken);
    [__DynamicallyInvokable]
    public static void TryEnter(object obj, TimeSpan timeout, ref bool lockTaken);
    [__DynamicallyInvokable]
    public static bool Wait(object obj);
    [__DynamicallyInvokable]
    public static bool Wait(object obj, int millisecondsTimeout);
    [__DynamicallyInvokable]
    public static bool Wait(object obj, TimeSpan timeout);
    [SecuritySafeCritical]
    public static bool Wait(object obj, int millisecondsTimeout, bool exitContext);
    public static bool Wait(object obj, TimeSpan timeout, bool exitContext);
}

 
Expand Methods
 
