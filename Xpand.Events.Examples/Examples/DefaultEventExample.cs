using System;

namespace Xpand.Events.Examples {
    
    public class DefaultEventEntity {

        private string _value = "";

        public readonly XEvent<DefaultEventEntity, string> OnValueChangeEvent = new();
        
        public string Value {
            get => _value;
            set {
                _value = value;
                OnValueChangeEvent.Invoke(this, _value);
            }
        }
        
    }
    
    public static class DefaultEventExample {

        private static DefaultEventEntity _entity;
        
        public static void Main(string[] args) {
            _entity = new DefaultEventEntity();
            _entity.OnValueChangeEvent.AddListener(Event_ValueChange);
            
            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            _entity.Value = "Hello There!";
            
            _entity.OnValueChangeEvent.Suspend();
            _entity.Value = "I changed value but you don't notice!"; // You won't catch this change, since event is suspended
            _entity.OnValueChangeEvent.Unsuspend();

            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            
            _entity.Value = "Greetings!";
        }
        
        private static void Event_ValueChange(DefaultEventEntity sender, string newValue) {
            Console.WriteLine($"Notice! Value was changed in {sender.GetType().Name}. New value is \"{newValue}\"");
        }
    }
}