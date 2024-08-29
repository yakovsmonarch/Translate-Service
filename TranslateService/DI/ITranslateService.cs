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
        Task<IEnumerable<TranslateModel>> Translate(TaskTranslationModel taskTranslationModel);

        /// <summary>
        /// Получение информации о сервисе.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        ServiceInfoModel GetServiceInfo(string serviceId);
    }
}
