namespace Harness.Sample.DI
{
    internal class MailNotification : INotification
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Message from Mail: {message}");
        }
    }
}
