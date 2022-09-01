using System;

namespace Xpand.Events {
    public class OrderedAEvent<TSender, TEventArgs> : BaseOrderedEvent<EventHandler<TSender, TEventArgs>> 
        where TEventArgs : EventArgs
    {

        public void Invoke(TSender sender, TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            var orderLists = _subscriptions.Values;
            for (int i = 0; i < orderLists.Count; i++) {
                var subscriptions = orderLists[i];
                for (int j = 0; j < subscriptions.Count; j++) {
                    subscriptions[j].Invoke(sender, args);
                }
            }
        }

    }

    public class OrderedAEvent<TEventArgs> : BaseOrderedEvent<EventHandler<TEventArgs>> where TEventArgs : EventArgs {
        
        public void Invoke(TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            var orderLists = _subscriptions.Values;
            for (int i = 0; i < orderLists.Count; i++) {
                var subscriptions = orderLists[i];
                for (int j = 0; j < subscriptions.Count; j++) {
                    subscriptions[j].Invoke(args);
                }
            }
        }
        
    }
}