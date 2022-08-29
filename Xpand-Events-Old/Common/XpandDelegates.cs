namespace Xpand.Events {
    public delegate void Event();
    public delegate void Event<in T>(T value);
    public delegate void Event<in T1, in T2>(T1 value1, T2 value2);
    public delegate void Event<in T1, in T2, in T3>(T1 value1, T2 value2, T3 value3);
    public delegate void Event<in T1, in T2, in T3, in T4>(T1 value1, T2 value2, T3 value3, T4 value4);
    public delegate void Event<in T1, in T2, in T3, in T4, in T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);
    public delegate void Event<in T1, in T2, in T3, in T4, in T5, in T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6);
    public delegate void Event<in T1, in T2, in T3, in T4, in T5, in T6, in T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7);
    public delegate void Event<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8);
}