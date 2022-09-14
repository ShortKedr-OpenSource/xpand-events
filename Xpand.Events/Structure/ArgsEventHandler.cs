namespace Xpand.Events {
    public delegate void ArgsEventHandler<in TEventArgs>(TEventArgs args) where TEventArgs : EventArgs;
    public delegate void ArgsEventHandler<in TSender, in TEventArgs>(TSender sender, TEventArgs args) where TEventArgs : EventArgs;
}