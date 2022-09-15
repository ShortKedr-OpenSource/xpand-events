using System;
using System.Collections;

namespace Xpand.Events.TupleEvents {
    public class XSafeTupleEvent<TTupleType> : BaseEvent<TupleEventHandler<TTupleType>> 
        where TTupleType : IStructuralEquatable, IStructuralComparable, IComparable 
    {
        
        public void Invoke(TTupleType args) {
            if (IsSuspended) return;
            PrepareInvoke();
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(args);
                } catch(Exception e){
                    XEventLogger.LogException(e);
                }
            }
        }
    }
}