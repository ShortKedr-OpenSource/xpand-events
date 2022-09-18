using System;

namespace Xpand.Events.Examples {
    
    public class ValueChangeEventArgs : EventArgs {
        public ArgEventEntity Sender { get; set; }
        public string NewValue { get; set; }
    }

    public class ArgEventEntity {

        private string _value = "";

        public readonly XEvent<ValueChangeEventArgs> OnValueChangeEvent = new();
        
        public string Value {
            get => _value;
            set {
                _value = value;
                OnValueChangeEvent.Invoke(new ValueChangeEventArgs(){ Sender = this, NewValue = _value });
            }
        }
        
    }
    
    public static class ArgEventExample {

        private static ArgEventEntity _entity;
        
        public static void Main(string[] args) {

            _entity = new ArgEventEntity();
            _entity.OnValueChangeEvent.AddListener(Event_ValueChange);
            
            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            _entity.Value = "Hello There!";
            
            _entity.OnValueChangeEvent.Suspend();
            _entity.Value = "I changed value but you don't notice!"; // You won't catch this change, since event is suspended
            _entity.OnValueChangeEvent.Unsuspend();

            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            
            _entity.Value = "Greetings!";
            
        }
        
        private static void Event_ValueChange(ValueChangeEventArgs valueArgs) {
            Console.WriteLine($"Notice! Value was changed in {valueArgs.Sender.GetType().Name}. New value is \"{valueArgs.NewValue}\"");
        }
    }

}