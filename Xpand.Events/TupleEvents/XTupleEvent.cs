using System;
using System.Collections;

namespace Xpand.Events.TupleEvents {
    public class XTupleEvent<TTupleType> : BaseEvent<TupleEventHandler<TTupleType>> 
        where TTupleType : IStructuralEquatable, IStructuralComparable, IComparable
    {
        
        public void Invoke(TTupleType args) {
            if (IsSuspended) return;
            PrepareInvoke();
            for (int i = 0; i < _subscriptions.Count; i++) {
                _subscriptions[i].Invoke(args);
            }
        }
        
    }
}