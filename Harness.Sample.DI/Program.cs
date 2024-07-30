using Harness.Sample.DI;

INotification mailNotification = new MailNotification();
var notifyViaEmail = new NotificationManager(mailNotification);
notifyViaEmail.SendMessage("Hello from console!");

INotification smsNotification = new SmsNotification();
var notifyViaSms = new NotificationManager(smsNotification);
notifyViaSms.SendMessage("Hello from console!");

Console.WriteLine("Message sent!");
Console.ReadLine();