public sealed class Thread : CriticalFinalizerObject, _Thread
{
	// Constructors
    public Thread(ParameterizedThreadStart start);    
	
	// Operations
	public void Start(object parameter);
    public void Suspend();
	public void Interrupt();
	public void Resume();
	public void Abort(object stateInfo);
    public bool Join(int millisecondsTimeout);
	
	// Static operations
	public static void Sleep(int millisecondsTimeout);
    public static void ResetAbort();
	public static void SpinWait(int iterations);
	public static bool Yield();	
    
	// Ancillary opereations
	public static extern void BeginCriticalRegion();
    public static extern void EndCriticalRegion();
	public static extern void EndThreadAffinity();
    
	// Data operations
	public static void SetData(LocalDataStoreSlot slot, object data);
	public static byte VolatileRead(ref byte address);
    public static void VolatileWrite(ref double address, double value);	

    // Properties -- writable
	public string Name { get; set; }
	public ThreadPriority Priority { get; set; }
	public CultureInfo CurrentCulture { get; set; }
	public CultureInfo CurrentUICulture { get; set; }
	public bool IsBackground { get; set; }
	public static IPrincipal CurrentPrincipal { get; set; }
	
	// Properties -- read-only
	public static Thread CurrentThread { get; }
	public int ManagedThreadId { get; }
	public bool IsAlive { get; }
	public bool IsThreadPoolThread { get; }
    public static Context CurrentContext { get; }
	public ExecutionContext ExecutionContext { get; }
	public ThreadState ThreadState { get; }
}