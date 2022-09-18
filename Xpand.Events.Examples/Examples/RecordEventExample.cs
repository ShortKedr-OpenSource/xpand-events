using System;

namespace Xpand.Events.Examples {

    public class RecordEventEntity {

        private string _value = "";

        public record ValueChangeRecord(object Sender, string NewValue); //Very similar to delegate usage. Shortest version of EventArgs;
        
        public readonly XEvent<ValueChangeRecord> OnValueChangeEvent = new();
        
        public string Value {
            get => _value;
            set {
                _value = value;
                OnValueChangeEvent.Invoke(new (this, _value));
            }
        }
        
    }
    
    
    public class RecordEventExample {

        private static RecordEventEntity _entity;
        
        public static void Main(string[] args) {

            _entity = new RecordEventEntity();
            _entity.OnValueChangeEvent.AddListener(Event_ValueChange);
            
            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            _entity.Value = "Hello There!";
            
            _entity.OnValueChangeEvent.Suspend();
            _entity.Value = "I changed value but you don't notice!"; // You won't catch this change, since event is suspended
            _entity.OnValueChangeEvent.Unsuspend();

            Console.WriteLine($"Current value: \"{_entity.Value}\"");
            
            _entity.Value = "Greetings!";
            
        }
        
        private static void Event_ValueChange(RecordEventEntity.ValueChangeRecord eventArgs) {
            Console.WriteLine($"Notice! Value was changed in {eventArgs.Sender.GetType().Name}. New value is \"{eventArgs.NewValue}\"");
        }
    }
}