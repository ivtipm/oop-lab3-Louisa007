using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ChatBot_test1
{
    public class WeatherInfo
    {
        public TemperatureInfo Main { get; set; }

        public string Name { get; set; }

        public WindInfo Wind { get; set; }


        public static String[] FindOutWeather()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Chita&units=metric&appid=2856fc0f74411cd143093c7ac9b9a7a0";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string responce;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                responce = streamReader.ReadToEnd();
            }

            WeatherInfo weather = JsonConvert.DeserializeObject<WeatherInfo>(responce);

            String[] infoWeather = { weather.Name, weather.Main.Temp.ToString(), weather.Wind.Speed.ToString() };
            return infoWeather;
        }

    }

    public class TemperatureInfo
    {
        public float Temp { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}