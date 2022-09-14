using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;

namespace Xpand.Events.Benchmark {

    [Config(typeof(NoArgsSubscribeConfig))]
    public class NoArgsSubscribeBenchmark {
        private const int ListenersCount = 1;
        
#pragma warning disable CS0067
        private event Event DefaultEvent;
#pragma warning restore CS0067
        private XEvent _xEvent;
        private XSafeEvent _XSafeEvent;
        private XOrderedEvent _XOrderedEvent;
        private XSafeOrderedEvent _orderedXSafeEvent;
        
        private Event _listener;

        [GlobalSetup]
        public void Setup() {
            _xEvent = new XEvent();
            _XSafeEvent = new XSafeEvent();
            _XOrderedEvent = new XOrderedEvent();
            _orderedXSafeEvent = new XSafeOrderedEvent();

            int NotSuppressedMethod() => 5;
            _listener = () => { int value = NotSuppressedMethod(); };
        }

        [Benchmark]
        public void DefaultEvent_Subscribe() => DefaultEvent += _listener;

        [Benchmark]
        public void XEvent_Subscribe() => _xEvent.AddListener(_listener);

        [Benchmark]
        public void XSafeEvent_Subscribe() => _XSafeEvent.AddListener(_listener);

        [Benchmark]
        public void XOrderedEvent_Subscribe() => _XOrderedEvent.AddListener(_listener);
        
        [Benchmark]
        public void OrderedXSafeEvent_Subscribe() => _orderedXSafeEvent.AddListener(_listener);
        }
}