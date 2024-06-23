using Domain.Entities;
using Infrastructure;

namespace Tests
{
    public class DeviceRepositoryTests
    {
        private const string TestCsvPath = "test_cameras.csv";

        private void CreateTestCsv(string content)
        {
            File.WriteAllText(TestCsvPath, content);
        }

        [Fact]
        public void GetDevices_ReturnsAllDevices()
        {
            // Arrange
            string csvContent = "Camera;Latitude;Longitude\n" +
                                "UTR-CM-504 Neude / Schoutenstraat;52.092995;5.119088\n" +
                                "UTR-CM-521 Mariaplaats / Zadelstraat / Springweg;52.090718;5.116421";
            CreateTestCsv(csvContent);

            var repository = new DeviceRepository(TestCsvPath);

            // Act
            List<CameraEntity> result = repository.GetDevices();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(504, result[0].Number);
            Assert.Equal("UTR-CM-504 Neude / Schoutenstraat", result[0].FullName);
        }

        [Fact]
        public void GetDevicesByName_ReturnsFilteredDevices()
        {
            // Arrange
            string csvContent = "Camera;Latitude;Longitude\n" +
                                "UTR-CM-504 Neude / Schoutenstraat;52.092995;5.119088\n" +
                                "UTR-CM-521 Mariaplaats / Zadelstraat / Springweg;52.090718;5.116421";
            CreateTestCsv(csvContent);

            var repository = new DeviceRepository(TestCsvPath);

            // Act
            List<CameraEntity> result = repository.GetDevicesByName("Neude");

            // Assert
            Assert.Single(result);
            Assert.Equal("UTR-CM-504 Neude / Schoutenstraat", result[0].FullName);
        }
    }
}
