[ClassInterface(ClassInterfaceType.None), ComDefaultInterface(typeof(_Thread)), ComVisible(true), __DynamicallyInvokable]
public sealed class Thread : CriticalFinalizerObject, _Thread
{
    // Fields
    private IntPtr DONT_USE_InternalThread;
    private Context m_Context;
    private CultureInfo m_CurrentCulture;
    private CultureInfo m_CurrentUICulture;
    private Delegate m_Delegate;
    private ExecutionContext m_ExecutionContext;
    private bool m_ExecutionContextBelongsToOuterScope;
    private int m_ManagedThreadId;
    private string m_Name;
    private int m_Priority;
    private object m_ThreadStartArg;
    private static AsyncLocal<CultureInfo> s_asyncLocalCurrentCulture;
    private static AsyncLocal<CultureInfo> s_asyncLocalCurrentUICulture;
    [ThreadStatic]
    private static LocalDataStoreHolder s_LocalDataStore;
    private static LocalDataStoreMgr s_LocalDataStoreMgr;

    // Methods
    [SecuritySafeCritical]
    public Thread(ParameterizedThreadStart start);
    [SecuritySafeCritical]
    public Thread(ThreadStart start);
    [SecuritySafeCritical]
    public Thread(ParameterizedThreadStart start, int maxStackSize);
    [SecuritySafeCritical]
    public Thread(ThreadStart start, int maxStackSize);
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public void Abort();
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public void Abort(object stateInfo);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void AbortInternal();
    [HostProtection(SecurityAction.LinkDemand, SharedState=true, ExternalThreading=true)]
    public static LocalDataStoreSlot AllocateDataSlot();
    [HostProtection(SecurityAction.LinkDemand, SharedState=true, ExternalThreading=true)]
    public static LocalDataStoreSlot AllocateNamedDataSlot(string name);
    private static void AsyncLocalSetCurrentCulture(AsyncLocalValueChangedArgs<CultureInfo> args);
    private static void AsyncLocalSetCurrentUICulture(AsyncLocalValueChangedArgs<CultureInfo> args);
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public static extern void BeginCriticalRegion();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static extern void BeginThreadAffinity();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    internal extern void ClearAbortReason();
    private static object CompleteCrossContextCallback(InternalCrossContextDelegate ftnToCall, object[] args);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    public extern void DisableComObjectEagerCleanup();
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public static extern void EndCriticalRegion();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static extern void EndThreadAffinity();
    [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    protected override void Finalize();
    [HostProtection(SecurityAction.LinkDemand, SharedState=true, ExternalThreading=true)]
    public static void FreeNamedDataSlot(string name);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    internal extern object GetAbortReason();
    [SecuritySafeCritical]
    public ApartmentState GetApartmentState();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern int GetApartmentStateNative();
    [SecurityCritical, Obsolete("Thread.GetCompressedStack is no longer supported. Please use the System.Threading.CompressedStack class")]
    public CompressedStack GetCompressedStack();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    internal static extern Context GetContextInternal(IntPtr id);
    [SecurityCritical]
    internal Context GetCurrentContextInternal();
    [SecuritySafeCritical]
    private CultureInfo GetCurrentCultureNoAppX();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    private static extern Thread GetCurrentThreadNative();
    [SecuritySafeCritical]
    internal CultureInfo GetCurrentUICultureNoAppX();
    [HostProtection(SecurityAction.LinkDemand, SharedState=true, ExternalThreading=true)]
    public static object GetData(LocalDataStoreSlot slot);
    [SecuritySafeCritical]
    public static AppDomain GetDomain();
    public static int GetDomainID();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern AppDomain GetDomainInternal();
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    internal ExecutionContext.Reader GetExecutionContextReader();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern AppDomain GetFastDomainInternal();
    [ComVisible(false)]
    public override int GetHashCode();
    [SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    internal ExecutionContext GetMutableExecutionContext();
    [HostProtection(SecurityAction.LinkDemand, SharedState=true, ExternalThreading=true)]
    public static LocalDataStoreSlot GetNamedDataSlot(string name);
    internal ThreadHandle GetNativeHandle();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern int GetPriorityNative();
    [SecurityCritical, SuppressUnmanagedCodeSecurity, DllImport("QCall", CharSet=CharSet.Unicode)]
    private static extern ulong GetProcessDefaultStackSize();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern int GetThreadStateNative();
    [SecurityCritical, SuppressUnmanagedCodeSecurity, DllImport("QCall", CharSet=CharSet.Unicode)]
    private static extern void InformThreadNameChange(ThreadHandle t, string name, int len);
    [SecurityCritical]
    internal object InternalCrossContextCallback(Context ctx, InternalCrossContextDelegate ftnToCall, object[] args);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    internal extern object InternalCrossContextCallback(Context ctx, IntPtr ctxID, int appDomainID, InternalCrossContextDelegate ftnToCall, object[] args);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    private extern void InternalFinalize();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    internal static extern IntPtr InternalGetCurrentThread();
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public void Interrupt();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void InterruptInternal();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern bool IsBackgroundNative();
    [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public void Join();
    [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public bool Join(int millisecondsTimeout);
    [HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public bool Join(TimeSpan timeout);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern bool JoinInternal(int millisecondsTimeout);
    [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical, __DynamicallyInvokable]
    public static extern void MemoryBarrier();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern bool nativeGetSafeCulture(Thread t, int appDomainId, bool isUI, ref CultureInfo safeCulture);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern bool nativeSetThreadUILocale(string locale);
    [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public static void ResetAbort();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void ResetAbortNative();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    internal extern void RestoreAppDomainStack(IntPtr appDomainStack);
    [SecuritySafeCritical, Obsolete("Thread.Resume has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false), SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public void Resume();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void ResumeInternal();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    internal extern void SetAbortReason(object o);
    [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, Synchronization=true, SelfAffectingThreading=true)]
    public void SetApartmentState(ApartmentState state);
    [SecurityCritical]
    private bool SetApartmentStateHelper(ApartmentState state, bool fireMDAOnMismatch);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern int SetApartmentStateNative(int state, bool fireMDAOnMismatch);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    internal extern IntPtr SetAppDomainStack(SafeCompressedStackHandle csHandle);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void SetBackgroundNative(bool isBackground);
    [SecurityCritical, Obsolete("Thread.SetCompressedStack is no longer supported. Please use the System.Threading.CompressedStack class")]
    public void SetCompressedStack(CompressedStack stack);
    [HostProtection(SecurityAction.LinkDemand, SharedState=true, ExternalThreading=true)]
    public static void SetData(LocalDataStoreSlot slot, object data);
    [SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    internal void SetExecutionContext(ExecutionContext value, bool belongsToCurrentScope);
    [SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    internal void SetExecutionContext(ExecutionContext.Reader value, bool belongsToCurrentScope);
    [SecurityCritical]
    private void SetPrincipalInternal(IPrincipal principal);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void SetPriorityNative(int priority);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void SetStart(Delegate start, int maxStackSize);
    [SecurityCritical]
    private void SetStartHelper(Delegate start, int maxStackSize);
    [SecuritySafeCritical]
    public static void Sleep(int millisecondsTimeout);
    public static void Sleep(TimeSpan timeout);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private static extern void SleepInternal(int millisecondsTimeout);
    [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public static void SpinWait(int iterations);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    private static extern void SpinWaitInternal(int iterations);
    [MethodImpl(MethodImplOptions.NoInlining), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public void Start();
    [MethodImpl(MethodImplOptions.NoInlining), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public void Start(object parameter);
    [SecuritySafeCritical]
    private void Start(ref StackCrawlMark stackMark);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void StartInternal(IPrincipal principal, ref StackCrawlMark stackMark);
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void StartupSetApartmentStateInternal();
    [SecuritySafeCritical, Obsolete("Thread.Suspend has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false), SecurityPermission(SecurityAction.Demand, ControlThread=true), SecurityPermission(SecurityAction.Demand, ControlThread=true)]
    public void Suspend();
    [MethodImpl(MethodImplOptions.InternalCall), SecurityCritical]
    private extern void SuspendInternal();
    void _Thread.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);
    void _Thread.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);
    void _Thread.GetTypeInfoCount(out uint pcTInfo);
    void _Thread.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
    [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, Synchronization=true, SelfAffectingThreading=true)]
    public bool TrySetApartmentState(ApartmentState state);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte VolatileRead(ref byte address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double VolatileRead(ref double address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short VolatileRead(ref short address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int VolatileRead(ref int address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long VolatileRead(ref long address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntPtr VolatileRead(ref IntPtr address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object VolatileRead(ref object address);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static sbyte VolatileRead(ref sbyte address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float VolatileRead(ref float address);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static ushort VolatileRead(ref ushort address);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static uint VolatileRead(ref uint address);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static ulong VolatileRead(ref ulong address);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static UIntPtr VolatileRead(ref UIntPtr address);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref byte address, byte value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref double address, double value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref short address, short value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref int address, int value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref long address, long value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref IntPtr address, IntPtr value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref object address, object value);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static void VolatileWrite(ref sbyte address, sbyte value);
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void VolatileWrite(ref float address, float value);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static void VolatileWrite(ref ushort address, ushort value);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static void VolatileWrite(ref uint address, uint value);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static void VolatileWrite(ref ulong address, ulong value);
    [MethodImpl(MethodImplOptions.NoInlining), CLSCompliant(false)]
    public static void VolatileWrite(ref UIntPtr address, UIntPtr value);
    [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public static bool Yield();
    [SecurityCritical, SuppressUnmanagedCodeSecurity, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true), DllImport("QCall", CharSet=CharSet.Unicode)]
    private static extern bool YieldInternal();

    // Properties
    internal object AbortReason { [SecurityCritical] get; [SecurityCritical] set; }
    [Obsolete("The ApartmentState property has been deprecated.  Use GetApartmentState, SetApartmentState or TrySetApartmentState instead.", false)]
    public ApartmentState ApartmentState { [SecuritySafeCritical] get; [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, Synchronization=true, SelfAffectingThreading=true)] set; }
    public static Context CurrentContext { [SecurityCritical] get; }
    [__DynamicallyInvokable]
    public CultureInfo CurrentCulture { [__DynamicallyInvokable] get; [SecuritySafeCritical, __DynamicallyInvokable, SecurityPermission(SecurityAction.Demand, ControlThread=true)] set; }
    public static IPrincipal CurrentPrincipal { [SecuritySafeCritical] get; [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlPrincipal)] set; }
    [__DynamicallyInvokable]
    public static Thread CurrentThread { [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable] get; }
    [__DynamicallyInvokable]
    public CultureInfo CurrentUICulture { [__DynamicallyInvokable] get; [SecuritySafeCritical, __DynamicallyInvokable, HostProtection(SecurityAction.LinkDemand, ExternalThreading=true)] set; }
    public ExecutionContext ExecutionContext { [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] get; }
    internal bool ExecutionContextBelongsToCurrentScope { get; set; }
    public bool IsAlive { [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical] get; }
    public bool IsBackground { [SecuritySafeCritical] get; [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, SelfAffectingThreading=true)] set; }
    public bool IsThreadPoolThread { [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical] get; }
    private static LocalDataStoreMgr LocalDataStoreManager { get; }
    [__DynamicallyInvokable]
    public int ManagedThreadId { [MethodImpl(MethodImplOptions.InternalCall), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), SecuritySafeCritical, __DynamicallyInvokable] get; }
    public string Name { get; [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, ExternalThreading=true)] set; }
    public ThreadPriority Priority { [SecuritySafeCritical] get; [SecuritySafeCritical, HostProtection(SecurityAction.LinkDemand, SelfAffectingThreading=true)] set; }
    public ThreadState ThreadState { [SecuritySafeCritical] get; }
}

 
Expand Methods
 
