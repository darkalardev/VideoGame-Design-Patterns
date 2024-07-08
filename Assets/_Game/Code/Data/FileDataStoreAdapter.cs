using System.Collections;
using System.Collections.Generic;
using System.IO;
using Darkalar.Patterns;
using UnityEngine;

namespace Darkalar.Adapter
{
    public class FileDataStoreAdapter : IDataStore
    {
        public void SetData<T>(T data, string name)
        {
            string _json = JsonUtility.ToJson(data);
            string _path = Path.Combine(Application.dataPath, name);
            File.WriteAllText(_path,_json);
        }

        public T GetData<T>(string name)
        {
            string _path = Path.Combine(Application.dataPath, name);
            string _json = File.ReadAllText(_path);
            return JsonUtility.FromJson<T>(_json);
        }
    }
}