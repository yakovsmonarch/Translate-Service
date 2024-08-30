using Newtonsoft.Json;

namespace TranslateService.Models
{
    public class TaskTranslationModel
    {
        [JsonProperty("folderId")]
        public string FolderId { get; set; }

        [JsonProperty("texts")]
        public string[] Texts { get; set; }

        [JsonProperty("targetLanguageCode")]
        public string TargetLanguageCode { get; set; }

        [JsonProperty("sourceLanguageCode")]
        public string SourceLanguageCode { get; set; }
    }
}
