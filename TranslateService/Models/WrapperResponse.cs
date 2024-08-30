using Newtonsoft.Json;

namespace TranslateService.Models
{
    public class WrapperResponse
    {
        [JsonProperty("translations")]
        public TranslateModel[] Translations { get; set; }
    }
}
