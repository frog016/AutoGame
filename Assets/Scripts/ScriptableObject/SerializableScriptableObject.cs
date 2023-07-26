using UnityEngine;

namespace ScriptableObject
{
    public abstract class SerializableScriptableObject : UnityEngine.ScriptableObject
    {
        protected virtual void OnEnable()
        {
            LoadFromFile();
        }

        protected virtual void OnDisable()
        {
            SaveToFile();
        }

        private void LoadFromFile()
        {
            if (SerializationHelper.TryLoadJson(name, out var json))
                JsonUtility.FromJsonOverwrite(json, this);
        }

        private void SaveToFile()
        {
            SerializationHelper.SaveObjectToJson(name, this);
        }
    }
}