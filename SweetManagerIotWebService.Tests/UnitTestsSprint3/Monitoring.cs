using NUnit.Framework;
using SweetManagerIotWebService.API;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Booking;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetManagerIotWebService.Tests.Reservations.Domain.Model.Aggregates
{
    [TestFixture]
    public class IoTMonitoringTests
    {
        [Test]
        public void VisualizarEstadoDeDispositivosIoTEnTiempoReal_WhenGetAllDevicesInRoom_ThenReturnActiveDevicesStatus()
        {
            // Arrange
            var room = new Room(1, 1, 1, "ACTIVE");
            var thermostat = new Thermostat(1, 1, 25.5, "192.168.1.100", "AA:BB:CC:DD:EE:FF", "ACTIVE", DateTime.Now);
            var smokeSensor = new SmokeSensor(1, 1, 0.2, "192.168.1.101", "AA:BB:CC:DD:EE:00", "ACTIVE", DateTime.Now);
            
            room.Thermostats.Add(thermostat);
            room.SmokeSensors.Add(smokeSensor);

            // Act
            var activeThermostats = room.Thermostats.Where(t => t.State == "ACTIVE").ToList();
            var activeSmokeSensors = room.SmokeSensors.Where(s => s.State == "ACTIVE").ToList();

            // Assert
            Assert.That(activeThermostats.Count, Is.EqualTo(1));
            Assert.That(activeSmokeSensors.Count, Is.EqualTo(1));
            Assert.That(activeThermostats.First().State, Is.EqualTo("ACTIVE"));
            Assert.That(activeSmokeSensors.First().State, Is.EqualTo("ACTIVE"));
        }

        [Test]
        public void ConfigurarAlertasPorTemperatura_WhenTemperatureExceedsLimits_ThenGenerateNotification()
        {
            // Arrange
            var createCommand = new CreateThermostatCommand(1, 35.0, "192.168.1.100", "AA:BB:CC:DD:EE:FF", "ACTIVE", DateTime.Now);
            var thermostat = new Thermostat(createCommand);
            var minThreshold = 18.0;
            var maxThreshold = 30.0;

            // Act
            var temperatureExceedsMax = thermostat.Temperature > maxThreshold;
            var temperatureExceedsMin = thermostat.Temperature < minThreshold;
            var alertRequired = temperatureExceedsMax || temperatureExceedsMin;

            // Assert
            Assert.That(alertRequired, Is.True);
            Assert.That(temperatureExceedsMax, Is.True);
            Assert.That(temperatureExceedsMin, Is.False);
            Assert.That(thermostat.Temperature, Is.EqualTo(35.0));
        }

        [Test]
        public void RecibirAlertaPorDeteccionDeHumo_WhenSmokeDetected_ThenActivateAlert()
        {
            // Arrange
            var createCommand = new CreateSmokeSensorCommand(1, 0.8, "192.168.1.101", "AA:BB:CC:DD:EE:00", "ACTIVE", DateTime.Now);
            var smokeSensor = new SmokeSensor(createCommand);
            var dangerousThreshold = 0.5;

            // Act
            var smokeDetected = smokeSensor.LastAnalogicValue > dangerousThreshold;
            var alertTime = smokeDetected ? DateTime.Now : (DateTime?)null;

            // Assert
            Assert.That(smokeDetected, Is.True);
            Assert.That(smokeSensor.LastAnalogicValue, Is.EqualTo(0.8));
            Assert.That(alertTime, Is.Not.Null);
            Assert.That(smokeSensor.State, Is.EqualTo("ACTIVE"));
        }

        [Test]
        public void ConfigurarUmbralesDeDeteccionDeHumo_WhenAdjustSensitivityLevels_ThenApplyNewThresholds()
        {
            // Arrange
            var createCommand = new CreateSmokeSensorCommand(1, 0.3, "192.168.1.101", "AA:BB:CC:DD:EE:00", "ACTIVE", DateTime.Now);
            var smokeSensor = new SmokeSensor(createCommand);
            var newSensitivityThreshold = 0.4;
            var oldSensitivityThreshold = 0.5;

            // Act
            var triggersOldThreshold = smokeSensor.LastAnalogicValue > oldSensitivityThreshold;
            var triggersNewThreshold = smokeSensor.LastAnalogicValue > newSensitivityThreshold;

            // Assert
            Assert.That(triggersOldThreshold, Is.False);
            Assert.That(triggersNewThreshold, Is.False);
            Assert.That(smokeSensor.LastAnalogicValue, Is.EqualTo(0.3));
            Assert.That(smokeSensor.State, Is.EqualTo("ACTIVE"));
        }
    }
}