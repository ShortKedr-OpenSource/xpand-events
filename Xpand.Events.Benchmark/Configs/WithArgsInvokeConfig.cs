using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Xpand.Events.Benchmark.Configs {
    public class WithArgsInvokeConfig : ManualConfig {
        public WithArgsInvokeConfig() {
            AddJob(new Job() {
                Accuracy = {MaxRelativeError = 0.01f}
            });
        }
    }
}