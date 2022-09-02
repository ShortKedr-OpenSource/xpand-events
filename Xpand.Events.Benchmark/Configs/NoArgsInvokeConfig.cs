using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using Perfolizer.Horology;

namespace Xpand.Events.Benchmark.Configs {
    public class NoArgsInvokeConfig : ManualConfig {
        public NoArgsInvokeConfig() {
            
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);

            AddJob(new Job() {
                Accuracy = {MaxRelativeError = 0.01f, MaxAbsoluteError = TimeInterval.FromMilliseconds(1.0d)}
            });
            
            AddExporter(CsvExporter.Default);
            AddExporter(MarkdownExporter.GitHub);
            AddExporter(HtmlExporter.Default);

        }
    }
}