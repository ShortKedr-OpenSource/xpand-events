
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


}

