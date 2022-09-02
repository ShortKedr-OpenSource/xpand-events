using System;
using NUnit.Framework;
using EventHandler = Xpand.Events.EventHandler<System.EventArgs>;

namespace Xpand.Events.Tests {
    [TestFixture]
    public class SafeAEventTests {
        [Test]
        public void AddRemoveContainsOps() {
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
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
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            EventHandler listener = (args) => {};
            bool a1 = ev.AddListener(listener);
            bool a2 = ev.AddListener(listener);
            Assert.IsTrue(a1 && !a2);
        }

        [Test]
        public void NullSafeInvoke() {
            //TODO use listener from external dll, dealloc it before use
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            ev.AddListener(null);
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(ev.Subscriptions.Length == 0);
        }

        [Test]
        public void SuspendWorks() {
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Suspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(!wasCalled);
        }
        
        [Test]
        public void UnsuspendWorks() {
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Unsuspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void ExceptionCatch() {
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            EventHandler listener = (args) => throw new Exception();
            ev.AddListener(listener);
            ev.Invoke(EventArgs.Empty);
            Assert.Pass();
        }

        [Test]
        public void Logging() {
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            EventHandler listener = (args) => throw new Exception();
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
            SafeXArgEvent<EventArgs> ev = new SafeXArgEvent<EventArgs>();
            EventHandler listener = (args) => throw new Exception();
            ev.AddListener(listener);
            
            bool wasCalled = false;
            XpandEventsConfig.LogLevel = LogLevel.None;
            XEventLogger.ExceptionDelegate exListener = exception => wasCalled = true;
            XEventLogger.ImplicitException += exListener;
            ev.Invoke(EventArgs.Empty);
            XEventLogger.ImplicitException -= exListener;
            
            Assert.IsTrue(wasCalled);
        }
    }
}