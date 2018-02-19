public abstract class WaitHandle : MarshalByRefObject, IDisposable
{
    // Fields
    protected static readonly IntPtr InvalidHandle;    
    public const int WaitTimeout = 0x102;

    // Methods
    protected WaitHandle();
    
	public virtual void Close();
    
	public void Dispose();
    protected virtual void Dispose(bool explicitDisposing);
	
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn);
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, int millisecondsTimeout, bool exitContext);
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, TimeSpan timeout, bool exitContext);
    
    public static bool WaitAll(WaitHandle[] waitHandles);
    public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout);
    public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout);
    public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext);
    public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext);
    
	public static int WaitAny(WaitHandle[] waitHandles);
    public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout);
    public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout);
    public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext);
    public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext);
    
    public virtual bool WaitOne();
    public virtual bool WaitOne(int millisecondsTimeout);
    public virtual bool WaitOne(TimeSpan timeout);
    public virtual bool WaitOne(int millisecondsTimeout, bool exitContext);
    public virtual bool WaitOne(TimeSpan timeout, bool exitContext);

    // Properties
    public virtual IntPtr Handle {  get; set; }
    public SafeWaitHandle SafeWaitHandle { get; set; }
}