namespace TranslateService.DI.CashServices
{
    public class VirtualCashService : ICashService
    {
        private readonly Dictionary<string, string> _cash;

        public VirtualCashService()
        {
            _cash = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            _cash.TryAdd(key, value);
        }

        public bool Get(string key, out string value)
        {
            if (_cash.ContainsKey(key))
            {
                value = _cash[key];
                return true;
            }

            value = string.Empty;
            return false;
        }

        public ulong GetSizeCash()
        {
            return (ulong)_cash.Count;
        }
    }
}
