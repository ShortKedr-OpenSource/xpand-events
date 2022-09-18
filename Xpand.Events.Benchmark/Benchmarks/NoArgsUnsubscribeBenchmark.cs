using System;
using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;
using Xpand.Events.Benchmark.SupportingTypes;

namespace Xpand.Events.Benchmark {

    [Config(typeof(NoArgsUnsubscribeConfig))]
    public class NoArgsUnsubscribeBenchmark {
        [Params(10, 50, 100, 1000, 10000)]
        public int SubscriptionCount { get; set; }
        
        private event Event DefaultEvent;
        
        private XEvent _xEvent;
        private SafeXEvent _safeXEvent;
        private OrderedXEvent _orderedXEvent;
        private SafeOrderedXEvent _safeOrderedXEvent;
        
        private Event[] _listeners;

        [GlobalSetup]
        public void Setup() {
            
            DefaultEvent = null;
            
            _xEvent = new XEvent();
            _safeXEvent = new SafeXEvent();
            _orderedXEvent = new OrderedXEvent();
            _safeOrderedXEvent = new SafeOrderedXEvent();

            int GetValue(int value) => value;

            bool validationSuccess = true;
            Console.WriteLine("Validation Table: ");
            _listeners = new Event[SubscriptionCount];
            for (int i = 0; i < SubscriptionCount; i++) {
                var iCopy = i;
                _listeners[i] = () => {
                    int value = GetValue(iCopy);
                    FakeLogger.Log(value.ToString());
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
            DefaultEvent?.Invoke();
        }
    }
}