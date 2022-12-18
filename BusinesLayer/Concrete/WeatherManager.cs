using BusinesLayer.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinesLayer.Concrete
{
    public class WeatherManager : IWeatherService
    {
        public IDataResult<List<Results>> GetList(string city)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("authorization", "apikey 6AfjbfXO5QdZXqAn0lPCey:19lS467XeytcGf7usv4Spt");
                var endpoit = new Uri($"https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city={city}");

                var result = client.GetAsync(endpoit).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                WeatherModel weatherModel = JsonConvert.DeserializeObject<WeatherModel>(json);

                List<Results> listProductData = weatherModel.Results;

                return new SuccessDataResult<List<Results>>(listProductData);



            }
        }
    }
}
