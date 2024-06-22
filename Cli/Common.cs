using Cli.Models;
using NotVisualBasic.FileIO;
using System.Globalization;

namespace Cli
{
    public class Common
    {
        public List<Camera> FetchData(string path)
        {
            List<Camera> cameras = new List<Camera>();
            bool headerLine = true;
            using(var csvReader = new CsvTextFieldParser(path))
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
                        AddDataRow(cameras, rowArray[0], rowArray[1], rowArray[2]);
                    }
                }
            }
            return cameras;
        }

        private void AddDataRow(List<Camera> cameras, string name, string latitude, string longitude)
        {
            cameras.Add(new Camera
            {
                Name = name,
                Latitude = double.Parse(latitude, CultureInfo.InvariantCulture),
                Longitude = double.Parse(longitude, CultureInfo.InvariantCulture)
            });
        }
    }
}
