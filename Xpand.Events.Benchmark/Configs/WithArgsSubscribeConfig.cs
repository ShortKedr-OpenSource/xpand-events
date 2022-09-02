using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Xpand.Events.Benchmark.Configs {
    public class WithArgsSubscribeConfig : ManualConfig{
        public WithArgsSubscribeConfig() {
            AddJob(new Job() {
                Accuracy = {MaxRelativeError = 0.01f}
            });
        }
    }
}