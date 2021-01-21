using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class CoreExtensions
{
    public static int RandomIndex<T>(this IList<T> coll) => UnityEngine.Random.Range(0, coll.Count);
    public static T RandomElement<T>(this IList<T> coll) => coll[coll.RandomIndex()];
    public static T Last<T>(this IList<T> coll) => coll[coll.Count - 1];

    public static T FromEnd<T>(this IList<T> coll, int i) => coll[coll.Count - 1 - i];

    public static T DeepClone<T>(this T original) where T : class
    {
        if (!typeof(T).IsSerializable)
        {
            throw new ArgumentException("Object is not serializable!");
        }

        if (object.ReferenceEquals(original, null))
        {
            return default(T);
        }

        IFormatter formatter = new BinaryFormatter();

        using (Stream stream = new MemoryStream())
        {
            formatter.Serialize(stream, original);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as T;
        }
    }
}