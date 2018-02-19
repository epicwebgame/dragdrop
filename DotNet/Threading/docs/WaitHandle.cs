[ComVisible(true), __DynamicallyInvokable]
public abstract class WaitHandle : MarshalByRefObject, IDisposable
{
    // Fields
    protected static readonly IntPtr InvalidHandle;
    [__DynamicallyInvokable]
    public const int WaitTimeout = 0x102;

    // Methods
    [__DynamicallyInvokable]
    protected WaitHandle();
    public virtual void Close();
    [__DynamicallyInvokable]
    public void Dispose();
    [SecuritySafeCritical, __DynamicallyInvokable]
    protected virtual void Dispose(bool explicitDisposing);
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn);
    [SecuritySafeCritical]
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, int millisecondsTimeout, bool exitContext);
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, TimeSpan timeout, bool exitContext);
    [__DynamicallyInvokable]
    public static bool WaitAll(WaitHandle[] waitHandles);
    [__DynamicallyInvokable]
    public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout);
    [__DynamicallyInvokable]
    public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout);
    [SecuritySafeCritical]
    public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext);
    public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext);
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable]
    public static int WaitAny(WaitHandle[] waitHandles);
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable]
    public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout);
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable]
    public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout);
    [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext);
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext);
    [__DynamicallyInvokable]
    public virtual bool WaitOne();
    [__DynamicallyInvokable]
    public virtual bool WaitOne(int millisecondsTimeout);
    [__DynamicallyInvokable]
    public virtual bool WaitOne(TimeSpan timeout);
    public virtual bool WaitOne(int millisecondsTimeout, bool exitContext);
    public virtual bool WaitOne(TimeSpan timeout, bool exitContext);

    // Properties
    [Obsolete("Use the SafeWaitHandle property instead.")]
    public virtual IntPtr Handle { [SecuritySafeCritical] get; [SecurityCritical, SecurityPermission(SecurityAction.InheritanceDemand, Flags=SecurityPermissionFlag.UnmanagedCode)] set; }
    public SafeWaitHandle SafeWaitHandle { [SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), SecurityPermission(SecurityAction.InheritanceDemand, Flags=SecurityPermissionFlag.UnmanagedCode)] get; [SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), SecurityPermission(SecurityAction.InheritanceDemand, Flags=SecurityPermissionFlag.UnmanagedCode)] set; }
}