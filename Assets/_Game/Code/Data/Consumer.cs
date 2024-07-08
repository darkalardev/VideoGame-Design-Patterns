using Darkalar.Patterns;
using UnityEngine;
using Darkalar.Adapter;

namespace Darkalar.Strategy
{
    public class Consumer
    {
        private IDataStore _dataStore;

        public Consumer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            Data data = new Data("Solaire", 294);
            _dataStore.SetData(data,"save2");
        }

        public void Load()
        {
            Data data = _dataStore.GetData<Data>("save2");
            Debug.Log("Name:" +data._name);
        }
    }
}