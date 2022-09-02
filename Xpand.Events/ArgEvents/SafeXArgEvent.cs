using System;

namespace Xpand.Events {
    
    public class SafeXArgEvent<TSender, TEventArgs> : BaseEvent<EventHandler<TSender, TEventArgs>> 
        where TEventArgs : EventArgs
    {

        public void Invoke(TSender sender, TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(sender, args);
                } catch(Exception e){
                    XEventLogger.LogException(e);
                }
            }
        }

    }

    public class SafeXArgEvent<TEventArgs> : BaseEvent<EventHandler<TEventArgs>> where TEventArgs : EventArgs {
        
        public void Invoke(TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(args);
                } catch(Exception e){
                    XEventLogger.LogException(e);
                }
            }
        }
        
    }
    
}