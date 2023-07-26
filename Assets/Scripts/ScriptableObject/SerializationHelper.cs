using System.IO;
using UnityEngine;

namespace ScriptableObject
{
    public static class SerializationHelper
    {
        private const string ScriptableObjectsDataDirectory = "ConfigSaves";
        private const string FileExtensionName = "json";

        public static void SaveObjectToJson(string name, object obj)
        {
            var filePath = GetFilePath(name);
            var json = JsonUtility.ToJson(obj);
            File.WriteAllText(filePath, json);
        }

        public static bool TryLoadJson(string name, out string data)
        {
            var filePath = Path.Combine(
                Application.persistentDataPath, 
                ScriptableObjectsDataDirectory,
                $"{name}.{FileExtensionName}");

            data = null;
            if (File.Exists(filePath) == false)
                return false;

            data = File.ReadAllText(filePath);
            return true;
        }

        private static string GetFilePath(string name)
        {
            var directoryPath = Path.Combine(Application.persistentDataPath, ScriptableObjectsDataDirectory);
            var filePath = Path.Combine(directoryPath, $"{name}.json");

            if (Directory.Exists(directoryPath) == false)
                Directory.CreateDirectory(directoryPath);

            if (File.Exists(filePath) == false)
                File.Create(filePath).Dispose();

            return filePath;
        }
    }
}