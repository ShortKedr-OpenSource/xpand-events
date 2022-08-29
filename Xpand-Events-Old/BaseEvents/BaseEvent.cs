using System;
using System.Collections.Generic;

namespace Xpand.Events {
    //TODO auto null checking
    //TODO ability to use interfaces instead of delegate
    public abstract class BaseEvent<T> where T : Delegate {
        
        protected List<T> _subscriptions;

        public BaseEvent() {
            _subscriptions = new List<T>(XpandEventsConfig.DefaultSubscriptionsBuffer);
        }

        public void AddListener(T listener) {
            _subscriptions.Add(listener);
        }

        public void AddListener(T listener, int priority) {
            
        }
        
        public void RemoveListener(T listener) {
            _subscriptions.Remove(listener);
        }

        private void PrepareInvoke() {
            RemoveNullSubscriptions();
        }

        private void RemoveNullSubscriptions() {
            for (int i = _subscriptions.Count-1; i >= 0; i--) {
                if (_subscriptions[i] == null) _subscriptions.RemoveAt(i);
            }
        }

    }
}