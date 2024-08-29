using Newtonsoft.Json;
using System.Text;
using TranslateService.Models;

namespace TranslateService.DI.TranslateServices
{
    public class YandexTranslateService : ITranslateService
    {
        private const string _info = "Yandex translate";
        private readonly ICashService _cashService;
        private const string _url = "https://translate.api.cloud.yandex.net/translate/v2/translate";

        public YandexTranslateService(ICashService cashService) 
        {
            _cashService = cashService;
        }

        public ServiceInfoModel GetServiceInfo(string serviceId)
        {
            var serviceInfo = new ServiceInfoModel(_cashService.GetSizeCash(), _info);
            return serviceInfo;
        }

        public IEnumerable<TranslateModel> Translate(TaskTranslationModel taskTranslationModel)
        {
            var translates = new List<TranslateModel>();
            translates.Add(new TranslateModel("Hello"));
            translates.Add(new TranslateModel("Hello"));
            translates.Add(new TranslateModel("Hello"));

            return translates.ToArray();
        }

        private string[] ReadCash(string[] texts)
        {
            var result = new List<string>();
            foreach(string text in texts)
            {
                if(_cashService.Get(text, out string value))
                {
                    result.Add(value);
                }
            }

            return result.ToArray();
        }

        private async Task<IEnumerable<TranslateModel>> Post(string url, string jsonData)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    IEnumerable<TranslateModel> result = JsonConvert.DeserializeObject<IEnumerable<TranslateModel>>(responseBody);
                    return result;
                }
                else
                {
                    string error = response.StatusCode.ToString();
                    return null;
                }
            }
        }
    }
}
