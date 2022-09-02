using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Xpand.Events.Benchmark.Configs {
    public class WithArgsUnsubscribeConfig : ManualConfig {
        public WithArgsUnsubscribeConfig() {
            AddJob(new Job() {
                Accuracy = {MaxRelativeError = 0.01f}
            });
        }
    }
}