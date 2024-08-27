namespace TranslateService.Models
{
    public class LanguangeModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public LanguangeModel() { }

        public LanguangeModel(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
