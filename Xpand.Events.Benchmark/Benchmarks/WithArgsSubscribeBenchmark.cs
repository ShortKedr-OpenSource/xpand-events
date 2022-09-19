using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;
using Xpand.Events.Benchmark.SupportingTypes;

namespace Xpand.Events.Benchmark {
    
    [Config(typeof(WithArgsSubscribeConfig))]
    public class WithArgsSubscribeBenchmark {
        
        [Params(10, 50, 100, 1000, 10000)]
        public int SubscriptionCount { get; set; }
        
        private event Event<object, int> DefaultEvent;

        private XEvent<object, int> _xEvent;
        private SafeXEvent<object, int> _safeXEvent;
        private OrderedXEvent<object, int> _orderedXEvent;
        private SafeOrderedXEvent<object, int> _safeOrderedXEvent;
        
        private Event<object, int>[] _listeners;

        [GlobalSetup]
        public void Setup() {

            DefaultEvent = null;
            
            _xEvent = new XEvent<object, int>();
            _safeXEvent = new SafeXEvent<object, int>();
            _orderedXEvent = new OrderedXEvent<object, int>();
            _safeOrderedXEvent = new SafeOrderedXEvent<object, int>();

            int GetValue(int value) => value;

            _listeners = new Event<object, int>[SubscriptionCount];
            for (int i = 0; i < SubscriptionCount; i++) {
                var iCopy = i;
                _listeners[i] = (sender, newValue) => {
                    int value = GetValue(iCopy);
                    FakeLogger.Log($"{sender} {newValue} {value}");
                };
            }

        }

        [Benchmark(Baseline = true, Description = "`DefaultEvent += listener;`")]
        public void DefaultEvent_Subscribe() {
            for (int i = 0; i < _listeners.Length; i++) DefaultEvent += _listeners[i];   
        }

        [Benchmark(Description = "`XEvent.AddListener(listener);`")]
        public void XEvent_Subscribe() {
            for (int i = 0; i < _listeners.Length; i++) _xEvent.AddListener(_listeners[i]);
        }

        [Benchmark(Description = "`SafeXEvent.AddListener(listener);`")]
        public void SafeXEvent_Subscribe() {
            for (int i = 0; i < _listeners.Length; i++) _safeXEvent.AddListener(_listeners[i]);
        }

        [Benchmark(Description = "`OrderedXEvent.AddListener(listener);`")]
        public void OrderedXEvent_Subscribe() {
            for (int i = 0; i < _listeners.Length; i++) _orderedXEvent.AddListener(_listeners[i]);
        }

        [Benchmark(Description = "`SafeOrderedXEvent.AddListener(listener);`")]
        public void SafeOrderedXEvent_Subscribe() {
            for (int i = 0; i < _listeners.Length; i++) _safeOrderedXEvent.AddListener(_listeners[i]);
        }

        protected virtual void OnDefaultEvent() {
            DefaultEvent?.Invoke(this, 49);
        }
        
    }
}