using System;
using System.Collections.Generic;
using NUnit.Framework;
using EventHandler = Xpand.Events.EventHandler<System.EventArgs>;

namespace Xpand.Events.Tests {
    [TestFixture]
    public class OrderedAEventTests {
        
        [Test]
        public void AddRemoveContainsOps() {
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Invoke(EventArgs.Empty);
            bool con1 = ev.Contains(listener);
            bool rem = ev.RemoveListener(listener);
            bool con2 = ev.Contains(listener);
            Assert.IsTrue(wasCalled && con1 && rem && !con2);
        }
        
        [Test]
        public void NoDuplicateListeners() {
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            EventHandler listener = (args) => {};
            bool a1 = ev.AddListener(listener);
            bool a2 = ev.AddListener(listener);
            Assert.IsTrue(a1 && !a2);
        }

        [Test]
        public void NullSafeInvoke() {
            //TODO use listener from external dll, dealloc it before use
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            ev.AddListener(null);
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(ev.Subscriptions.Length == 0);
        }

        [Test]
        public void SuspendWorks() {
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Suspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(!wasCalled);
        }
        
        [Test]
        public void UnsuspendWorks() {
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Unsuspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void SubscriptionsArrayOrder() {
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            List<int> callStack = new List<int>();
            
            EventHandler l1 = (args) => { callStack.Add(1); };
            EventHandler l2 = (args) => { callStack.Add(2); };
            EventHandler l3 = (args) => { callStack.Add(3); };
            EventHandler l4 = (args) => { callStack.Add(4); };
            EventHandler l5 = (args) => { callStack.Add(5);};
            EventHandler l6 = (args) => { callStack.Add(6);};
            EventHandler l7 = (args) => { callStack.Add(7);};
            EventHandler l8 = (args) => { callStack.Add(8);};
            EventHandler l9 = (args) => { callStack.Add(9);};

            ev.AddListener(l2, 1);
            ev.AddListener(l1, 4);
            ev.AddListener(l3, 0);
            ev.AddListener(l4,2);
            ev.AddListener(l5, 3);
            ev.AddListener(l6, 0);
            ev.AddListener(l7, 4);
            ev.AddListener(l8, 1);
            ev.AddListener(l9, 2);
            
            var subscriptions = ev.Subscriptions;
            if (subscriptions.Length != 9) Assert.Fail($"Expected count: 9; Real count:{subscriptions.Length}");
            for (int i = 0; i < subscriptions.Length; i++) subscriptions[i].Invoke(EventArgs.Empty);
            
            int expectedOrder = 175492836;
            int builtOrder = 0;
            for (int i = 0; i < callStack.Count; i++) builtOrder += callStack[i] * (int)Math.Pow(10, callStack.Count-i-1);
            Assert.IsTrue(builtOrder == expectedOrder, $"Expected order: {expectedOrder}; Built order: {builtOrder}");
        }

        [Test]
        public void InvokeOrder() {
            OrderedAEvent<EventArgs> ev = new OrderedAEvent<EventArgs>();
            List<int> callStack = new List<int>();
            List<Action> addActions = new List<Action>();

            
            EventHandler l1 = (args) => { callStack.Add(1); };
            EventHandler l2 = (args) => { callStack.Add(2); };
            EventHandler l3 = (args) => { callStack.Add(3); };
            EventHandler l4 = (args) => { callStack.Add(4); };
            EventHandler l5 = (args) => { callStack.Add(5);};
            EventHandler l6 = (args) => { callStack.Add(6);};
            EventHandler l7 = (args) => { callStack.Add(7);};
            EventHandler l8 = (args) => { callStack.Add(8);};
            EventHandler l9 = (args) => { callStack.Add(9);};

            ev.AddListener(l2, 1);
            ev.AddListener(l1, 4);
            ev.AddListener(l3, 0);
            ev.AddListener(l4,2);
            ev.AddListener(l5, 3);
            ev.AddListener(l6, 0);
            ev.AddListener(l7, 4);
            ev.AddListener(l8, 1);
            ev.AddListener(l9, 2);

            ev.Invoke(EventArgs.Empty);
            
            int expectedOrder = 175492836;
            int builtOrder = 0;
            for (int i = 0; i < callStack.Count; i++) builtOrder += callStack[i] * (int)Math.Pow(10, callStack.Count-i-1);
            Assert.IsTrue(builtOrder == expectedOrder, $"Expected order: {expectedOrder}; Built order: {builtOrder}");
        }
        
    }
}