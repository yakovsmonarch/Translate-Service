using Microsoft.AspNetCore.Mvc;
using TranslateService.Models;

namespace TranslateService.DI
{
    public interface ITranslateService
    {
        /// <summary>
        /// Перевод по заданию.
        /// </summary>
        /// <param name="taskTranslationModel"></param>
        /// <returns></returns>
        WrapperResponse Translate(TaskTranslationModel taskTranslationModel);

        /// <summary>
        /// Получение информации о сервисе.
        /// </summary>
        /// <returns></returns>
        ServiceInfoModel GetServiceInfo();
    }
}
