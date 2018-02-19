public class EventWaitHandle : WaitHandle
{
    public EventWaitHandle(bool initialState, EventResetMode mode);
    public EventWaitHandle(bool initialState, EventResetMode mode, string name);
    public EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew);
    public EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew, EventWaitHandleSecurity eventSecurity);
    
    public static EventWaitHandle OpenExisting(string name);
    public static EventWaitHandle OpenExisting(string name, EventWaitHandleRights rights);
	public static bool TryOpenExisting(string name, out EventWaitHandle result);
    public static bool TryOpenExisting(string name, EventWaitHandleRights rights, out EventWaitHandle result);
    
	public bool Set();
    public bool Reset();
    
	public EventWaitHandleSecurity GetAccessControl();
	public void SetAccessControl(EventWaitHandleSecurity eventSecurity);
}