namespace TranslateService.DI
{
    public interface ICashService
    {
        /// <summary>
        /// Добавляет в кэш резуьтат перевода.
        /// </summary>
        /// <param name="source">Переводимые слова</param>
        /// <param name="target">Переведенные слова</param>
        void Add(string[] source, string[] target);

        /// <summary>
        /// Возвращает не переведенные слова.
        /// </summary>
        /// <param name="words">Слова для перевода от пользователя</param>
        /// <returns></returns>
        string[] Get(string[] words);

        /// <summary>
        /// Число переводов в кэше.
        /// </summary>
        /// <returns></returns>
        ulong GetSizeCash();
    }
}
