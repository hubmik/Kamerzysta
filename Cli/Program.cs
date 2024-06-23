// See https://aka.ms/new-console-template for more information
using Infrastructure;
using Microsoft.Extensions.Configuration;
class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();
        string csvFilePath = config["CsvFilePath"];

        DeviceRepository cameraRepository = new DeviceRepository(csvFilePath);
        cameraRepository.GetDevicesByName(args[0]).ForEach(i=> Console.WriteLine("{0} | {1} | {2} | {3}\t", i.Number, i.FullName, i.Latitude, i.Longitude));
    }
}