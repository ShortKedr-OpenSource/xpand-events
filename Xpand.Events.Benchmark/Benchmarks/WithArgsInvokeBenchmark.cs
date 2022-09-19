using System;
using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;
using Xpand.Events.Benchmark.SupportingTypes;

namespace Xpand.Events.Benchmark {
    
    [Config(typeof(WithArgsInvokeConfig))]
    public class WithArgsInvokeBenchmark {
        
        [Params(10, 50, 100, 1000, 10000)]
        public int ListenersCount { get; set; }

        private event Event<object, int> DefaultEvent;
        
        private XEvent<object, int> _xEvent;
        private SafeXEvent<object, int> _safeXEvent;
        private OrderedXEvent<object, int> _orderedXEvent;
        private SafeOrderedXEvent<object, int> _safeOrderedXEvent;

        private Event<object, int>[] _listeners;

        private object _sender;
        private int _newValue;

        [GlobalSetup]
        public void Setup() {

            _sender = this;
            _newValue = 49;
            
            DefaultEvent = null;

            _xEvent = new XEvent<object, int>();
            _safeXEvent = new SafeXEvent<object, int>();
            _orderedXEvent = new OrderedXEvent<object, int>();
            _safeOrderedXEvent = new SafeOrderedXEvent<object, int>();

            int GetValue(int value) => value;

            bool validationSuccess = true;
            Console.WriteLine("Validation Table: ");
            _listeners = new Event<object, int>[ListenersCount];
            for (int i = 0; i < ListenersCount; i++) {
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

        [Benchmark(Baseline = true, Description = "`DefaultEvent?.Invoke(sender, newValue);`")]
        public void DefaultEvent_Invoke() => DefaultEvent?.Invoke(_sender, _newValue);

        
        [Benchmark(Description = "`XEvent.Invoke(_sender, _newValue);`")]
        public void XEvent_Invoke() => _xEvent.Invoke(_sender, _newValue);
        
        
        [Benchmark(Description = "`SafeXEvent.Invoke(_sender, _newValue);`")]
        public void SafeXEvent_Invoke() => _safeXEvent.Invoke(_sender, _newValue);

        
        [Benchmark(Description = "`OrderedXEvent.Invoke(_sender, _newValue);`")]
        public void OrderedXEvent_Invoke() => _orderedXEvent.Invoke(_sender, _newValue);
        
        
        [Benchmark(Description = "`SafeOrderedXEvent.Invoke(_sender, _newValue);`")]
        public void SafeOrderedXEvent_Invoke() => _safeOrderedXEvent.Invoke(_sender, _newValue);
        
    }
}