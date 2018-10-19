using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PersianTools.Core
{
    public class CityUtil
    {
        private static CityUtil instance;
        private CityUtil()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "PersianTools.Core.Properties.Resources.resources";
            var x1 = this.GetType().Assembly.GetManifestResourceNames();
            var m = Encoding.Unicode.GetString(PersianTools.Core.Properties.Resources.IranCities);
            var xx = JSONSerializer<List<CitiesModel>>.DeSerialize(m);
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
            }
        }
        public static CityUtil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CityUtil();
                }
                return instance;
            }
        }
    }
    public static class JSONSerializer<TType> where TType : class
    {
        /// <summary>
        /// Serializes an object to JSON
        /// </summary>
        public static string Serialize(TType instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(TType));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// DeSerializes an object from JSON
        /// </summary>
        public static TType DeSerialize(string json)
        {
            json = @"[{'name': 'آذربایجان شرقی','Cities': [{ 'name': 'سهند' }]}]";
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));

            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(TType));
            ms.Position = 0;
            var x = dcjs.ReadObject(ms);
            TType pd = (TType)dcjs.ReadObject(ms);
            return pd;
        }
    }
    internal class ProvinceFake
    {
        public string name { get; set; }
    }
    [DataContract]
    internal class CityFake
    {
        [DataMember(Name = "name")]
        public string name { get; set; }
    }
    [DataContract]
    internal class CitiesModel
    {
        [DataMember(Name = "name")]
        public string ProvinceName { get; set; }
        [DataMember(Name = "Cities")]
        public List<CityFake> Cities { get; set; }
    }
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
    public class City
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Province Province { get; set; }
    }
}
