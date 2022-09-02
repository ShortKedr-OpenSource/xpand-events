﻿using System;

namespace Xpand.Events {
    
    public class XArgEvent<TSender, TEventArgs> : BaseEvent<EventHandler<TSender, TEventArgs>> 
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

    public class XArgEvent<TEventArgs> : BaseEvent<EventHandler<TEventArgs>> where TEventArgs : EventArgs {
        
        public void Invoke(TEventArgs args) {
            if (IsSuspended) return;
            PrepareInvoke();
            for (int i = 0; i < _subscriptions.Count; i++) {
                _subscriptions[i].Invoke(args);
            }
        }
        
    }
    
}