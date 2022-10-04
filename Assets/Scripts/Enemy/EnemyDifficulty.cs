using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyDifficulty
{
    private static float _damage = SaveProgress.EnemyDamage;
    private static int _castleHp = SaveProgress.EnemyCastleHp;
    private static int _spawnCount = SaveProgress.EnemySpawnCount;

    public static void IncreaseDamage(float value)
    {
        if(value > 0)
        {
            _damage += value;
            SaveProgress.EnemyDamage = value;
        }        
    }

    public static void DecreaseDamage(float value)
    {
        if (value > 0)
        {
            _damage -= value;
            SaveProgress.EnemyDamage = value;
        }
    }

    public static void IncreaseCastleHp(int value)
    {
        if (value > 0)
        {
            _castleHp += value;
            SaveProgress.EnemyCastleHp = value;
        }
    }

    public static void DecreaseCastleHp(int value)
    {
        if (value > 0)
        {
            _castleHp -= value;
            SaveProgress.EnemyCastleHp = value;
        }
    }

    public static void IncreaseSpawnCount(int value)
    {
        if (value > 0)
        {
            _spawnCount += value;
            SaveProgress.EnemySpawnCount = value;
        }
    }

    public static void DecreaseSpawnCount(int value)
    {
        if (value > 0)
        {
            _spawnCount -= value;
            SaveProgress.EnemySpawnCount = value;
        }
    }
}
