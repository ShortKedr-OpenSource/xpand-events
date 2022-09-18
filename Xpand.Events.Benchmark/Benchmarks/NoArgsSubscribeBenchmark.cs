using System;
using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;
using Xpand.Events.Benchmark.SupportingTypes;

namespace Xpand.Events.Benchmark {

    [Config(typeof(NoArgsSubscribeConfig))]
    public class NoArgsSubscribeBenchmark {
        
        [Params(10, 50, 100, 1000, 10000)]
        public int SubscriptionCount { get; set; }

// Disable method is never invoked warning
#pragma warning disable CS0067 
        private event Event DefaultEvent;
#pragma warning restore CS0067
        
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

            _listeners = new Event[SubscriptionCount];
            for (int i = 0; i < SubscriptionCount; i++) {
                var iCopy = i;
                _listeners[i] = () => {
                    int value = GetValue(iCopy);
                    FakeLogger.Log(value.ToString());
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
    }
}