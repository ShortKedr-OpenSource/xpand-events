﻿using BenchmarkDotNet.Attributes;
using Xpand.Events.Benchmark.Configs;

namespace Xpand.Events.Benchmark {

    [Config(typeof(NoArgsUnsubscribeConfig))]
    public class NoArgsUnsubscribeBenchmark {
        
    }
}