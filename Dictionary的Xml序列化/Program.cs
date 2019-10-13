using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Dictionary的Xml序列化
{
    [Serializable]
    public class SerialDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        private string name;
        public SerialDictionary()
        {
            this.name = "SerialDictionary";
        }
        public SerialDictionary(string name)
        {
            this.name = name;
        }
        public void WriteXml(XmlWriter write)       // Serializer
        {
            XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));

            write.WriteAttributeString("name", name);

            write.WriteStartElement(name);
            foreach (KeyValuePair<TKey, TValue> kv in this)
            {
                write.WriteStartElement("element");
                write.WriteStartElement("key");
                KeySerializer.Serialize(write, kv.Key);
                write.WriteEndElement();
                write.WriteStartElement("value");
                ValueSerializer.Serialize(write, kv.Value);
                write.WriteEndElement();
                write.WriteEndElement();
            }
            write.WriteEndElement();
        }
        public void ReadXml(XmlReader reader)       // Deserializer
        {
            reader.Read();
            XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));

            name = reader.Name;
            reader.ReadStartElement(name);
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("element");
                reader.ReadStartElement("key");
                TKey tk = (TKey)KeySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue vl = (TValue)ValueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadEndElement();

                this.Add(tk, vl);
                reader.MoveToContent();
            }
            reader.ReadEndElement();
            reader.ReadEndElement();

        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SerialDictionary<string, uint> sd = new SerialDictionary<string, uint>("modelNextIDs");
            sd.Add("xxxx", 10);
            sd.Add("xxxxx", 1);
            sd.Add("xxxxxx", 1);
            string fileName = "字典的序列化.xml";
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xmlFormatter = new XmlSerializer(sd.GetType());
                xmlFormatter.Serialize(fileStream, sd);
            }

            SerialDictionary<string, uint> sd2 = new SerialDictionary<string, uint>("modelNextIDs");
            using (FileStream fileStream2 = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmlFormatter = new XmlSerializer(sd2.GetType());
                sd2 = xmlFormatter.Deserialize(fileStream2) as SerialDictionary<string, uint>;
            }
        }
    }
}
