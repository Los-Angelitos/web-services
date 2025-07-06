using NUnit.Framework;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using System;

namespace SweetManagerIotWebService.Tests.OrganizationalManagement
{
    [TestFixture]
    public class OrganizationalManagementTests
    {
        [Test]
        public void CreateHotel_WhenValidInformationProvided_ShouldCreateHotelSuccessfully()
        {
            // Given - El administrador accede al módulo organizacional
            var command = new CreateHotelCommand(
                OwnerId: 1,
                Name: "Hotel Paradise",
                Description: "Luxury hotel with ocean view",
                Email: "info@hotelparadise.com",
                Address: "123 Beach Avenue",
                Phone: "+1234567890",
                Category: "FEATURED"
            );

            // When - Completa la información del nuevo hotel
            var hotel = new Hotel(command);

            // Then - El hotel debe crearse y aparecer en la estructura organizacional
            Assert.That(hotel.Name, Is.EqualTo("Hotel Paradise"));
            Assert.That(hotel.OwnerId, Is.EqualTo(1));
            Assert.That(hotel.Category, Is.EqualTo(ECategory.FEATURED));
            Assert.That(hotel.Email, Is.EqualTo("info@hotelparadise.com"));
        }

        [Test]
        public void CreateProvider_WhenAssigningProviderToHotel_ShouldAssignProviderWithActiveStatus()
        {
            // Given - Existe un hotel sin proveedor asignado
            var command = new CreateProviderCommand(
                Name: "ABC Supplies",
                Email: "contact@abcsupplies.com",
                Phone: "+1987654321",
                State: "Active",
                HotelId: 1
            );

            // When - El administrador selecciona un proveedor para el hotel
            var provider = new Provider(command);

            // Then - El proveedor debe obtener estado activo y asignarse al hotel
            Assert.That(provider.Name, Is.EqualTo("ABC Supplies"));
            Assert.That(provider.State, Is.EqualTo(State.Active));
            Assert.That(provider.HotelId, Is.EqualTo(1));
            Assert.That(provider.IsActive(), Is.True);
        }

        [Test]
        public void CreateFogServer_WhenDefiningNetworkConfiguration_ShouldCreateFogServerWithConfiguration()
        {
            // Given - El supervisor accede al módulo de configuración de red
            var command = new CreateFogServerCommand(
                IpAddress: "192.168.1.100",
                SubnetMask: "255.255.255.0",
                HotelId: 1
            );

            // When - Define configuración de red y asigna servidor al hotel
            var fogServer = new FogServer(command);

            // Then - La configuración debe guardarse y asociarse al hotel
            Assert.That(fogServer.IpAddress, Is.EqualTo("192.168.1.100"));
            Assert.That(fogServer.SubnetMask, Is.EqualTo("255.255.255.0"));
            Assert.That(fogServer.HotelId, Is.EqualTo(1));
        }

        [Test]
        public void UpdateProviderState_WhenProviderRequestsStateChange_ShouldUpdateProviderState()
        {
            // Given - Un proveedor necesita cambiar su estado
            var provider = new Provider(
                name: "XYZ Services",
                email: "info@xyzservices.com",
                phone: "+1122334455",
                state: "Active",
                hotelId: 1
            );

            // When - Solicita el cambio de estado a través del sistema
            provider.UpdateState("Inactive");

            // Then - La solicitud debe procesarse y el estado debe actualizarse
            Assert.That(provider.State, Is.EqualTo(State.Inactive));
            Assert.That(provider.IsActive(), Is.False);
        }
    }
}