public static class Monitor
{
    // Methods
    public static void Enter(object obj, ref bool lockTaken);    
	public static extern void Exit(object obj);
	public static bool IsEntered(object obj);
    
	public static void Pulse(object obj);
    public static void PulseAll(object obj);
    
    public static bool TryEnter(object obj);
    public static void TryEnter(object obj, ref bool lockTaken);
    
	public static bool TryEnter(object obj, int millisecondsTimeout);
    public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken);
    
    public static bool Wait(object obj, TimeSpan timeout, bool exitContext);
}