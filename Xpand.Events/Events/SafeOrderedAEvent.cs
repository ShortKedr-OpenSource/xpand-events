using System;

namespace Xpand.Events {
    
    public class SafeOrderedAEvent<TSender, TEventArgs> : BaseOrderedEvent<EventHandler<TSender, TEventArgs>> 
        where TEventArgs : EventArgs
    {

        public void Invoke(TSender sender, TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            var orderLists = _subscriptions.Values;
            for (int i = 0; i < orderLists.Count; i++) {
                var subscriptions = orderLists[i];
                for (int j = 0; j < subscriptions.Count; j++) {
                    try {
                        subscriptions[j].Invoke(sender, args);
                    } catch(Exception e){
                        XEventLogger.LogException(e);
                    }
                }
            }
        }

    }

    public class SafeOrderedAEvent<TEventArgs> : BaseOrderedEvent<EventHandler<TEventArgs>> where TEventArgs : EventArgs {
        
        public void Invoke(TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            var orderLists = _subscriptions.Values;
            for (int i = 0; i < orderLists.Count; i++) {
                var subscriptions = orderLists[i];
                for (int j = 0; j < subscriptions.Count; j++) {
                    try {
                        subscriptions[j].Invoke(args);
                    } catch(Exception e){
                        XEventLogger.LogException(e);
                    }
                }
            }
        }
        
    }
}