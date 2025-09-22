using Newtonsoft.Json.Linq;
using TempoAgora.Models;

namespace TempoAgora.Services
{
    public class DataService
    {
        public static async Task<Tempo?> GetPrevisão(string cidade)
        {
           
                Tempo? t = null;

                string chave = "d961c3db5d4749a09ef894476d0889d8";
                string url = $"https://api.openweathermap.org/data/2.5/weather?" +
                    $"q={cidade}&units=metric&appid={chave}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage resp = await client.GetAsync(url);

                    if (resp.IsSuccessStatusCode)
                    {
                        string json = await resp.Content.ReadAsStringAsync();
                        var rascunho = JObject.Parse(json);

                        DateTime time = new();
                        DateTime sunrise = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                        DateTime sunset = time.AddSeconds((double)rascunho["sys"]["sunset"]).ToLocalTime();

                        t = new()
                        {
                            lat = (double)rascunho["coord"]["lat"],
                            lon = (double)rascunho["coord"]["lon"],
                            descriptionTempo = (string)rascunho["weather"][0]["description"],
                            main = (string)rascunho["weather"][0]["main"],
                            temp_min = (double)rascunho["main"]["temp_min"],
                            temp_max = (double)rascunho["main"]["temp_max"],
                            visibility = (int)rascunho["visibility"],
                            sunrise = sunrise.ToString(),
                            sunset = sunset.ToString(),
                            speedVento = (double)rascunho["wind"]["speed"]
                        };
                    }
                }

                return t;


           
        }
    }
}