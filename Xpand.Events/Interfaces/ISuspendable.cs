namespace Xpand.Events.Interfaces {
    public interface ISuspendable {
        public bool IsSuspended { get; }
        public void Suspend();
        public void Unsuspend();
    }
}