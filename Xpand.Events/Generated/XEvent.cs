

namespace Xpand.Events { 

    public class XEvent : BaseEvent<Event> {

        public void Invoke(){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke();
            }
        }

    }

    public class XEvent<T> : BaseEvent<Event<T>> {

        public void Invoke(T value){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value);
            }
        }

    }

    public class XEvent<T1, T2> : BaseEvent<Event<T1, T2>> {

        public void Invoke(T1 value1, T2 value2){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2);
            }
        }

    }

    public class XEvent<T1, T2, T3> : BaseEvent<Event<T1, T2, T3>> {

        public void Invoke(T1 value1, T2 value2, T3 value3){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4> : BaseEvent<Event<T1, T2, T3, T4>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5> : BaseEvent<Event<T1, T2, T3, T4, T5>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6> : BaseEvent<Event<T1, T2, T3, T4, T5, T6>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14, T15 value15){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14, value15);
            }
        }

    }

    public class XEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14, T15 value15, T16 value16){
            if (IsSuspended) return;
            PrepareInvoke();
            var subscriptions = GetImmutableSubscriptionArray();
            for (int i = 0; i < subscriptions.Length; i++) {
                subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14, value15, value16);
            }
        }

    }


}