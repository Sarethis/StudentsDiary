using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public class FileHelper <T> where T : new()
    {
        private string _filePath;
        private bool _xmlJsonStateB;

        public FileHelper(string filePath, bool xmlJsonStateB = false)
        {
            _filePath = filePath;
            _xmlJsonStateB = xmlJsonStateB;
        }

        public void SerializeToFile(T data)
        {
            if (!_xmlJsonStateB)
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var streamWriter = new StreamWriter($"{_filePath}.xml"))
                {
                    serializer.Serialize(streamWriter, data);
                    streamWriter.Close();
                }
            }
            else
            {
                var json = JsonConvert.SerializeObject(data);
                File.WriteAllText($"{_filePath}.txt", json);
            }
        }
        public T DeserializerFromFile()
        {
            if (!File.Exists($"{_filePath}.xml"))
                return new T();

            if (!_xmlJsonStateB)
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var streamReader = new StreamReader($"{_filePath}.xml"))
                {
                    var students = ((T)serializer.Deserialize(streamReader));
                    streamReader.Close();
                    return students;
                }
            }
            else
            {
                var dataReaded = File.ReadAllText($"{_filePath}.txt");
                return JsonConvert.DeserializeObject<T>(dataReaded);
            }
        }
        public void SerializeToSecondDataBase(T data)
        {
            if (_xmlJsonStateB)
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var streamWriter = new StreamWriter($"{_filePath}.xml"))
                {
                    serializer.Serialize(streamWriter, data);
                    streamWriter.Close();
                }
            }
            else
            {
                var json = JsonConvert.SerializeObject(data);
                File.WriteAllText($"{_filePath}.txt", json);
            }
        }
    }
}
