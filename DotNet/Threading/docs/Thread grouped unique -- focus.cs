public sealed class Thread : CriticalFinalizerObject, _Thread
{
	// What is the stack size of a thread? 
	// The Win32 API CreateThread function as well 
	// as the .NET System.Threading.Thread class 
	// constructor has an overload that accepts a stack size.
	
	// concurrency vs. asynchrony vs. parallelism vs. multi-tasking vs. multi-threading

	// Operations
	public void Start(object parameter);
    public void Suspend();
	public void Interrupt();
	public void Resume();
	public void Abort(object stateInfo);
    public static void Sleep(int millisecondsTimeout);
    public bool Join(int millisecondsTimeout);
    public static void ResetAbort();
	public static void SpinWait(int iterations);
	public static bool Yield();	
    
	// Ancillary opereations
	public static extern void BeginCriticalRegion();
    public static extern void EndCriticalRegion();
	public static extern void EndThreadAffinity();
    
	// Data operations
	public static byte VolatileRead(ref byte address);
    public static void VolatileWrite(ref double address, double value);	

    public static Context CurrentContext { get; }
	public ExecutionContext ExecutionContext { get; }
}