using Domain.Entities;
using Domain;
using Moq;
using Application.Services;

namespace Tests
{
    public class DeviceServiceTests
    {
        [Fact]
        public void GetAllDevices_ReturnsMappedDevices()
        {
            // Arrange
            var mockRepository = new Mock<IDeviceRepository>();
            mockRepository.Setup(repo => repo.GetDevices()).Returns(new List<CameraEntity>
            {
                new CameraEntity { Number = 504, FullName = "UTR-CM-504 Neude / Schoutenstraat", Latitude = 52.092995, Longitude = 5.119088 },
                new CameraEntity { Number = 521, FullName = "UTR-CM-521 Mariaplaats / Zadelstraat / Springweg", Latitude = 52.090718, Longitude = 5.116421 }
            });

            var service = new DeviceService(mockRepository.Object);

            // Act
            var result = service.GetAllDevices().ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(504, result[0].Number);
            Assert.Equal("UTR-CM-504 Neude / Schoutenstraat", result[0].FullName);
        }
    }
}
