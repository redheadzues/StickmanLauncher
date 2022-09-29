using UnityEngine;

public static class SaveProgress
{
    private const string c_Money = "Money";
    private const string c_Stars = "Stars";
    private const string c_VolumeValue = "VolumeValue";
    private const string c_EquipedSkinId = "EquipedSkinId";
    private const string c_LastLoadScene = "LastLoadScene";

    public static int Money
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Money))
                return PlayerPrefs.GetInt(c_Money);
            else
                return 0;
        }
        set { PlayerPrefs.SetInt(c_Money, value); }
    }

    public static int Stars
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Stars))
                return PlayerPrefs.GetInt(c_Stars);
            else
                return 0;
        }
        set { PlayerPrefs.SetInt(c_Stars, value); }
    }

    public static float VolumeValue
    {
        get
        {
            if (PlayerPrefs.HasKey(c_VolumeValue))
                return PlayerPrefs.GetFloat(c_VolumeValue);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_VolumeValue, value); }
    }

    public static int LastLoadScene
    {
        get
        {
            if (PlayerPrefs.HasKey(c_LastLoadScene))
                return PlayerPrefs.GetInt(c_LastLoadScene);
            else
                return 1;
        }
        set { PlayerPrefs.SetInt(c_LastLoadScene, value); }
    }

    public static int EquipedSkinId
    {
        get
        {
            if (PlayerPrefs.HasKey(c_EquipedSkinId))
                return PlayerPrefs.GetInt(c_EquipedSkinId);
            else
                return 0;
        }
        set { PlayerPrefs.SetInt(c_EquipedSkinId, value); }
    }
}
