using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LabWork5
{
    static class SerializationList
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Flat>));
        static List<Flat> newFlat;


        /// <summary>
        /// Сериализация List
        /// </summary>
        /// <returns></returns>
        public static string SerializeList(List<Flat> flats)
        {
            try
            {
                using (FileStream fs = new FileStream("Flat.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    serializer.Serialize(fs, flats);
                }
                return ("Объект сереализован");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Десериализация List
        /// </summary>
        /// <returns></returns>
        public static string DeserializeList()
        {
            try
            {
                using (FileStream fs = new FileStream("Flat.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    newFlat = (List<Flat>)serializer.Deserialize(fs);
                }
                return ("Объект десереализован");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static List<Flat> GetDeserializeFlats()
        {
            if (newFlat is null)
                return null;
            else
                return newFlat;
        }
    }
}
