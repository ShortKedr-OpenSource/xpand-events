using System;

namespace Xpand.Events {
    
    public class XSafeOrderedArgEvent<TSender, TEventArgs> : BaseOrderedEvent<ArgsEventHandler<TSender, TEventArgs>> 
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

    public class XSafeOrderedArgEvent<TEventArgs> : BaseOrderedEvent<ArgsEventHandler<TEventArgs>> where TEventArgs : EventArgs {
        
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