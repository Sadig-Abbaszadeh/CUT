using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveObject(string fileName, object saveObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, fileName), FileMode.Create);

        formatter.Serialize(stream, saveObject);
        stream.Close();
    }

    public static object LoadObject(string fileName)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(fullPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fullPath, FileMode.Open);

            object obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
        else
        {
            return null;
        }
    }

    public static void DeleteFile(string fileName)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }
}