namespace Harness.Sample.DI
{
    public class NotificationManager
    {
        public readonly INotification _notify;
        public NotificationManager(INotification notify)
        {
            _notify = notify;
        }

        public void SendMessage(string? message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message), "Message is either null or empty.");
            }
            _notify.SendMessage(message);
        }
    }
}
