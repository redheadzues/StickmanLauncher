using UnityEngine;

public static class SaveProgress
{
    private const string c_Money = "Money";
    private const string c_Stars = "Stars";

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


}
