using System;
using NUnit.Framework;
using Xpand.Events;

namespace Tests {
    public class Tests {

        public delegate void MyAction();
        
        [Test]
        public void Test1() {
            /*CodeGenXEvent xevent = new CodeGenXEvent();
            xevent.Invoke();*/

            XEvent<int, int> ev = new XEvent<int, int>();
            ev.AddListener((value1, value2) => {
                Console.WriteLine($"{value1} {value2}");
            });
            ev.Invoke(5, 5);
        }
    }
}