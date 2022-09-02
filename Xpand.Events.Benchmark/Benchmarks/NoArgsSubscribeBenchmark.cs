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
        private SafeXEvent _safeXEvent;
        private OrderedXEvent _orderedXEvent;
        private SafeOrderedXEvent _orderedSafeXEvent;
        
        private Event _listener;

        [GlobalSetup]
        public void Setup() {
            _xEvent = new XEvent();
            _safeXEvent = new SafeXEvent();
            _orderedXEvent = new OrderedXEvent();
            _orderedSafeXEvent = new SafeOrderedXEvent();

            int NotSuppressedMethod() => 5;
            _listener = () => { int value = NotSuppressedMethod(); };
        }

        [Benchmark]
        public void DefaultEvent_Subscribe() => DefaultEvent += _listener;

        [Benchmark]
        public void XEvent_Subscribe() => _xEvent.AddListener(_listener);

        [Benchmark]
        public void SafeXEvent_Subscribe() => _safeXEvent.AddListener(_listener);

        [Benchmark]
        public void OrderedXEvent_Subscribe() => _orderedXEvent.AddListener(_listener);
        
        [Benchmark]
        public void OrderedSafeXEvent_Subscribe() => _orderedSafeXEvent.AddListener(_listener);
        }
}