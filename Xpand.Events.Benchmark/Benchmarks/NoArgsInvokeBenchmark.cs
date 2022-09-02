using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using Xpand.Events.Benchmark.Configs;
using Xpand.Events.Benchmark.SupportingTypes;

namespace Xpand.Events.Benchmark {
    
    [Config(typeof(NoArgsInvokeConfig))]
    public class NoArgsInvokeBenchmark {

        [Params(10, 50, 100, 1000, 10000)]
        public int ListenersCount { get; set; }

        private event Event DefaultEvent;
        
        private XEvent _xEvent;
        private SafeXEvent _safeXEvent;
        private OrderedXEvent _orderedXEvent;
        private SafeOrderedXEvent _orderedSafeXEvent;

        private Event[] _listeners;

        [GlobalSetup]
        public void Setup() {

            DefaultEvent = null;

            _xEvent = new XEvent();
            _safeXEvent = new SafeXEvent();
            _orderedXEvent = new OrderedXEvent();
            _orderedSafeXEvent = new SafeOrderedXEvent();

            int GetValue(int value) => value;

            bool validationSuccess = true;
            Console.WriteLine("Validation Table: ");
            _listeners = new Event[ListenersCount];
            for (int i = 0; i < ListenersCount; i++) {
                var iCopy = i;
                _listeners[i] = () => {
                    int value = GetValue(iCopy);
                    FakeLogger.Log(value.ToString());
                };
                DefaultEvent += _listeners[i];
                bool a = _xEvent.AddListener(_listeners[i]);
                bool b = _safeXEvent.AddListener(_listeners[i]);
                bool c = _orderedXEvent.AddListener(_listeners[i]);
                bool d = _orderedSafeXEvent.AddListener(_listeners[i]);
                Console.WriteLine($"{a} {b} {c} {d}");
                if (!a || !b || !c || !d) validationSuccess = false;
            }
            Console.WriteLine($"\nSetup Success: {validationSuccess}\n");
            if (!validationSuccess) throw new Exception("Global Setup Error");
        }

        [Benchmark(Baseline = true, Description = "`DefaultEvent?.Invoke()`")]
        public void DefaultEvent_Invoke() => DefaultEvent?.Invoke();

        
        [Benchmark(Description = "`XEvent.Invoke()`")]
        public void XEvent_Invoke() => _xEvent.Invoke();
        
        
        [Benchmark(Description = "`SafeXEvent.Invoke()`")]
        public void SafeXEvent_Invoke() => _safeXEvent.Invoke();

        
        [Benchmark(Description = "`OrderedXEvent.Invoke()`")]
        public void OrderedXEvent_Invoke() => _orderedXEvent.Invoke();
        
        
        [Benchmark(Description = "`OrderedSafeXEvent.Invoke()`")]
        public void OrderedSafeXEvent_Invoke() => _orderedSafeXEvent.Invoke();
        
    }
}