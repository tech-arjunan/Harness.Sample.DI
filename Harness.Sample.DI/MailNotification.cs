namespace Harness.Sample.DI
{
    internal class SmsNotification : INotification
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Message from Sms: {message}");
        }
    }
}
