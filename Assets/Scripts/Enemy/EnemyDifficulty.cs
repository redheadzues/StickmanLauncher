public static class EnemyDifficulty
{
    private static float _damage = SaveProgress.EnemyDamage;
    private static int _castleHp = SaveProgress.EnemyCastleHp;
    private static int _spawnCount = SaveProgress.EnemySpawnCount;
    private static float _spawnTime = SaveProgress.EnemySpawnTime;

    public static float Damage => _damage;
    public static int CastleHp => _castleHp;
    public static int SpawnCount => _spawnCount;
    public static float SpawnTime => _spawnTime;

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

    public static void IncreaseSpawnTime(float value)
    {
        if (value > 0)
        {
            _spawnTime += value;
            SaveProgress.EnemyDamage = value;
        }
    }

    public static void DecreaseSpawnTime(float value)
    {
        if (value > 0)
        {
            _spawnTime -= value;
            SaveProgress.EnemyDamage = value;
        }
    }
}
