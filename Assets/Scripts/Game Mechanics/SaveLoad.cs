using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public static class SaveLoad
{
    public static void Save(string name, int value)
    {
        if (string.IsNullOrEmpty(name))
            return;

        PlayerPrefs.SetInt(name, value);
        PlayerPrefs.Save();
    }
    public static void Save(string name, float value)
    {
        if (string.IsNullOrEmpty(name))
            return;

        PlayerPrefs.SetFloat(name, value);
        PlayerPrefs.Save();
    }
    public static void Save(string name, bool value)
    {
        if (string.IsNullOrEmpty(name))
            return;

        PlayerPrefs.SetInt(name, value? 1:0);
        PlayerPrefs.Save();
    }
    public static void Save(string name, string value)
    {
        if (string.IsNullOrEmpty(name))
            return;

        PlayerPrefs.SetString(name, value);
        PlayerPrefs.Save();
    }

    public static int LoadInt(string name)
    {
        return PlayerPrefs.GetInt(name, 0);
    }
    public static float LoadFloat(string name)
    {
        return PlayerPrefs.GetFloat(name, 0f);
    }
    public static bool LoadBool(string name)
    {
        return PlayerPrefs.GetInt(name, 0) == 1;
    }
    public static string LoadString(string name)
    {
        return PlayerPrefs.GetString(name, string.Empty);
    }
}
