using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xpand.Events.Interfaces;

namespace Xpand.Events {
    public abstract class BaseOrderedEvent<T> : ISuspendable where T : Delegate {
        
        private SortedList<int, List<T>> _subscriptions;
        private Dictionary<T, int> _orderBySubscriptionDict;
        private bool _isSuspended;

        
        public bool IsSuspended => _isSuspended;

        
        public BaseOrderedEvent() {
            _subscriptions = new SortedList<int, List<T>>(XpandEventsConfig.DefaultSubscriptionsBuffer);
            _orderBySubscriptionDict = new Dictionary<T, int>(XpandEventsConfig.DefaultSubscriptionsBuffer);
            _isSuspended = false;
        }

        /// <summary>
        /// Adds new event listener is specified priority.
        /// Priority is optional param, so default priority equals to 0.
        /// Higher the priority, closer the listener to invoke in the invocation queue.
        /// Listeners with same priority value invokes in order they was added to the event.
        /// Null reference listeners can't be added to the ordered event, method will returns False this way.
        /// </summary>
        /// <param name="listener">listener</param>
        /// <param name="priority">invocation priority</param>
        /// <returns>true if listener was added</returns>
        public bool AddListener(T listener, int priority = 0) {
            if (listener == null) return false;
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

        /// <summary>
        /// Return subscriptions array. Subscriptions are already ordered
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[] GetImmutableSubscriptionArray() {
            IList<List<T>> orderLists = _subscriptions.Values;
            int totalCount = 0;
            for (int i = 0; i < orderLists.Count; i++) totalCount += orderLists[i].Count;
            List<T> result = new List<T>(totalCount);
            for (int i = 0; i < orderLists.Count; i++) {
                for (int j = 0; j < orderLists[i].Count; j++) {
                    result.Add(orderLists[i][j]);
                }
            }
            return result.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void PrepareInvoke() {
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