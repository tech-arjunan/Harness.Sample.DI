using Harness.Sample.DI;
using Moq;

namespace Harness.Sample.Tests
{
    [TestFixture]
    public class NotificationTests
    {
        private Mock<INotification> _mockNotification;
        private NotificationManager _notificationManager;

        [SetUp]
        public void SetUp()
        {
            _mockNotification = new Mock<INotification>();
            _notificationManager = new NotificationManager(_mockNotification.Object);
        }

        [Test]
        public void SendMessage_CallsSendMessageOnNotification()
        {
            // Arrange
            string message = "Test message";

            // Act
            _notificationManager.SendMessage(message);

            // Assert
            _mockNotification.Verify(n => n.SendMessage(message), Times.Once);
        }

        [Test]
        public void SendMessage_ThrowsArgumentNullExceptionIfMessageIsNull()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => _notificationManager.SendMessage(null));
            Assert.That(ex.ParamName, Is.EqualTo("message"));
            Assert.That(ex.Message, Contains.Substring("Message is either null or empty."));
        }

        [Test]
        public void SendMessage_ThrowsArgumentNullExceptionIfMessageIsEmpty()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => _notificationManager.SendMessage(string.Empty));
            Assert.That(ex.ParamName, Is.EqualTo("message"));
            Assert.That(ex.Message, Contains.Substring("Message is either null or empty."));
        }


        [Test]
        public void SendMessage_CallsSendMessageWithDifferentMessages()
        {
            // Arrange
            string message1 = "First message";
            string message2 = "Second message";

            // Act
            _notificationManager.SendMessage(message1);
            _notificationManager.SendMessage(message2);

            // Assert
            _mockNotification.Verify(n => n.SendMessage(message1), Times.Once);
            _mockNotification.Verify(n => n.SendMessage(message2), Times.Once);
        }

        [Test]
        public void SendMessage_ThrowsExceptionIfNotificationThrowsException()
        {
            // Arrange
            string message = "Test message";
            _mockNotification.Setup(n => n.SendMessage(It.IsAny<string>())).Throws(new InvalidOperationException());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _notificationManager.SendMessage(message));
        }

        [Test]
        public void SendMessage_HandlesDifferentNotificationImplementations()
        {
            // Arrange
            var emailNotification = new Mock<INotification>();
            var smsNotification = new Mock<INotification>();
            var emailManager = new NotificationManager(emailNotification.Object);
            var smsManager = new NotificationManager(smsNotification.Object);
            string message = "Test message";

            // Act
            emailManager.SendMessage(message);
            smsManager.SendMessage(message);

            // Assert
            emailNotification.Verify(n => n.SendMessage(message), Times.Once);
            smsNotification.Verify(n => n.SendMessage(message), Times.Once);
        }
    }
}
