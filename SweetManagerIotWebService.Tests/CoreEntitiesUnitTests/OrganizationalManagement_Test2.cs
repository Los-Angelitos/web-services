using NUnit.Framework;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;
using System;

namespace SweetManagerIotWebService.Tests.OrganizationalManagementTests
{
    [TestFixture]
    public class OrganizationalManagementTests
    {
        #region Scenario: Registrar nueva organización

        [Test]
        public void RegisterNewOrganization_WhenOwnerCompletesRegistrationForm_ShouldCreateHotelCorrectly()
        {
            // Given - El propietario del hotel accede al formulario de registro
            var createHotelCommand = new CreateHotelCommand(
                OwnerId: 1,
                Name: "Hotel Paradise",
                Description: "Un lujoso hotel ubicado en el corazón de la ciudad con servicios de primera clase",
                Email: "info@hotelparadise.com",
                Address: "Av. Principal 123, Lima, Perú",
                Phone: "+51-1-234-5678",
                Category: "FEATURED"
            );

            // When - Completa los datos de la organización
            var hotel = new Hotel(createHotelCommand);

            // Then - La organización debe registrarse correctamente en el sistema
            Assert.That(hotel.OwnerId, Is.EqualTo(1));
            Assert.That(hotel.Name, Is.EqualTo("Hotel Paradise"));
            Assert.That(hotel.Description, Is.EqualTo("Un lujoso hotel ubicado en el corazón de la ciudad con servicios de primera clase"));
            Assert.That(hotel.Email, Is.EqualTo("info@hotelparadise.com"));
            Assert.That(hotel.Address, Is.EqualTo("Av. Principal 123, Lima, Perú"));
            Assert.That(hotel.Phone, Is.EqualTo("+51-1-234-5678"));
            Assert.That(hotel.Category, Is.EqualTo(ECategory.FEATURED));
        }

        [Test]
        public void RegisterNewOrganization_WithDirectConstructor_ShouldInitializeHotelData()
        {
            // Given - Se proporciona información básica del hotel
            var name = "Grand Hotel Lima";
            var description = "Hotel boutique con vista al océano";
            var email = "reservas@grandhotellima.com";
            var address = "Malecón de la Reserva 615, Miraflores";
            var phone = "+51-1-987-6543";
            var category = "WITH_A_POOL";

            // When - Se registra el hotel usando el constructor directo
            var hotel = new Hotel(name, description, email, address, phone, category);

            // Then - El hotel debe crearse con los datos correctos
            Assert.That(hotel.Name, Is.EqualTo(name));
            Assert.That(hotel.Description, Is.EqualTo(description));
            Assert.That(hotel.Email, Is.EqualTo(email));
            Assert.That(hotel.Address, Is.EqualTo(address));
            Assert.That(hotel.Phone, Is.EqualTo(phone));
            Assert.That(hotel.Category, Is.EqualTo(ECategory.WITH_A_POOL));
        }

        #endregion

        #region Scenario: Actualizar información de organización

        [Test]
        public void UpdateOrganizationData_WhenOwnerModifiesInformation_ShouldUpdateHotelCorrectly()
        {
            // Given - Existe un hotel registrado en el sistema
            var hotel = new Hotel("Hotel Original", "Descripción original", "original@hotel.com", "Dirección original", "123456789", "NEAR_THE_LAKE");
            
            var updateCommand = new UpdateHotelCommand(
                HotelId: 1,
                Description: "Nueva descripción actualizada con mejores servicios",
                Email: "nuevo@hotel.com", 
                Address: "Nueva dirección comercial 456",
                Phone: "+51-1-999-8888",
                OwnerId: 2,
                Category: "SUITE"
            );

            // When - El propietario actualiza la información del hotel
            hotel.UpdateData(updateCommand);

            // Then - Los datos del hotel deben actualizarse correctamente
            Assert.That(hotel.OwnerId, Is.EqualTo(2));
            Assert.That(hotel.Description, Is.EqualTo("Nueva descripción actualizada con mejores servicios"));
            Assert.That(hotel.Email, Is.EqualTo("nuevo@hotel.com"));
            Assert.That(hotel.Address, Is.EqualTo("Nueva dirección comercial 456"));
            Assert.That(hotel.Phone, Is.EqualTo("+51-1-999-8888"));
            // El nombre no debe cambiar ya que no está en el comando de actualización
            Assert.That(hotel.Name, Is.EqualTo("Hotel Original"));
        }

        #endregion

        #region Scenario: Gestión de proveedores

        [Test]
        public void RegisterProvider_WhenHotelNeedsNewSupplier_ShouldCreateProviderCorrectly()
        {
            // Given - El hotel necesita registrar un nuevo proveedor
            var createProviderCommand = new CreateProviderCommand(
                Name: "Distribuidora Lima SAC",
                Email: "ventas@distribuidoralima.com",
                Phone: "+51-1-555-1234",
                State: "Active",
                HotelId: 1
            );

            // When - Se registra el proveedor en el sistema
            var provider = new Provider(createProviderCommand);

            // Then - El proveedor debe crearse correctamente
            Assert.That(provider.Name, Is.EqualTo("Distribuidora Lima SAC"));
            Assert.That(provider.Email, Is.EqualTo("ventas@distribuidoralima.com"));
            Assert.That(provider.Phone, Is.EqualTo("+51-1-555-1234"));
            Assert.That(provider.State, Is.EqualTo(State.Active));
            Assert.That(provider.HotelId, Is.EqualTo(1));
            Assert.That(provider.IsActive(), Is.True);
        }

        [Test]
        public void UpdateProviderData_WhenProviderInformationChanges_ShouldUpdateCorrectly()
        {
            // Given - Existe un proveedor registrado
            var provider = new Provider("Proveedor Original", "original@proveedor.com", "111111111", "Active", 1);
            
            var updateCommand = new UpdateProviderCommand(
                Id: 1,
                Name: "Proveedor Actualizado SAC",
                Email: "nuevo@proveedor.com",
                Phone: "+51-1-777-9999"
            );

            // When - Se actualiza la información del proveedor
            provider.UpdateData(updateCommand);

            // Then - Los datos del proveedor deben actualizarse
            Assert.That(provider.Name, Is.EqualTo("Proveedor Actualizado SAC"));
            Assert.That(provider.Email, Is.EqualTo("nuevo@proveedor.com"));
            Assert.That(provider.Phone, Is.EqualTo("+51-1-777-9999"));
        }

        [Test]
        public void DisableProvider_WhenProviderNoLongerNeeded_ShouldSetStateToInactive()
        {
            // Given - Existe un proveedor activo
            var provider = new Provider("Proveedor Activo", "activo@proveedor.com", "123456789", "Active", 1);
            Assert.That(provider.IsActive(), Is.True);

            // When - Se desactiva el proveedor
            provider.DisableProvider();

            // Then - El proveedor debe estar inactivo
            Assert.That(provider.State, Is.EqualTo(State.Inactive));
            Assert.That(provider.IsActive(), Is.False);
        }

        [Test]
        public void UpdateProviderState_WhenStateChangesRequired_ShouldUpdateStateCorrectly()
        {
            // Given - Existe un proveedor con estado inicial
            var provider = new Provider("Test Provider", "test@provider.com", "123456789", "Active", 1);

            // When - Se cambia el estado del proveedor
            provider.UpdateState("Inactive");

            // Then - El estado debe actualizarse correctamente
            Assert.That(provider.State, Is.EqualTo(State.Inactive));
            Assert.That(provider.IsActive(), Is.False);

            // When - Se vuelve a activar
            provider.UpdateState("Active");

            // Then - El proveedor debe estar activo nuevamente
            Assert.That(provider.State, Is.EqualTo(State.Active));
            Assert.That(provider.IsActive(), Is.True);
        }

        #endregion

        #region Scenario: Validación de estados y categorías

        [Test]
        public void CreateProvider_WithInvalidState_ShouldThrowArgumentException()
        {
            // Given - Se intenta crear un proveedor con estado inválido
            // When & Then - Debe lanzar una excepción
            var ex = Assert.Throws<ArgumentException>(() => 
                new Provider("Test Provider", "test@provider.com", "123456789", "InvalidState", 1));
            
            Assert.That(ex.Message, Contains.Substring("Invalid state, use 'Active' or 'Inactive'"));
        }

        [Test]
        public void UpdateProviderState_WithInvalidState_ShouldThrowArgumentException()
        {
            // Given - Existe un proveedor válido
            var provider = new Provider("Test Provider", "test@provider.com", "123456789", "Active", 1);

            // When & Then - Intentar actualizar con estado inválido debe lanzar excepción
            var ex = Assert.Throws<ArgumentException>(() => provider.UpdateState("InvalidState"));
            Assert.That(ex.Message, Contains.Substring("Invalid state, use 'Active' or 'Inactive'"));
        }

        [Test]
        public void CreateHotel_WithValidCategory_ShouldParseCorrectly()
        {
            // Given - Se crean hoteles con diferentes categorías válidas
            var featuredHotel = new Hotel("Hotel 1", "Desc", "email@test.com", "Address", "123", "FEATURED");
            var lakeHotel = new Hotel("Hotel 2", "Desc", "email@test.com", "Address", "123", "NEAR_THE_LAKE");
            var poolHotel = new Hotel("Hotel 3", "Desc", "email@test.com", "Address", "123", "WITH_A_POOL");
            var beachHotel = new Hotel("Hotel 4", "Desc", "email@test.com", "Address", "123", "NEAR_THE_BEACH");
            var ruralHotel = new Hotel("Hotel 5", "Desc", "email@test.com", "Address", "123", "RURAL_HOTEL");
            var suiteHotel = new Hotel("Hotel 6", "Desc", "email@test.com", "Address", "123", "SUITE");

            // Then - Las categorías deben parsearse correctamente
            Assert.That(featuredHotel.Category, Is.EqualTo(ECategory.FEATURED));
            Assert.That(lakeHotel.Category, Is.EqualTo(ECategory.NEAR_THE_LAKE));
            Assert.That(poolHotel.Category, Is.EqualTo(ECategory.WITH_A_POOL));
            Assert.That(beachHotel.Category, Is.EqualTo(ECategory.NEAR_THE_BEACH));
            Assert.That(ruralHotel.Category, Is.EqualTo(ECategory.RURAL_HOTEL));
            Assert.That(suiteHotel.Category, Is.EqualTo(ECategory.SUITE));
        }

        #endregion

        #region Scenario: Inicialización de colecciones

        [Test]
        public void CreateHotel_ShouldInitializeEmptyCollections()
        {
            // Given & When - Se crea un nuevo hotel
            var hotel = new Hotel();

            // Then - Las colecciones deben estar inicializadas pero vacías
            Assert.That(hotel.Rooms, Is.Not.Null);
            Assert.That(hotel.Rooms, Is.Empty);
            Assert.That(hotel.Supplies, Is.Not.Null);
            Assert.That(hotel.Supplies, Is.Empty);
            Assert.That(hotel.Admins, Is.Not.Null);
            Assert.That(hotel.Admins, Is.Empty);
            Assert.That(hotel.Notifications, Is.Not.Null);
            Assert.That(hotel.Notifications, Is.Empty);
            Assert.That(hotel.Multimedias, Is.Not.Null);
            Assert.That(hotel.Multimedias, Is.Empty);
            Assert.That(hotel.Providers, Is.Not.Null);
            Assert.That(hotel.Providers, Is.Empty);
        }

        [Test]
        public void CreateProvider_ShouldInitializeEmptySuppliesCollection()
        {
            // Given & When - Se crea un nuevo proveedor
            var provider = new Provider();

            // Then - La colección de suministros debe estar inicializada pero vacía
            Assert.That(provider.Supplies, Is.Not.Null);
            Assert.That(provider.Supplies, Is.Empty);
        }

        #endregion
    }
}