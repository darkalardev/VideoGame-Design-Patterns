using Darkalar.Adapter;
using Darkalar.Patterns;

namespace Darkalar.Strategy
{
    public class ConsumerInstaller
    {
        private void Awake()
        {
            Consumer consumer = new Consumer(GetDataStore());
            consumer.Save();
            consumer.Load();
        }

        private IDataStore GetDataStore()
        {
            return new FileDataStoreAdapter();
        }
    }
}