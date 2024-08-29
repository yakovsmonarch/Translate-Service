namespace TranslateService.Models
{
    public class TaskTranslationModel
    {
        public string FolderId { get; set; }

        public string[] Texts { get; set; }

        public string TargetLanguageCode { get; set; }

        public string SourceLanguageCode { get; set; }
    }
}
