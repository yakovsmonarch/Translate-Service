using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TranslateService.Models;

namespace TranslateService.DI.TranslateServices
{
    public class YandexTranslateService : ITranslateService
    {
        private const string _info = "Yandex translate";
        private readonly ICashService _cashService;
        private const string _url = "https://translate.api.cloud.yandex.net/translate/v2/translate";
        private const string _iamToken = "Bearer t1.9euelZrMjoqJj8aeyI-OlJuRl5HMk-3rnpWal5qclo6Pj5ecy4_Oz5qPmMjl8_cUZD1J-e82Tnku_t3z91QSO0n57zZOeS7-zef1656VmpOUj5yaxpzNyZaKjpGOzYrO7_zF656VmpOUj5yaxpzNyZaKjpGOzYrO.FglY9SrmuvdZKCe5ZQfgFZ9TyrlMz0cua4S43IRIjik1zcRX_IkT1GD2DwvaQTabK4d2YhqPpdLBhfnETA6TAw";
        private const string _folderId = "b1gbq7fg2cq65bvr6d3r";

        public YandexTranslateService(ICashService cashService) 
        {
            _cashService = cashService;
        }

        public ServiceInfoModel GetServiceInfo(string serviceId)
        {
            var serviceInfo = new ServiceInfoModel(_cashService.GetSizeCash(), _info);
            return serviceInfo;
        }

        public async Task<IEnumerable<TranslateModel>> Translate(TaskTranslationModel taskTranslationModel)
        {
            taskTranslationModel.FolderId = _folderId;
            var result = await Post(_url, taskTranslationModel);
            return result;

            //var translates = new List<TranslateModel>();
            //translates.Add(new TranslateModel("Hello"));
            //translates.Add(new TranslateModel("Hello"));
            //translates.Add(new TranslateModel("Hello"));

            //return translates.ToArray();
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

        private async Task<IEnumerable<TranslateModel>> Post(string url, TaskTranslationModel taskTranslationModel)
        {
            /*
                var folderId = "b1gbq7fg2cq65bvr6d3r";
                var texts = new[] { "привет", "мир" };
                var targetLanguageCode = "de";
                var sourceLanguageCode = "ru";

                // Создание JSON-объекта
                var jsonData = new
                {
                    folderId = folderId,
                    texts = texts,
                    targetLanguageCode = targetLanguageCode,
                    sourceLanguageCode = sourceLanguageCode
                };

                // Преобразование JSON-объекта в строку
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);

                // Создание HTTP-клиента
                using (var client = new HttpClient())
                {
                    // Установка заголовков
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer t1.9euelZrMjoqJj8aeyI-OlJuRl5HMk-3rnpWal5qclo6Pj5ecy4_Oz5qPmMjl8_cUZD1J-e82Tnku_t3z91QSO0n57zZOeS7-zef1656VmpOUj5yaxpzNyZaKjpGOzYrO7_zF656VmpOUj5yaxpzNyZaKjpGOzYrO.FglY9SrmuvdZKCe5ZQfgFZ9TyrlMz0cua4S43IRIjik1zcRX_IkT1GD2DwvaQTabK4d2YhqPpdLBhfnETA6TAw");
                    
                    // Создание контента запроса
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // Отправка POST-запроса
                    var response = await client.PostAsync(url, content);

                    // Получение и вывод результата
                    var responseBody = await response.Content.ReadAsStringAsync();
                    IEnumerable<TranslateModel> result = JsonConvert.DeserializeObject<IEnumerable<TranslateModel>>(responseBody);
                    return result;
                }
                */

            //string jsonData = JsonConvert.SerializeObject(taskTranslationModel);
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", _iamToken);


            //HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await client.PostAsync(url, content);

            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    IEnumerable<TranslateModel> result = JsonConvert.DeserializeObject<IEnumerable<TranslateModel>>(responseBody);
            //    return result;
            //}
            //else
            //{
            //    string error = response.StatusCode.ToString();
            //    return null;
            //}


            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://translate.api.cloud.yandex.net/translate/v2/translate");
            request.Headers.Add("Authorization", _iamToken);
            var content = new StringContent("{\n    \"folderId\": \"b1gbq7fg2cq65bvr6d3r\",\n    \"texts\": [\"привет\", \"мир\"],\n    \"targetLanguageCode\": \"de\",\n    \"sourceLanguageCode\": \"ru\"\n}", Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            IEnumerable<TranslateModel> result1 = JsonConvert.DeserializeObject<IEnumerable<TranslateModel>>(result);
            return result1;
        }
    }
}
