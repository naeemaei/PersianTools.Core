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
        public List<CityModel> Cities;
        private static CityUtil instance;
        private CityUtil()
        {
            var m = Encoding.UTF8.GetString(PersianTools.Core.Properties.Resources.IranCities);
            this.Cities = JSONSerializer<List<CityModel>>.DeSerialize(m);
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
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(TType));
            ms.Position = 0;
            var x = dcjs.ReadObject(ms) as TType;
            ms.Close();
            return x;
        }
    }
    [DataContract]
    public class JsonCity
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class CityModel
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "Cities")]
        public IList<JsonCity> Cities { get; set; }
    }
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public IList<City> Cities { get; set; }
    }

    public class City
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Province Province { get; set; }
    }
}
