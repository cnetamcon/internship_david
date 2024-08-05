using Core.Interfaces.Converters;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core.Converters
{
    public class XmlConvertManager : IXmlConvertManager
    {
        public T Deserialize<T>(string xml)
        {
            var st = typeof(T);

            T result;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }

        public string Serialize<T>(T model)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            var xml = "";
            using (var sww = new StringUtf8Writer())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, model, xmlSerializerNamespaces);
                    xml = sww.ToString();
                }
            }
            return xml;
        }

        public class StringUtf8Writer : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}