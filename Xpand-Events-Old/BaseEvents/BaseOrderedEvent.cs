using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xpand.Events.Interface;

namespace Xpand.Events {
    public abstract class BaseOrderedEvent<T> : ISuspendable where T : Delegate {
        
        protected SortedList<int, List<T>> _subscriptions;
        protected Dictionary<T, int> _orderBySubscriptionDict;
        private bool _isSuspended;

        
        public bool IsSuspended => _isSuspended;


        public BaseOrderedEvent() {
            _subscriptions = new SortedList<int, List<T>>(XpandEventsConfig.DefaultSubscriptionsBuffer);
            _orderBySubscriptionDict = new Dictionary<T, int>(XpandEventsConfig.DefaultSubscriptionsBuffer);
            _isSuspended = false;
        }

        public bool AddListener(T listener, int priority = 0) {
            if (_orderBySubscriptionDict.ContainsKey(listener)) return false;
            int order = ComputeOrderByPriority(priority);
            if (!_subscriptions.ContainsKey(order)) _subscriptions.Add(order, new List<T>(XpandEventsConfig.DefaultSubscriptionsBuffer));
            _subscriptions[order].Add(listener);
            _orderBySubscriptionDict.Add(listener, order);
            return true;
        }

        public bool RemoveListener(T listener) {
            if (!_orderBySubscriptionDict.ContainsKey(listener)) return false;
            int order = _orderBySubscriptionDict[listener];
            _orderBySubscriptionDict.Remove(listener);
            return _subscriptions[order].Remove(listener);
        }
        
        public bool Contains(T listener) {
            return _orderBySubscriptionDict.ContainsKey(listener);
        }

        public void Suspend() {
            _isSuspended = true;
        }

        public void Unsuspend() {
            _isSuspended = false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void PrepareInvoke() {
            RemoveNullSubscriptions();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RemoveNullSubscriptions() {
            IList<List<T>> orderLists = _subscriptions.Values;
            for (int i = 0; i < orderLists.Count; i++) {
                List<T> list = orderLists[i];
                for (int j = list.Count - 1; j >= 0; j--) {
                    if (list[j] == null) list.RemoveAt(j);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ComputeOrderByPriority(int priority) {
            return int.MaxValue - priority;
        }

    }
}