using System;
using System.Collections.Generic;
using NUnit.Framework;
using ArgsEventHandler = Xpand.Events.ArgsEventHandler<Xpand.Events.EventArgs>;

namespace Xpand.Events.Tests {
    [TestFixture]
    public class SafeOrderedAEventTests {
        
        [Test]
        public void AddRemoveContainsOps() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            bool wasCalled = false;
            ArgsEventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Invoke(EventArgs.Empty);
            bool con1 = ev.Contains(listener);
            bool rem = ev.RemoveListener(listener);
            bool con2 = ev.Contains(listener);
            Assert.IsTrue(wasCalled && con1 && rem && !con2);
        }
        
        [Test]
        public void NoDuplicateListeners() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            ArgsEventHandler listener = (args) => {};
            bool a1 = ev.AddListener(listener);
            bool a2 = ev.AddListener(listener);
            Assert.IsTrue(a1 && !a2);
        }

        [Test]
        public void NullSafeInvoke() {
            //TODO use listener from external dll, dealloc it before use
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            ev.AddListener(null);
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(ev.Subscriptions.Length == 0);
        }

        [Test]
        public void SuspendWorks() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            bool wasCalled = false;
            ArgsEventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Suspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(!wasCalled);
        }
        
        [Test]
        public void UnsuspendWorks() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            bool wasCalled = false;
            ArgsEventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Unsuspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void ExceptionCatch() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            ArgsEventHandler listener = (args) => throw new Exception();
            ev.AddListener(listener);
            ev.Invoke(EventArgs.Empty);
            Assert.Pass();
        }

        [Test]
        public void Logging() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            ArgsEventHandler listener = (args) => throw new Exception();
            ev.AddListener(listener);
            
            bool wasOnCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.Exception;
            XEventLogger.ExceptionDelegate onExListener = exception => wasOnCalled = true;
            XEventLogger.Exception += onExListener;
            ev.Invoke(EventArgs.Empty);
            XEventLogger.Exception -= onExListener;
            
            bool wasOffCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.None;
            XEventLogger.ExceptionDelegate offExListener = exception => wasOffCalled = true;
            XEventLogger.Exception += offExListener;
            ev.Invoke(EventArgs.Empty);
            XEventLogger.Exception -= offExListener;
            
            Assert.IsTrue(wasOnCalled && !wasOffCalled);
        }

        [Test]
        public void ImplicitLogging() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            ArgsEventHandler listener = (args) => throw new Exception();
            ev.AddListener(listener);
            
            bool wasCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.None;
            XEventLogger.ExceptionDelegate exListener = exception => wasCalled = true;
            XEventLogger.ImplicitException += exListener;
            ev.Invoke(EventArgs.Empty);
            XEventLogger.ImplicitException -= exListener;
            
            Assert.IsTrue(wasCalled);
        }
        
        [Test]
        public void SubscriptionsArrayOrder() {
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            List<int> callStack = new List<int>();
            
            ArgsEventHandler l1 = (args) => { callStack.Add(1); };
            ArgsEventHandler l2 = (args) => { callStack.Add(2); };
            ArgsEventHandler l3 = (args) => { callStack.Add(3); };
            ArgsEventHandler l4 = (args) => { callStack.Add(4); };
            ArgsEventHandler l5 = (args) => { callStack.Add(5);};
            ArgsEventHandler l6 = (args) => { callStack.Add(6);};
            ArgsEventHandler l7 = (args) => { callStack.Add(7);};
            ArgsEventHandler l8 = (args) => { callStack.Add(8);};
            ArgsEventHandler l9 = (args) => { callStack.Add(9);};

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
            SafeOrderedXArgEvent<EventArgs> ev = new SafeOrderedXArgEvent<EventArgs>();
            List<int> callStack = new List<int>();
            List<Action> addActions = new List<Action>();
            
            ArgsEventHandler l1 = (args) => { callStack.Add(1); };
            ArgsEventHandler l2 = (args) => { callStack.Add(2); };
            ArgsEventHandler l3 = (args) => { callStack.Add(3); };
            ArgsEventHandler l4 = (args) => { callStack.Add(4); };
            ArgsEventHandler l5 = (args) => { callStack.Add(5);};
            ArgsEventHandler l6 = (args) => { callStack.Add(6);};
            ArgsEventHandler l7 = (args) => { callStack.Add(7);};
            ArgsEventHandler l8 = (args) => { callStack.Add(8);};
            ArgsEventHandler l9 = (args) => { callStack.Add(9);};

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