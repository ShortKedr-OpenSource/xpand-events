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
        private XSafeEvent _XSafeEvent;
        private XOrderedEvent _XOrderedEvent;
        private XSafeOrderedEvent _orderedXSafeEvent;

        private Event[] _listeners;

        [GlobalSetup]
        public void Setup() {

            DefaultEvent = null;

            _xEvent = new XEvent();
            _XSafeEvent = new XSafeEvent();
            _XOrderedEvent = new XOrderedEvent();
            _orderedXSafeEvent = new XSafeOrderedEvent();

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
                bool b = _XSafeEvent.AddListener(_listeners[i]);
                bool c = _XOrderedEvent.AddListener(_listeners[i]);
                bool d = _orderedXSafeEvent.AddListener(_listeners[i]);
                Console.WriteLine($"{a} {b} {c} {d}");
                if (!a || !b || !c || !d) validationSuccess = false;
            }
            Console.WriteLine($"\nSetup Success: {validationSuccess}\n");
            if (!validationSuccess) throw new Exception("Global Setup Error");
        }

        [Benchmark(Baseline = true, Description = "`DefaultEvent?.Invoke()`")]
        public void DefaultEvent_Invoke() => DefaultEvent?.Invoke();

        
        [Benchmark(Description = "`XArgEvent.Invoke()`")]
        public void XEvent_Invoke() => _xEvent.Invoke();
        
        
        [Benchmark(Description = "`XSafeEvent.Invoke()`")]
        public void XSafeEvent_Invoke() => _XSafeEvent.Invoke();

        
        [Benchmark(Description = "`XOrderedEvent.Invoke()`")]
        public void XOrderedEvent_Invoke() => _XOrderedEvent.Invoke();
        
        
        [Benchmark(Description = "`OrderedXSafeEvent.Invoke()`")]
        public void OrderedXSafeEvent_Invoke() => _orderedXSafeEvent.Invoke();
        
    }
}