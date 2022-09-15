using System;
using System.Collections;

namespace Xpand.Events.TupleEvents {
    public class XSafeOrderedTupleEvent<TTupleType> : BaseOrderedEvent<TupleEventHandler<TTupleType>> 
        where TTupleType : IStructuralEquatable, IStructuralComparable, IComparable
    {
        
        public void Invoke(TTupleType args) {
            if (IsSuspended) return;
            PrepareInvoke();
            var orderLists = _subscriptions.Values;
            for (int i = 0; i < orderLists.Count; i++) {
                var subscriptions = orderLists[i];
                for (int j = 0; j < subscriptions.Count; j++) {
                    try {
                        subscriptions[j].Invoke(args);
                    } catch(Exception e){
                        XEventLogger.LogException(e);
                    }
                }
            }
        }

    }
}