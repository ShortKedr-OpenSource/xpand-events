### Events
2. Async/Await Events
3. Async/Callback Events
4. Multithreading Events
5. Add xml docs to public content
6. Override += and -= operators (easy migration from default events)
7. Add fast property constructor and hide default. For example: `XEvent.Default1`, `XEvent.Safe1`, `XEvent.Ordered1`, `XEvent.SafeOrdered1`.

### Tests
1. Implement tests for XArgEvent<TSender, TEventArgs>

### Benchmark
1. Parametrization - iteration count;
2. Column "Code usage";
3. Benchmark - Invoke

### Examples
1. Implement examples: XEvent, SafeXEvent, OrderedXEvent, OrderedSafeXEvent;
2. Implement examples: XArgEvent<TEventArgs>, XArgEvent<TSender, TEventArgs>;
3. Implement examples: Async/Await, Async/Callback;
4. Implement examples: Multithreading Invocation;

### Supporting Library
1. Add EventProvider bindings


### Supporting Library CPP
1. Implement EventProvider
2. Implement EventProvider memory disposing
