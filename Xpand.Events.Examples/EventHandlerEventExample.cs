using System;
using System.Diagnostics;

namespace Xpand.Events.Examples {
    //TODO remove this example, add another one
    public class EventHandlerEventExample {
        public static void Main(string[] args) {

            string sender = "Sender";

            EventHandlerEvent<string, MyEventArgs> ev = new EventHandlerEvent<string, MyEventArgs>();
            
            ev.AddListener((s, eventArgs) => {
                Console.WriteLine($"Sender: {sender}");
                Console.WriteLine($"IntValue: {eventArgs.IntValue}");
                Console.WriteLine($"StringValue: {eventArgs.StringValue}");
            });
            
            ev.Invoke(sender, new MyEventArgs() { IntValue = 5, StringValue = "Hello world!" });
        }

        public class MyEventArgs : EventArgs {
            public int IntValue { get; init; }
            public string StringValue { get; init; }
            
            
        }
    }
}