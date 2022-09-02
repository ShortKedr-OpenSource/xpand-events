using System;

namespace Xpand.Events.Examples {
    //TODO rename it
    public static class ArgEventsExample {
        public static void Main(string[] args) {
            Console.WriteLine("Args");
            //TODO implement handle event example
        }
    }

    public class MyEvent : SafeOrderedXArgEvent<string, EventArgs>{}
}