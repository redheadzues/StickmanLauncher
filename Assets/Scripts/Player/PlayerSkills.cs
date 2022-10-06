public static class PlayerSkills
{
    private static float _speed = SaveProgress.Speed;
    private static float _damage = SaveProgress.Damage;
    private static int _castleHp = SaveProgress.CastleHp;
    private static float _reload = SaveProgress.Reload;

    private static float _maxSpeed = 40;
    private static float _maxDamage = 10;
    private static float _maxCastleHp = 100;
    private static float _minReload = 0.5f;

    private static float _speedImproveStep = 1;
    private static float _damageImproveStep = 0.1f;
    private static int _castleHpImproveStep = 1;
    private static float _reloadImproveStep = 0.1f;


    public static float MaxSpeed => _maxSpeed;
    public static float MaxDamage => _maxDamage;
    public static float MaxCastleHp => _maxCastleHp;
    public static float MinReload => _minReload;

    public static float Speed => _speed;
    public static float Damage => _damage;
    public static float CastleHp => _castleHp;
    public static float Reload => _reload;  

    public static void ImproveSpeed()
    {
        if(_speed + _speedImproveStep <= _maxSpeed)
        {
            _speed += _speedImproveStep;
            SaveProgress.Speed = _speed;
        }
    }

    public static void ImproveDamage()
    {
        if(_damage + _damageImproveStep <= _maxDamage)
        {
            _damage += _damageImproveStep;
            SaveProgress.Damage = _damage;
        }
    }

    public static void ImproveCastleHp()
    {
        if(_castleHp + _castleHpImproveStep  <= _maxCastleHp)
        {
            _castleHp += _castleHpImproveStep;
            SaveProgress.CastleHp = _castleHp;
        }
    }

    public static void ImproveReload()
    {
        if(_reload - _reloadImproveStep >= _minReload)
        {
            _reload += _reloadImproveStep;
            SaveProgress.Reload = _reload;
        }
    }
}
