using Microsoft.AspNetCore.Mvc;
using TranslateService.DI;
using TranslateService.Models;

namespace TranslateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private readonly ITranslateService _translateService;

        public TranslateController(ITranslateService translateService) 
        {
            _translateService = translateService;
        }

        [HttpPost]
        public IEnumerable<TranslateModel> Post([FromBody]TaskTranslationModel taskTranslationModel)
        {

            return _translateService.Translate(taskTranslationModel);
        }
    }
}
