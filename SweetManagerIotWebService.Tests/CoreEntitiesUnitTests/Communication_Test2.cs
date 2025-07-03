using NUnit.Framework;
using SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Communication.Domain.Model.Commands;
using System;

namespace SweetManagerIotWebService.Tests.CommunicationManagementTests
{
    [TestFixture]
    public class NotificationAlertManagementTests
    {
        private const int BROADCAST_RECEIVER_ID = -1; // Special value for broadcast

        #region Scenario: Recibir notificación por sensor de humo

        [Test]
        public void ReceiveSmokeDetectorNotification_WhenAbnormalActivityDetected_ShouldCreateNotificationForOwner()
        {
            // Given - Un sensor de humo detecta actividad anormal
            var createNotificationCommand = new CreateNotificationCommand(
                Title: "🚨 ALERTA DE HUMO DETECTADO",
                Content: "El sensor de humo en la habitación 205 ha detectado actividad anormal. Se requiere atención inmediata.",
                SenderType: "SENSOR",
                SenderId: 1001, // ID del sensor de humo
                ReceiverId: 1, // ID del propietario
                HotelId: 1
            );

            // When - Se activa la alerta en el sistema
            var notification = new Notification(createNotificationCommand);

            // Then - El propietario del hotel debe recibir una notificación inmediata
            Assert.That(notification.Title, Is.EqualTo("🚨 ALERTA DE HUMO DETECTADO"));
            Assert.That(notification.Content, Contains.Substring("sensor de humo"));
            Assert.That(notification.Content, Contains.Substring("habitación 205"));
            Assert.That(notification.SenderType, Is.EqualTo("SENSOR"));
            Assert.That(notification.SenderId, Is.EqualTo(1001));
            Assert.That(notification.ReceiverId, Is.EqualTo(1));
            Assert.That(notification.HotelId, Is.EqualTo(1));
        }

        #endregion

        #region Scenario: Alerta sonora por detección de humo

        [Test]
        public void SoundAlert_WhenSmokeDetected_ShouldCreateAudioAlertNotification()
        {
            // Given - El sensor de humo detecta presencia de humo
            var emergencyProtocolCommand = new CreateNotificationCommand(
                Title: "🔊 PROTOCOLO DE EMERGENCIA ACTIVADO",
                Content: "Alerta sonora activada en la habitación 205. Evacuación inmediata requerida. Personal de emergencia notificado.",
                SenderType: "EMERGENCY_SYSTEM",
                SenderId: 2001, // ID del sistema de emergencia
                ReceiverId: BROADCAST_RECEIVER_ID, // Broadcast a todos los usuarios del hotel
                HotelId: 1
            );

            // When - Se activa el protocolo de emergencia
            var audioAlert = new Notification(emergencyProtocolCommand);

            // Then - Debe sonar una alerta audible en la habitación afectada
            Assert.That(audioAlert.Title, Is.EqualTo("🔊 PROTOCOLO DE EMERGENCIA ACTIVADO"));
            Assert.That(audioAlert.Content, Contains.Substring("Alerta sonora activada"));
            Assert.That(audioAlert.Content, Contains.Substring("habitación 205"));
            Assert.That(audioAlert.Content, Contains.Substring("Evacuación inmediata"));
            Assert.That(audioAlert.SenderType, Is.EqualTo("EMERGENCY_SYSTEM"));
            Assert.That(audioAlert.SenderId, Is.EqualTo(2001));
            Assert.That(audioAlert.ReceiverId, Is.EqualTo(BROADCAST_RECEIVER_ID)); // Check for broadcast value
            Assert.That(audioAlert.HotelId, Is.EqualTo(1));
        }

        #endregion

        #region Scenarios adicionales para completar la funcionalidad

        [Test]
        public void CreateNotification_WithConstructorParameters_ShouldInitializeCorrectly()
        {
            // Given - Se necesita crear una notificación directamente
            var title = "Mantenimiento Programado";
            var content = "Se realizará mantenimiento en el sistema de climatización mañana de 8:00 AM a 12:00 PM";
            var senderType = "ADMIN";
            var senderId = 5;
            var receiverId = 10;
            var hotelId = 1;

            // When - Se crea la notificación usando el constructor con parámetros
            var notification = new Notification(title, content, senderType, senderId, receiverId, hotelId);

            // Then - La notificación debe inicializarse correctamente
            Assert.That(notification.Title, Is.EqualTo(title));
            Assert.That(notification.Content, Is.EqualTo(content));
            Assert.That(notification.SenderType, Is.EqualTo(senderType));
            Assert.That(notification.SenderId, Is.EqualTo(senderId));
            Assert.That(notification.ReceiverId, Is.EqualTo(receiverId));
            Assert.That(notification.HotelId, Is.EqualTo(hotelId));
        }

        [Test]
        public void CreateBroadcastNotification_ForHotelGuests_ShouldCreateNotificationWithoutSpecificReceiver()
        {
            // Given - Se necesita enviar una notificación a todos los huéspedes
            var broadcastCommand = new CreateNotificationCommand(
                Title: "📢 AVISO IMPORTANTE",
                Content: "El servicio de Wi-Fi será interrumpido temporalmente entre las 2:00 AM y 4:00 AM para mantenimiento.",
                SenderType: "HOTEL_MANAGEMENT",
                SenderId: 1,
                ReceiverId: BROADCAST_RECEIVER_ID, // Broadcast usando valor especial
                HotelId: 1
            );

            // When - Se crea la notificación broadcast
            var broadcastNotification = new Notification(broadcastCommand);

            // Then - La notificación debe configurarse para broadcast
            Assert.That(broadcastNotification.Title, Is.EqualTo("📢 AVISO IMPORTANTE"));
            Assert.That(broadcastNotification.Content, Contains.Substring("Wi-Fi"));
            Assert.That(broadcastNotification.SenderType, Is.EqualTo("HOTEL_MANAGEMENT"));
            Assert.That(broadcastNotification.SenderId, Is.EqualTo(1));
            Assert.That(broadcastNotification.ReceiverId, Is.EqualTo(BROADCAST_RECEIVER_ID));
            Assert.That(broadcastNotification.HotelId, Is.EqualTo(1));
        }

        #endregion
    }
}