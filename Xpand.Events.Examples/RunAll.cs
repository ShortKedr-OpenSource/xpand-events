using System;
using System.Drawing;

namespace Xpand.Events.Examples {
    public static class RunAll {
        
        private delegate void EntryPoint(string[] args);
        
        public static void Main(string[] args) {

            EntryPoint[] examples = {
                DefaultEventExample.Main,
                ArgEventExample.Main,
                TupleEventExample.Main,
                RecordEventExample.Main
            };
            
            RunMultiple(examples);
            
        }

        private static void Run(EntryPoint entryPoint) {
            string name = entryPoint.Method?.DeclaringType?.Name;
            ConsoleColor currentColor = Console.ForegroundColor;
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n>> Executing example: {name}");
            Console.ForegroundColor = currentColor;
            
            entryPoint?.Invoke(Array.Empty<string>());
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"<< Complete example: {name}\n");
            Console.ForegroundColor = currentColor;
            
        }

        private static void RunMultiple(EntryPoint[] entryPoints) {
            foreach (var entryPoint in entryPoints) Run(entryPoint);
        }
        
    }
}