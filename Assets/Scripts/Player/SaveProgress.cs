using UnityEngine;

public static class SaveProgress
{
    #region Constants

    private const string c_Money = "Money";
    private const string c_Stars = "Stars";
    private const string c_VolumeValue = "VolumeValue";
    private const string c_EquipedSkinId = "EquipedSkinId";
    private const string c_LastLoadScene = "LastLoadScene";
    private const string c_Speed = "Speed";
    private const string c_Damage = "Damage";
    private const string c_CastleHp = "CastleHp";
    private const string c_Reload = "Reload";
    private const string c_EnemyCastleHp = "EnemyCastleHp";
    private const string c_EnemyDamage = "EnemyDamage";
    private const string c_EnemySpawnCount = "EnemySpawnCoun";
    private const string c_EnemySpawnTime = "EnemySpawnTime";
    private const string c_LooseInRow = "LooseInRow";

    #endregion

    #region Achivments
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

    #endregion

    #region GameSettings
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

    #endregion

    #region PlayerSkills

    public static float Speed
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Speed))
                return PlayerPrefs.GetFloat(c_Speed);
            else
                return 20;
        }
        set { PlayerPrefs.SetFloat(c_Speed, value); }
    }

    public static float Damage
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Damage))
                return PlayerPrefs.GetFloat(c_Damage);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_Damage, value); }
    }

    public static int CastleHp
    {
        get
        {
            if (PlayerPrefs.HasKey(c_CastleHp))
                return PlayerPrefs.GetInt(c_CastleHp);
            else
                return 5;
        }
        set { PlayerPrefs.SetInt(c_CastleHp, value); }
    }

    public static float Reload
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Reload))
                return PlayerPrefs.GetFloat(c_Reload);
            else
                return 0;
        }
        set { PlayerPrefs.SetFloat(c_Reload, value); }
    }

    #endregion

    #region EnemyDifficulty

    public static int EnemyCastleHp
    {
        get
        {
            if (PlayerPrefs.HasKey(c_EnemyCastleHp))
                return PlayerPrefs.GetInt(c_EnemyCastleHp);
            else
                return 5;
        }
        set { PlayerPrefs.SetInt(c_EnemyCastleHp, value); }
    }

    public static float EnemyDamage
    {
        get
        {
            if (PlayerPrefs.HasKey(c_EnemyDamage))
                return PlayerPrefs.GetFloat(c_EnemyDamage);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_EnemyDamage, value); }
    }

    public static int EnemySpawnCount
    {
        get
        {
            if (PlayerPrefs.HasKey(c_EnemySpawnCount))
                return PlayerPrefs.GetInt(c_EnemySpawnCount);
            else
                return 1;
        }
        set { PlayerPrefs.SetInt(c_EnemySpawnCount, value); }
    }

    public static float EnemySpawnTime
    {
        get
        {
            if (PlayerPrefs.HasKey(c_EnemySpawnTime))
                return PlayerPrefs.GetFloat(c_EnemySpawnTime);
            else
                return 3;
        }
        set { PlayerPrefs.SetFloat(c_EnemySpawnTime, value); }
    }

    public static int LooseInRow
    {
        get
        {
            if (PlayerPrefs.HasKey(c_LooseInRow))
                return PlayerPrefs.GetInt(c_LooseInRow);
            else
                return 0;
        }
        set { PlayerPrefs.SetInt(c_LooseInRow, value); }
    }

    #endregion
}
