using System.Net;
using System.Net.Http;
using System.Globalization;
using TempoAgora.Models;
using TempoAgora.Services;

namespace TempoAgora
{
    public partial class MainPage : ContentPage
    {

        private readonly HttpClient _httpClient;
        public MainPage()
        {
            InitializeComponent();

            _httpClient = new HttpClient();
        }

        //Verificando Conexão com a Internet
        public async Task<string> GetDataAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
               
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            
            }
            catch (HttpRequestException)
            {
                await App.Current.MainPage.DisplayAlert("Sem Conexão", "Verifique sua Conexão com a Internet", "OK");

            }
            return string.Empty;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisão(txt_cidade.Text);
                    if (t != null)
                    {
                        string dados_previsao = $"Latitude: {t.lat}\n" +
                            $"Longidude: {t.lon}\n" +
                            $"Descrição do Tempo: {t.descriptionTempo}\n" +
                            $"Temperatura Minima: {t.temp_min}ºC\n" +
                            $"Temperatura Maxima: {t.temp_max}ºC\n" +
                            $"Visibilidade: {t.visibility}m\n" +
                            $"Nascer do Sol: {t.sunrise}\n" +
                            $"Pôr do Sol: {t.sunset}\n" +
                            $"Velocidade do Vento: {t.speedVento}m/s\n";

                        txt_resp.Text = dados_previsao;
                    }
                    else //cidade não encontrada aviso
                    {

                        await DisplayAlert("Cidade não encontrada", "Tente novamente", "OK");

                    }
                }
                else
                {
                    txt_resp.Text = "Preencha a cidade";
                }
          


        }
    }
}