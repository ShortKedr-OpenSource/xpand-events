namespace Xpand.Events.Interface {
    public interface ISuspendable {
        public bool IsSuspended { get; }
        public void Suspend();
        public void Unsuspend();
    }
}