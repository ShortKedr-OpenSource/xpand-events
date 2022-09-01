using System;
using Xpand.Events.Delegates;

namespace Xpand.Events {
    //TODO implement and correlate names with other XEvent. Make it easy to remember in use of different types of events
    public class EventHandlerEvent<TSender, TEventArgs> : BaseEvent<EventHandler<TSender, TEventArgs>> 
        where TEventArgs : EventArgs
    {

        public void Invoke(TSender sender, TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            for (int i = 0; i < _subscriptions.Count; i++) {
                _subscriptions[i].Invoke(sender, args);
            }
        }

    }
}