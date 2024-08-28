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
    }
}
