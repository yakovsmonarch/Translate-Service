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
        private const string _iamToken = "Bearer t1.9euelZqXlI_JzY2cio-TmsyUiZ6RlO3rnpWal5qclo6Pj5ecy4_Oz5qPmMjl9PdVejhJ-e9VDz7J3fT3FSk2SfnvVQ8-yc3n9euelZqOlciby4nHkJyPj82NzMbOzO_8xeuelZqOlciby4nHkJyPj82NzMbOzA.lPiwQi1fsMTHgXjwcLIeZ-aXXAGBAd8iV0WudpkPNkFyInjSWp5Q7TcTxhOlgNy3PD0ynA1ItWAs00srDng1CA";
        private const string _folderId = "b1gbq7fg2cq65bvr6d3r";

        public YandexTranslateService(ICashService cashService) 
        {
            _cashService = cashService;
        }

        public ServiceInfoModel GetServiceInfo()
        {
            var serviceInfo = new ServiceInfoModel(_cashService.GetSizeCash(), _info);
            return serviceInfo;
        }

        public WrapperResponse Translate(TaskTranslationModel taskTranslationModel)
        {
            taskTranslationModel.FolderId = _folderId;
            string json = Post(_url, taskTranslationModel);
            var result = JsonConvert.DeserializeObject<WrapperResponse>(json);
            return result;
        }

        private string Post(string url, TaskTranslationModel taskTranslationModel)
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", _iamToken);

            string jsonData = JsonConvert.SerializeObject(taskTranslationModel);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            request.Content = content;

            using var response = client.Send(request);
            response.EnsureSuccessStatusCode();
            string resultJson = response.Content.ReadAsStringAsync().Result;
            return resultJson;
        }


    }
}
