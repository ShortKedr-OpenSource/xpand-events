using System;

namespace Xpand.Events.Benchmark.SupportingTypes {
    public static class FakeLogger {

        public static bool CanLog = false;
        
        public static void Log(string message) {
            if (CanLog) Console.WriteLine(message);
        }
    }
}