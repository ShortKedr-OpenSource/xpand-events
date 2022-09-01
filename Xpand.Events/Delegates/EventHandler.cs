using System;

namespace Xpand.Events {
    public delegate void EventHandler<in TEventArgs>(TEventArgs args) where TEventArgs : EventArgs;
    public delegate void EventHandler<in TSender, in TEventArgs>(TSender sender, TEventArgs args) where TEventArgs : EventArgs;
}