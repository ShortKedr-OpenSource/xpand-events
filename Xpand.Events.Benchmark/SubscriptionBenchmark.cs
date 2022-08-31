using BenchmarkDotNet.Attributes;

namespace Xpand.Events.Benchmark {
    [SimpleJob( 2, 2, 2)]
    public class SubscriptionBenchmark {

        private const int ListenersCount = 50;
        
#pragma warning disable CS0067
        private event Event DefaultEvent;
#pragma warning restore CS0067
        private XEvent _xEvent;
        private SafeXEvent _safeXEvent;
        private OrderedXEvent _orderedXEvent;
        private SafeOrderedXEvent _orderedSafeXEvent;

        private Event[] _listeners;

        [GlobalSetup]
        public void Setup() {
            _xEvent = new XEvent();
            _safeXEvent = new SafeXEvent();
            _orderedXEvent = new OrderedXEvent();
            _orderedSafeXEvent = new SafeOrderedXEvent();
            
            _listeners = new Event[ListenersCount];
            for (int i = 0; i < _listeners.Length; i++) {
                _listeners[i] = () => {};
                DefaultEvent += _listeners[i];
                _xEvent.AddListener(_listeners[i]);
                _safeXEvent.AddListener(_listeners[i]);
                _orderedXEvent.AddListener(_listeners[i]);
                _orderedSafeXEvent.AddListener(_listeners[i]);
            }
        }

        [Benchmark]
        public void DefaultEvent_Invoke() => DefaultEvent?.Invoke();
        
        [Benchmark]
        public void XEvent_Invoke() => _xEvent.Invoke();
        
        [Benchmark]
        public void SafeXEvent_Invoke() => _safeXEvent.Invoke();

        [Benchmark]
        public void OrderedXEvent_Invoke() => _orderedXEvent.Invoke();
        
        [Benchmark]
        public void OrderedSafeXEvent_Invoke() => _orderedSafeXEvent.Invoke();
        
    }
}