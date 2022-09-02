using System;

namespace Xpand.Events.Benchmark.SupportingTypes {
    public class SenderEventArgs : EventArgs {
        public int IntArg { get; set; }
        public float FloatArg { get; set; }
        public double DoubleArg { get; set; }
        public string StringArg { get; set; }
    }
}