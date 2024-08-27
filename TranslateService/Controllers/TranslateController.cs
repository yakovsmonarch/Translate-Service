using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranslateService.Models;

namespace TranslateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<TranslateModel> Post([FromBody] TaskTranslationModel taskTranslationModel)
        {
            var translates = new List<TranslateModel>();
            translates.Add(new TranslateModel("Hello"));
            translates.Add(new TranslateModel("Hello"));
            translates.Add(new TranslateModel("Hello"));

            return translates.ToArray();
        }
    }
}
