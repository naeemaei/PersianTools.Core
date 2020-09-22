using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PersianTools.Core
{
    public class CityUtil
    {
        public List<Province> Provinces { get; set; }
        private static CityUtil instance;
        private CityUtil()
        {
            string json;
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(this.GetType(), "IranCities.json");
            stream.Position = 0;

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }

            this.Provinces = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Province>>(json);
            FillCityCodes();
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
        private void FillCityCodes()
        {
            int i = 0;
            foreach (var item in this.Provinces)
            {
                item.ProvinceId = Provinces.IndexOf(item) + 1;
                item.Cities.ForEach(a => a.ProvinceId = item.ProvinceId);
                item.Cities.ForEach(a => a.CityId = ++i);
            }
        }
    }
    [DataContract]
    public class Province
    {
        public int ProvinceId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<City> Cities { get; set; }
    }
    [DataContract]
    public class City
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}

