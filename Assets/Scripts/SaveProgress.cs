using UnityEngine;

public static class SaveProgress
{
    private const string c_Money = "Money";
    private const string c_SkinID = "SkinId";

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

    public static int SkinId
    {
        get
        {
            if (PlayerPrefs.HasKey(c_SkinID))
                return PlayerPrefs.GetInt(c_SkinID);
            else
                return 0;
        }
        set { PlayerPrefs.SetInt(c_SkinID, value); }
    }
}
