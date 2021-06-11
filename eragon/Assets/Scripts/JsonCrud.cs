using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonCrud
{
    // Start is called before the first frame update
    public static void CreateJSON(String path, String name)
    {
        using (StreamWriter file = File.CreateText(path + name))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, new Dictionary<String, String>());
        }
    }

    public static JObject ReadJson(String path)
    {
        using (StreamReader reader = File.OpenText(path))
        {
            JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            return o;

        }
    }

    public static void WriteJSON(String path, Dictionary<string, string> data)
    {
        JObject oldData = ReadJson(path);

        foreach (KeyValuePair<string, string> entry in data)
        {
            oldData[entry.Key] = entry.Value;
        }
        using (StreamWriter file = File.CreateText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, oldData);
        }
    }


    public static void DeleteJson(String path)
    {
        File.Delete(path);
    }
}
