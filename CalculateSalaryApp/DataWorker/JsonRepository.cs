using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CalculateSalaryApp.DataWorker
{
    public class JsonRepository : IRepository
    {
        public List<T> Load<T>(string fileName) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = File.OpenText(fileName))
            {

                if (serializer.Deserialize(sr, typeof(List<T>)) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return default(List<T>);
                }

            }
        }

        public void Save<T>(List<T> employees, string fileName) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate), Encoding.Default))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, employees);
            }
        }
    }
}
