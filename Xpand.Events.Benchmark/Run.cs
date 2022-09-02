using BenchmarkDotNet.Running;

namespace Xpand.Events.Benchmark {
    public static class Run {
        public static void Main(string[] args) {
            var noArgsInvokeSummary = BenchmarkRunner.Run<NoArgsInvokeBenchmark>();
            /*var noArgsSubscribeSummary = BenchmarkRunner.Run<NoArgsSubscribeBenchmark>();
            var noArgsUnsubscribeSummary = BenchmarkRunner.Run<NoArgsUnsubscribeBenchmark>();
            var withArgsInvokeSummary = BenchmarkRunner.Run<WithArgsInvokeBenchmark>();
            var withArgsSubscribeSummary = BenchmarkRunner.Run<WithArgsSubscribeBenchmark>();
            var withArgsUnsubscribeSummary = BenchmarkRunner.Run<WithArgsUnsubscribeBenchmark>();*/
        }
    }
}