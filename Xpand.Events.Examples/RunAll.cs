using System;

namespace Xpand.Events.Examples {
    public static class RunAll {
        
        private delegate void EntryPoint(string[] args);
        
        public static void Main(string[] args) {
            Run(EventsBasicExample.Main);
            Run(ArgEventsExample.Main);
            Run(AsyncEventsExample.Main);
            Run(MultithreadingExample.Main);
        }

        private static void Run(EntryPoint entryPoint) {
            string name = entryPoint.Method?.DeclaringType?.Name;
            Console.WriteLine($"\n// Executing example: {name}\n");
            entryPoint?.Invoke(Array.Empty<string>());
            Console.WriteLine($"\n// Complete example: {name}\n");
        }
        
    }
}