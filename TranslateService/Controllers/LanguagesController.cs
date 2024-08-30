using Microsoft.AspNetCore.Mvc;
using TranslateService.DI;
using TranslateService.Models;

namespace TranslateService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ITranslateService _translateService;

        public LanguagesController(ITranslateService translateService)
        {
            _translateService = translateService;
        }

        [HttpGet]
        public ServiceInfoModel Get()
        {

            return _translateService.GetServiceInfo();
        }
    }
}
