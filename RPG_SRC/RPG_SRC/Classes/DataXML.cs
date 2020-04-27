using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace RPG_SRC.Classes
{
    public static class DataXML
    {
        public static string path = @"..\..\Data\";

        public static void Save(string file, List<Player> list)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(path + file, settings))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));
                xmlSerializer.Serialize(writer, list);
            }
        }

        public static List<Player> Load(string file)
        {
            List<Player> data = null;
            using (StreamReader reader = new StreamReader(path + file))
            {
                XmlSerializer xmlSerialer = new XmlSerializer(typeof(List<Player>));
                data = xmlSerialer.Deserialize(reader) as List<Player>;
            }
            return data;
        }
    }
}
