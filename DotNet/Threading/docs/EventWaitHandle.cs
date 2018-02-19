[ComVisible(true), __DynamicallyInvokable, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
public class EventWaitHandle : WaitHandle
{
    // Methods
    [SecuritySafeCritical, __DynamicallyInvokable]
    public EventWaitHandle(bool initialState, EventResetMode mode);
    [SecurityCritical, __DynamicallyInvokable]
    public EventWaitHandle(bool initialState, EventResetMode mode, string name);
    [SecurityCritical, __DynamicallyInvokable]
    public EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew);
    [SecurityCritical]
    public EventWaitHandle(bool initialState, EventResetMode mode, string name, out bool createdNew, EventWaitHandleSecurity eventSecurity);
    [SecuritySafeCritical]
    public EventWaitHandleSecurity GetAccessControl();
    [SecurityCritical, __DynamicallyInvokable]
    public static EventWaitHandle OpenExisting(string name);
    [SecurityCritical]
    public static EventWaitHandle OpenExisting(string name, EventWaitHandleRights rights);
    [SecuritySafeCritical, __DynamicallyInvokable]
    public bool Reset();
    [SecuritySafeCritical, __DynamicallyInvokable]
    public bool Set();
    [SecuritySafeCritical]
    public void SetAccessControl(EventWaitHandleSecurity eventSecurity);
    [SecurityCritical, __DynamicallyInvokable]
    public static bool TryOpenExisting(string name, out EventWaitHandle result);
    [SecurityCritical]
    public static bool TryOpenExisting(string name, EventWaitHandleRights rights, out EventWaitHandle result);
}