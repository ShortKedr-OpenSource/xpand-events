
public class XEvent : BaseEvent<Event<>> {

    public void Invoke(>){
        for (int i = 0; i < _subscriptions.Count; i++) {
            _subscriptions[i].Invoke();
        }
    }

}

