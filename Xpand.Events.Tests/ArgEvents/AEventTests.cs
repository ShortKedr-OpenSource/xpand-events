using System;
using NUnit.Framework;
using EventHandler = Xpand.Events.EventHandler<System.EventArgs>;

namespace Xpand.Events.Tests {
    [TestFixture]
    public class AEventTests {

        [Test]
        public void AddRemoveContainsOps() {
            AEvent<EventArgs> ev = new AEvent<EventArgs>();
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
            AEvent<EventArgs> ev = new AEvent<EventArgs>();
            EventHandler listener = (args) => {};
            bool a1 = ev.AddListener(listener);
            bool a2 = ev.AddListener(listener);
            Assert.IsTrue(a1 && !a2);
        }

        [Test]
        public void NullSafeInvoke() {
            //TODO use listener from external dll, dealloc it before use
            AEvent<EventArgs> ev = new AEvent<EventArgs>();
            ev.AddListener(null);
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(ev.Subscriptions.Length == 0);
        }

        [Test]
        public void SuspendWorks() {
            AEvent<EventArgs> ev = new AEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Suspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(!wasCalled);
        }
        
        [Test]
        public void UnsuspendWorks() {
            AEvent<EventArgs> ev = new AEvent<EventArgs>();
            bool wasCalled = false;
            EventHandler listener = (args) => wasCalled = true;
            ev.AddListener(listener);
            ev.Unsuspend();
            ev.Invoke(EventArgs.Empty);
            Assert.IsTrue(wasCalled);
        }
    }
}