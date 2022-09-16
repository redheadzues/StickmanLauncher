using UnityEngine;

public static class SaveProgress
{
    private const string c_Money = "Money";

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
}
