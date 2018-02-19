public sealed class Thread : CriticalFinalizerObject, _Thread
{
	// Constructors
    public Thread(ParameterizedThreadStart start);    
	public Thread(ThreadStart start);
	public Thread(ParameterizedThreadStart start, int maxStackSize);
	public Thread(ThreadStart start, int maxStackSize);
	
	// Destructor
	protected override void Finalize();
    
	// Operations
	public void Start();
	public void Start(object parameter);
    public void Suspend();
	public void Interrupt();
	public void Resume();
	public void Abort();
	public void Abort(object stateInfo);
	public void Join();
    public bool Join(int millisecondsTimeout);
    public bool Join(TimeSpan timeout);
	
	// Static operations
	public static void Sleep(int millisecondsTimeout);
    public static void Sleep(TimeSpan timeout);
    public static void ResetAbort();
	public static void SpinWait(int iterations);
	public static bool Yield();	
    
	// Ancillary opereations
	public static extern void BeginCriticalRegion();
    public static extern void EndCriticalRegion();
	public static extern void EndThreadAffinity();
    
	
    // Get information
	public ApartmentState GetApartmentState();
	public static AppDomain GetDomain();
    public static int GetDomainID();
    public static LocalDataStoreSlot GetNamedDataSlot(string name);
    
	
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