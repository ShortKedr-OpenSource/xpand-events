using System;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Xpand.Events.Benchmark {
    public static class Run {

        public delegate Summary BenchmarkEntry(IConfig config = null, string[] args = null);
            
        public static readonly BenchmarkEntry[] BenchmarkEntries = {
            BenchmarkRunner.Run<NoArgsInvokeBenchmark>,
            BenchmarkRunner.Run<NoArgsSubscribeBenchmark>,
            BenchmarkRunner.Run<NoArgsUnsubscribeBenchmark>,
            BenchmarkRunner.Run<WithArgsInvokeBenchmark>,
            BenchmarkRunner.Run<WithArgsSubscribeBenchmark>,
            BenchmarkRunner.Run<WithArgsUnsubscribeBenchmark>,
        };
            
            
        public static void Main(string[] args) {
            if (args.Contains("-all")) {
                Console.WriteLine("All argument was found, starting all mode!");
                AllMode();
            } else {
                Console.WriteLine("No arguments was found, starting selection mode!");
                SelectionMode();
            }
        }

        public static void AllMode() {
            for (int i = 0; i < BenchmarkEntries.Length; i++) {
                var summary = BenchmarkEntries[i].Invoke();
            }
        }
        
        public static void SelectionMode() {
            SelectionModeStart:
            Console.WriteLine("Select benchmark to run: ");
            for (int i = 0; i < BenchmarkEntries.Length; i++) {
                Console.WriteLine($"{i+1}. {BenchmarkEntries[i].Method.GetGenericArguments()[0].Name}");
            }
            Console.Write("Witch one to run?: ");
            string answer = Console.ReadLine();
            int parsedAnswer = -1;
            if (int.TryParse(answer, out parsedAnswer) && parsedAnswer >= 1 && parsedAnswer <= BenchmarkEntries.Length) {
                var summary = BenchmarkEntries[parsedAnswer].Invoke();
            } else {
                Console.WriteLine("Number is out of range, try again!");
                goto SelectionModeStart;
            }
        }
    }
}