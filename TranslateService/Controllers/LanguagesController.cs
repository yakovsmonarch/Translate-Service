using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranslateService.Models;

namespace TranslateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LanguangeModel> Get()
        {
            var languages = new List<LanguangeModel>();
            languages.Add(new LanguangeModel("ru", "rusian"));
            languages.Add(new LanguangeModel("en", "english"));

            return languages.ToArray();
        }
    }
}
