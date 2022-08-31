using System;
using System.Collections.Generic;
using NUnit.Framework;
using Xpand.Events;

namespace Tests {
    [TestFixture]
    public class SafeOrderedXEventTests {
        
        [Test]
        public void AddRemoveContainsOps() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            bool wasCalled = false;
            Event listener = () => wasCalled = true;
            ev.AddListener(listener);
            ev.Invoke();
            bool con1 = ev.Contains(listener);
            bool rem = ev.RemoveListener(listener);
            bool con2 = ev.Contains(listener);
            Assert.IsTrue(wasCalled && con1 && rem && !con2);
        }
        
        [Test]
        public void NoDuplicateListeners() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            Event listener = () => {};
            bool a1 = ev.AddListener(listener);
            bool a2 = ev.AddListener(listener);
            Assert.IsTrue(a1 && !a2);
        }

        [Test]
        public void NullSafeInvoke() {
            //TODO use listener from external dll, dealloc it before use
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            ev.AddListener(null);
            ev.Invoke();
            Assert.IsTrue(ev.Subscriptions.Length == 0);
        }

        [Test]
        public void SuspendWorks() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            bool wasCalled = false;
            Event listener = () => wasCalled = true;
            ev.AddListener(listener);
            ev.Suspend();
            ev.Invoke();
            Assert.IsTrue(!wasCalled);
        }
        
        [Test]
        public void UnsuspendWorks() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            bool wasCalled = false;
            Event listener = () => wasCalled = true;
            ev.AddListener(listener);
            ev.Unsuspend();
            ev.Invoke();
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void ExceptionCatch() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            Event listener = () => throw new Exception();
            ev.AddListener(listener);
            ev.Invoke();
            Assert.Pass();
        }

        [Test]
        public void Logging() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            Event listener = () => throw new Exception();
            ev.AddListener(listener);
            
            bool wasOnCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.Exception;
            XEventLogger.ExceptionDelegate onExListener = exception => wasOnCalled = true;
            XEventLogger.Exception += onExListener;
            ev.Invoke();
            XEventLogger.Exception -= onExListener;
            
            bool wasOffCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.None;
            XEventLogger.ExceptionDelegate offExListener = exception => wasOffCalled = true;
            XEventLogger.Exception += offExListener;
            ev.Invoke();
            XEventLogger.Exception -= offExListener;
            
            Assert.IsTrue(wasOnCalled && !wasOffCalled);
        }

        [Test]
        public void ImplicitLogging() {
            SafeOrderedXEvent ev = new SafeOrderedXEvent();
            Event listener = () => throw new Exception();
            ev.AddListener(listener);
            
            bool wasCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.None;
            XEventLogger.ExceptionDelegate exListener = exception => wasCalled = true;
            XEventLogger.ImplicitException += exListener;
            ev.Invoke();
            XEventLogger.ImplicitException -= exListener;
            
            Assert.IsTrue(wasCalled);
        }
        
        [Test]
        public void SubscriptionsArrayOrder() {
            OrderedXEvent ev = new OrderedXEvent();
            List<int> callStack = new List<int>();
            
            Event l1 = () => { callStack.Add(1); };
            Event l2 = () => { callStack.Add(2); };
            Event l3 = () => { callStack.Add(3); };
            Event l4 = () => { callStack.Add(4); };
            Event l5 = () => { callStack.Add(5);};
            Event l6 = () => { callStack.Add(6);};
            Event l7 = () => { callStack.Add(7);};
            Event l8 = () => { callStack.Add(8);};
            Event l9 = () => { callStack.Add(9);};

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
            for (int i = 0; i < subscriptions.Length; i++) subscriptions[i].Invoke();
            
            int expectedOrder = 175492836;
            int builtOrder = 0;
            for (int i = 0; i < callStack.Count; i++) builtOrder += callStack[i] * (int)Math.Pow(10, callStack.Count-i-1);
            Assert.IsTrue(builtOrder == expectedOrder, $"Expected order: {expectedOrder}; Built order: {builtOrder}");
        }

        [Test]
        public void InvokeOrder() {
            OrderedXEvent ev = new OrderedXEvent();
            List<int> callStack = new List<int>();
            List<Action> addActions = new List<Action>();

            
            Event l1 = () => { callStack.Add(1); };
            Event l2 = () => { callStack.Add(2); };
            Event l3 = () => { callStack.Add(3); };
            Event l4 = () => { callStack.Add(4); };
            Event l5 = () => { callStack.Add(5);};
            Event l6 = () => { callStack.Add(6);};
            Event l7 = () => { callStack.Add(7);};
            Event l8 = () => { callStack.Add(8);};
            Event l9 = () => { callStack.Add(9);};

            ev.AddListener(l2, 1);
            ev.AddListener(l1, 4);
            ev.AddListener(l3, 0);
            ev.AddListener(l4,2);
            ev.AddListener(l5, 3);
            ev.AddListener(l6, 0);
            ev.AddListener(l7, 4);
            ev.AddListener(l8, 1);
            ev.AddListener(l9, 2);

            ev.Invoke();
            
            int expectedOrder = 175492836;
            int builtOrder = 0;
            for (int i = 0; i < callStack.Count; i++) builtOrder += callStack[i] * (int)Math.Pow(10, callStack.Count-i-1);
            Assert.IsTrue(builtOrder == expectedOrder, $"Expected order: {expectedOrder}; Built order: {builtOrder}");
        }
    }
}