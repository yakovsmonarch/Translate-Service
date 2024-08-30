namespace TranslateService.DI.CashServices
{
    public class VirtualCashService : ICashService
    {
        private readonly Dictionary<string, string> _cash;

        public VirtualCashService()
        {
            _cash = new Dictionary<string, string>();
        }

        public void Add(string[] source, string[] target)
        {
            if (source == null || target == null) return;
            if (source.Length != target.Length) return;

            for(int i = 0; i < source.Length; i++)
            {
                _cash.TryAdd(source[i], target[i]);
            }
        }

        public string[] Get(string[] words)
        {
            var result = new List<string>();

            foreach(string word in words)
            {
                if (_cash.ContainsKey(word)) continue;
                result.Add(word);
            }

            return result.ToArray();
        }

        public ulong GetSizeCash()
        {
            return (ulong)_cash.Count;
        }
    }
}
