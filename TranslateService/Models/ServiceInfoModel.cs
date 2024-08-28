namespace TranslateService.Models
{
    public class ServiceInfoModel
    {
        public ServiceInfoModel(ulong sizeCash, string info)
        {
            SizeCash = sizeCash;
            Info = info;
        }

        /// <summary>
        /// Наименование сервиса.
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Размер кэша.
        /// </summary>
        public ulong SizeCash { get; set; }
    }
}
