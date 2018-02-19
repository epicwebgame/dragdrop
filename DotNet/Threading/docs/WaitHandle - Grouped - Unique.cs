public abstract class WaitHandle : MarshalByRefObject, IDisposable
{
	// Static methods
    public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, TimeSpan timeout, bool exitContext);
    public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext);
	public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext);
    
	// Instance methods
	public virtual bool WaitOne(TimeSpan timeout, bool exitContext);
	public virtual void Close();
	protected virtual void Dispose(bool explicitDisposing);
}