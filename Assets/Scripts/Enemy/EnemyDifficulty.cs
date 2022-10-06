using UnityEngine;
public static class EnemyDifficulty
{
    private static float _damage = SaveProgress.EnemyDamage;
    private static int _castleHp = SaveProgress.EnemyCastleHp;
    private static int _spawnCount = SaveProgress.EnemySpawnCount;
    private static float _spawnTime = SaveProgress.EnemySpawnTime;

    private static float _changeDamageStep = 0.1f;
    private static int _changeCastleHpStep = 1;
    private static int _changeSpawnCountStep = 1;
    private static float _changeSpawnTineStep = 0.1f;

    private static float _minDamage = 1;
    private static float _minCastleHp = 5;
    private static float _minSpawnCount = 1;
    private static float _maxSpawnTime = 4;

    public static float Damage => _damage;
    public static int CastleHp => _castleHp;
    public static int SpawnCount => _spawnCount;
    public static float SpawnTime => _spawnTime;

    public static void IncreaseDifficulty()
    {
        switch (GetRandomNumberOfDifficult())
        {
            case 1:
                IncreaseDamage(_changeDamageStep);
                break;

            case 2:
                IncreaseCastleHp(_changeCastleHpStep);
                break;

            case 3:
                IncreaseSpawnCount(_changeSpawnCountStep);
                break;

            case 4:
                DecreaseSpawnTime(_changeSpawnTineStep);
                break;
        }
    }

    public static void DecreaseDifficulty()
    {
        switch (GetRandomNumberOfDifficult())
        {
            case 1:
                DecreaseDamage(_changeDamageStep);
                break;

            case 2:
                DecreaseCastleHp(_changeCastleHpStep);
                break;

            case 3:
                DecreaseSpawnCount(_changeSpawnCountStep);
                break;

            case 4:
                IncreaseSpawnTime(_changeSpawnTineStep);
                break;
        }
    }

    private static void IncreaseDamage(float value)
    {
        if(value > 0)
        {
            _damage += value;
            SaveProgress.EnemyDamage = _damage;
        }        
    }

    private static void DecreaseDamage(float value)
    {
        if ((_damage - value > _minDamage) && (value > 0))
        {
            _damage -= value;
            SaveProgress.EnemyDamage = _damage;
        }
        else
            DecreaseDifficulty();
    }

    private static void IncreaseCastleHp(int value)
    {
        if (value > 0)
        {
            _castleHp += value;
            SaveProgress.EnemyCastleHp = _castleHp;
        }
    }

    private static void DecreaseCastleHp(int value)
    {
        if ((_castleHp - value > _minCastleHp) && (value > 0))
        {
            _castleHp -= value;
            SaveProgress.EnemyCastleHp = _castleHp;
        }
    }

    private static void IncreaseSpawnCount(int value)
    {
        if (value > 0)
        {
            _spawnCount += value;
            SaveProgress.EnemySpawnCount = _spawnCount;
        }
    }

    private static void DecreaseSpawnCount(int value)
    {
        if ((_spawnCount - value > _minSpawnCount) && (value > 0))
        {
            _spawnCount -= value;
            SaveProgress.EnemySpawnCount = _spawnCount;
        }
    }

    private static void IncreaseSpawnTime(float value)
    {
        if ((_spawnTime + value > _maxSpawnTime) && (value > 0))
        {
            _spawnTime += value;
            SaveProgress.EnemyDamage = _spawnTime;
        }
    }

    private static void DecreaseSpawnTime(float value)
    {
        if (value > 0 && _spawnTime - value > 0)
        {
            _spawnTime -= value;
            SaveProgress.EnemyDamage = _spawnTime;
        }
    }

    private static int GetRandomNumberOfDifficult()
    {
        return Random.Range(1, 5);
    }
}
