public static class Monitor
{
    // Methods
    public static extern void Enter(object obj);
    public static void Enter(object obj, ref bool lockTaken);    
	public static extern void Exit(object obj);
	public static bool IsEntered(object obj);
    
	public static void Pulse(object obj);
    public static void PulseAll(object obj);
    
    public static bool TryEnter(object obj);
    public static void TryEnter(object obj, ref bool lockTaken);
    public static bool TryEnter(object obj, int millisecondsTimeout);
    public static bool TryEnter(object obj, TimeSpan timeout);
    public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken);
    public static void TryEnter(object obj, TimeSpan timeout, ref bool lockTaken);
    
    public static bool Wait(object obj);
    public static bool Wait(object obj, int millisecondsTimeout);
    public static bool Wait(object obj, TimeSpan timeout);
    public static bool Wait(object obj, int millisecondsTimeout, bool exitContext);
    public static bool Wait(object obj, TimeSpan timeout, bool exitContext);
}