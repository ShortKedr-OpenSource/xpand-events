using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Xpand.Events;

namespace Tests {
    [TestFixture]
    public class SafeXEventTests {
        [Test]
        public void AddRemoveContainsOps() {
            SafeXEvent ev = new SafeXEvent();
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
            SafeXEvent ev = new SafeXEvent();
            Event listener = () => {};
            bool a1 = ev.AddListener(listener);
            bool a2 = ev.AddListener(listener);
            Assert.IsTrue(a1 && !a2);
        }

        [Test]
        public void NullSafeInvoke() {
            SafeXEvent ev = new SafeXEvent();
            ev.AddListener(null);
            ev.Invoke();
            Assert.IsTrue(ev.Subscriptions.Length == 0);
        }

        [Test]
        public void SuspendWorks() {
            SafeXEvent ev = new SafeXEvent();
            bool wasCalled = false;
            Event listener = () => wasCalled = true;
            ev.AddListener(listener);
            ev.Suspend();
            ev.Invoke();
            Assert.IsTrue(!wasCalled);
        }
        
        [Test]
        public void UnsuspendWorks() {
            SafeXEvent ev = new SafeXEvent();
            bool wasCalled = false;
            Event listener = () => wasCalled = true;
            ev.AddListener(listener);
            ev.Unsuspend();
            ev.Invoke();
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void ExceptionCatch() {
            SafeXEvent ev = new SafeXEvent();
            Event listener = () => throw new Exception();
            ev.AddListener(listener);
            ev.Invoke();
            Assert.Pass();
        }

        [Test]
        public void Logging() {
            SafeXEvent ev = new SafeXEvent();
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
            SafeXEvent ev = new SafeXEvent();
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
    }
}