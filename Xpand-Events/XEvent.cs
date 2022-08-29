using System;
using System.Collections.Generic;

namespace Xpand.Events {
    public class XEvent<T> where T : Delegate {

        private List<T> _subsMethods;

        public XEvent() {
            _subsMethods = new List<T>(XEventConfig.DefaultSubscriptionBuffer);
        }
    }
}