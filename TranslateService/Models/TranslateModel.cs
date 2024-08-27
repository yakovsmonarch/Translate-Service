namespace TranslateService.Models
{
    public class TranslateModel
    {
        public string Text { get; set; }

        public TranslateModel() { }

        public TranslateModel(string text)
        {
            Text = text;
        }
    }
}
