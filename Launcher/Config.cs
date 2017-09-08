using System;
using LitJson;
using System.IO;

public class Config
{
    private static Config _instance;
    [JsonPropertyName("JAVAPath")] public String _mJavaPath;
    [JsonPropertyName("LastVersion")] public String _mLastVersion;
    [JsonPropertyName("MaxMemory")] public int _mMaxMemory;
    [JsonPropertyName("Password")] public String _mPassword;
    [JsonPropertyName("Email")] public String _mEmail;

    static Config()
    {
        Load();
    }
    public static String JavPath
    {
        get { return _instance._mJavaPath; }
        set
        {
            _instance._mJavaPath = value;
            Save();
        }
    }

    public static String LastVersion
    {
        get { return _instance._mLastVersion; }
        set
        {
            _instance._mLastVersion = value;
            Save();
        }
    }

    public static String Password
    {
        get { return _instance._mPassword; }
        set
        {
            _instance._mPassword = value;
            Save();
        }
    }

    public static int MaxMemory
    {
        get { return _instance._mMaxMemory; }
        set
        {
            _instance._mMaxMemory = value;
            Save();
        }
    }

    public static void Save()
    {
        try
        {
            File.WriteAllText("hclconfig.cfg", JsonMapper.ToJson(_instance));
        }
        catch
        {
        }
    }

    public static void Load()
    {
        try
        {
            _instance = JsonMapper.ToObject<Config>(File.ReadAllText("hclconfig.cfg"));
        }
        catch
        {
            _instance = new Config();
        }
    }

}