using Domain;
using Domain.Entities;
using NotVisualBasic.FileIO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Infrastructure
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly string _path;
        public DeviceRepository(string path)
        {
            _path = path;
        }
        public List<CameraEntity> GetDevices()
        {
            List<CameraEntity> cameras = new List<CameraEntity>();
            bool headerLine = true;
            var regex = new Regex(@"\d+");

            using (var csvReader = new CsvTextFieldParser(_path))
            {
                while (!csvReader.EndOfData)
                {
                    var csvLine = csvReader.ReadFields();
                    if (headerLine)
                    {
                        headerLine = false;
                        continue;
                    }
                    var rowArray = csvLine[0].Split(';');
                    if (rowArray.Count() == 3)
                    {
                        var number = regex.Match(rowArray[0]).Value;
                        AddDataRow(cameras, number, rowArray[0], rowArray[1], rowArray[2]);
                    }
                }
            }
            return cameras;
        }

        public List<CameraEntity> GetDevicesByName(string name)
        {
            return GetDevices()
                .FindAll(c => c.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        private void AddDataRow(List<CameraEntity> cameras, string number, string name, string latitude, string longitude)
        {
            cameras.Add(new CameraEntity
            {
                Number = int.Parse(number),
                FullName = name,
                Latitude = double.Parse(latitude, CultureInfo.InvariantCulture),
                Longitude = double.Parse(longitude, CultureInfo.InvariantCulture)
            });
        }
    }
}
