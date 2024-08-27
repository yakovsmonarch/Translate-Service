namespace TranslateService.Models
{
    public class TaskTranslationModel
    {
        public string[] Texts { get; set; }

        public string TargetLanguageCode { get; set; }

        public string SourceLanguageCode { get; set; }
    }
}
