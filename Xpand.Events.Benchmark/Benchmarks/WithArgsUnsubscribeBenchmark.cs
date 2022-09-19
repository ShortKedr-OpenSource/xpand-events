using System;
using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.SupportingTypes;

namespace Xpand.Events.Benchmark {
    public class WithArgsUnsubscribeBenchmark {
        
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

            bool validationSuccess = true;
            Console.WriteLine("Validation Table: ");
            _listeners = new Event<object, int>[SubscriptionCount];
            for (int i = 0; i < SubscriptionCount; i++) {
                var iCopy = i;
                _listeners[i] = (sender, newValue) => {
                    int value = GetValue(iCopy);
                    FakeLogger.Log($"{sender} {newValue} {value}");
                };
                DefaultEvent += _listeners[i];
                bool a = _xEvent.AddListener(_listeners[i]);
                bool b = _safeXEvent.AddListener(_listeners[i]);
                bool c = _orderedXEvent.AddListener(_listeners[i]);
                bool d = _safeOrderedXEvent.AddListener(_listeners[i]);
                Console.WriteLine($"{a} {b} {c} {d}");
                if (!a || !b || !c || !d) validationSuccess = false;
            }
            Console.WriteLine($"\nSetup Success: {validationSuccess}\n");
            if (!validationSuccess) throw new Exception("Global Setup Error");

        }

        [Benchmark(Baseline = true, Description = "`DefaultEvent -= listener;`")]
        public void DefaultEvent_Unsubscribe() {
            for (int i = 0; i < _listeners.Length; i++) DefaultEvent -= _listeners[i];   
        }

        [Benchmark(Description = "`XEvent.RemoveListener(listener);`")]
        public void XEvent_Unsubscribe() {
            for (int i = 0; i < _listeners.Length; i++) _xEvent.RemoveListener(_listeners[i]);
        }

        [Benchmark(Description = "`SafeXEvent.RemoveListener(listener);`")]
        public void SafeXEvent_Unsubscribe() {
            for (int i = 0; i < _listeners.Length; i++) _safeXEvent.RemoveListener(_listeners[i]);
        }

        [Benchmark(Description = "`OrderedXEvent.RemoveListener(listener);`")]
        public void OrderedXEvent_Unsubscribe() {
            for (int i = 0; i < _listeners.Length; i++) _orderedXEvent.RemoveListener(_listeners[i]);
        }

        [Benchmark(Description = "`SafeOrderedXEvent.RemoveListener(listener);`")]
        public void SafeOrderedXEvent_Unsubscribe() {
            for (int i = 0; i < _listeners.Length; i++) _safeOrderedXEvent.RemoveListener(_listeners[i]);
        }

        protected virtual void OnDefaultEvent() {
            DefaultEvent?.Invoke(this, 49);
        }
        
    }
}