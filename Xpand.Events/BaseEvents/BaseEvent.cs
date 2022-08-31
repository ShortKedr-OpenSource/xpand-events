using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xpand.Events.Interface;

namespace Xpand.Events {
    /// <summary>
    /// Base event class
    /// </summary>
    /// <typeparam name="T">event delegate type</typeparam>
    public abstract class BaseEvent<T> : ISuspendable where T : Delegate {

        protected List<T> _subscriptions;
        protected HashSet<T> _subscriptionsCache;
        private bool _isSuspended;


        public bool IsSuspended => _isSuspended;

        public T[] Subscriptions => _subscriptions.ToArray();


        public BaseEvent() {
            _subscriptions = new List<T>(XpandEventsConfig.DefaultSubscriptionsBuffer);
            _subscriptionsCache = new HashSet<T>();
            _isSuspended = false;
        }

        public bool AddListener(T listener) {
            if (_subscriptionsCache.Contains(listener)) return false;
            _subscriptions.Add(listener);
            _subscriptionsCache.Add(listener);
            return true;
        }

        public bool RemoveListener(T listener) {
            if (!_subscriptionsCache.Contains(listener)) return false;
            _subscriptionsCache.Remove(listener);
            return _subscriptions.Remove(listener);
        }

        public bool Contains(T listener) {
            return _subscriptionsCache.Contains(listener);
        }

        public void Suspend() {
            _isSuspended = true;
        }

        public void Unsuspend() {
            _isSuspended = false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void PrepareInvoke() {
            RemoveNullSubscriptions();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RemoveNullSubscriptions() {
            for (int i = _subscriptions.Count-1; i >= 0; i--) {
                if (_subscriptions[i] == null) _subscriptions.RemoveAt(i);
            }
        }

    }
}