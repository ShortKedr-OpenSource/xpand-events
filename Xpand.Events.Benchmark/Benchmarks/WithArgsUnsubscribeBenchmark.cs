using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;

namespace Xpand.Events.Benchmark {
    
    [Config(typeof(WithArgsUnsubscribeConfig))]
    public class WithArgsUnsubscribeBenchmark {
        
    }
}