using System;
using System.Collections.Generic;
using System.IO;
using TradeMaster.Models;

namespace TradeMaster.IO.Tables {
    public static class XmlTablesNameList {

        public static void Write(List<TableDetails> tablesNameList) {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<TableDetails>));
            using (FileStream stream = new FileStream($"{Environment.CurrentDirectory}\\TableList.xml", FileMode.Create, FileAccess.Write)) {
                serializer.Serialize(stream, tablesNameList);
            }

        }

        public static List<TableDetails> Read() {
            List<TableDetails> list = new List<TableDetails>();
            System.Xml.Serialization.XmlSerializer xmlDeserializer = new System.Xml.Serialization.XmlSerializer(typeof(List<TableDetails>));
            using (FileStream fs = new FileStream($"{Environment.CurrentDirectory}\\TableList.xml", FileMode.Open, FileAccess.Read)) {
                list = xmlDeserializer.Deserialize(fs) as List<TableDetails>;
            }
            return list;
        }
    }

}

