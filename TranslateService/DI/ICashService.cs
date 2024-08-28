namespace TranslateService.DI
{
    public interface ICashService
    {
        /// <summary>
        /// Добавить перевод в кэш.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(string key, string value);

        /// <summary>
        /// Получить перевод из кэша.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Get(string key, out string value);

        /// <summary>
        /// Число переводов в кэше.
        /// </summary>
        /// <returns></returns>
        ulong GetSizeCash();
    }
}
