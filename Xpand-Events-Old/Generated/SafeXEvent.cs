

using System;

namespace Xpand.Events { 

    public class SafeXEvent : BaseEvent<Event> {

        public void Invoke(){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke();
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T> : BaseEvent<Event<T>> {

        public void Invoke(T value){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2> : BaseEvent<Event<T1, T2>> {

        public void Invoke(T1 value1, T2 value2){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3> : BaseEvent<Event<T1, T2, T3>> {

        public void Invoke(T1 value1, T2 value2, T3 value3){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4> : BaseEvent<Event<T1, T2, T3, T4>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5> : BaseEvent<Event<T1, T2, T3, T4, T5>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6> : BaseEvent<Event<T1, T2, T3, T4, T5, T6>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14, T15 value15){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14, value15);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }

    public class SafeXEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : BaseEvent<Event<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> {

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14, T15 value15, T16 value16){
            for (int i = 0; i < _subscriptions.Count; i++) {
                try {
                    _subscriptions[i].Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10, value11, value12, value13, value14, value15, value16);
                } catch(Exception e){
                    //TODO call Exception method
                } 
            }
        }

    }


}

