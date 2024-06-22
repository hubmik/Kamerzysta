// See https://aka.ms/new-console-template for more information
using Infrastructure;
class Program
{
    static void Main(string[] args)
    {
        DeviceRepository cameraRepository = new DeviceRepository();
        cameraRepository.GetDevicesByName(args[0]).ForEach(i=> Console.WriteLine("{0} | {1} | {2} | {3}\t", i.Number, i.FullName, i.Latitude, i.Longitude));
    }
}