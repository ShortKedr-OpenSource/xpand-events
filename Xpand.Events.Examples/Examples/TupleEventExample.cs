using System;

namespace Xpand.Events.Examples {
    
    
    public class TupleEventEntity {

        private string _value = "";
        
        public readonly XEvent<(object sender, string newValue)> OnValueChangeEvent = new();
        
        public string Value {
            get => _value;
            set {
                _value = value;
                OnValueChangeEvent.Invoke(new (this, _value));
            }
        }
        
    }
    
    public class TupleEventExample {

        private static TupleEventEntity _entity;
        
        public static void Main(string[] args) {

            _entity = new TupleEventEntity();
            _entity.OnValueChangeEvent.AddListener(Event_ValueChange);
            
            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            _entity.Value = "Hello There!";
            
            _entity.OnValueChangeEvent.Suspend();
            _entity.Value = "I changed value but you don't notice!"; // You won't catch this change, since event is suspended
            _entity.OnValueChangeEvent.Unsuspend();

            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            
            _entity.Value = "Greetings!";
            
        }

        private static void Event_ValueChange((object sender, string newValue) eventArgs) {
            Console.WriteLine($"Notice! Value was changed in {eventArgs.sender.GetType().Name}. New value is \"{eventArgs.newValue}\"");
        }
    }
}