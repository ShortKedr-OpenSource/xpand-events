using BenchmarkDotNet.Running;

namespace Xpand.Events.Benchmark {
    public static class Run {
        public static void Main(string[] args) {
            var invokeSummary = BenchmarkRunner.Run<InvokeBenchmark>();
            var subscribeSummary = BenchmarkRunner.Run<SubscriptionBenchmark>();
        }
    }
}