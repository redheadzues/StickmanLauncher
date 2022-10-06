public static class PlayerSkills
{
    private static float _speed = SaveProgress.Speed;
    private static float _damage = SaveProgress.Damage;
    private static int _castleHp = SaveProgress.CastleHp;
    private static float _reload = SaveProgress.Reload;

    private static float _maxSpeed = 40;
    private static float _maxDamage = 10;
    private static float _maxCastleHp = 100;
    private static float _maxReload = 2f;

    private static float _realyMaxReload = 2.5f;

    private static float _speedImproveStep = 1;
    private static float _damageImproveStep = 0.1f;
    private static int _castleHpImproveStep = 1;
    private static float _reloadImproveStep = 0.1f;

    private static int _baseCastleHp = 5;
    private static float _baseSpeed = 20;
    private static float _baseDamage = 1;
    private static float _baseReload = 0;

    public static int BaseCastleHp => _baseCastleHp;
    public static float BaseSpeed => _baseSpeed;
    public static float BaseDamage => _baseDamage;
    public static float BaseReload => _baseReload;


    public static float MaxSpeed => _maxSpeed;
    public static float MaxDamage => _maxDamage;
    public static float MaxCastleHp => _maxCastleHp;
    public static float MaxReload => _maxReload;
    public static float RealyMaxReload => _realyMaxReload;


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
        if(_reload + _reloadImproveStep <= _maxReload)
        {
            _reload += _reloadImproveStep;
            SaveProgress.Reload = _reload;
        }
    }
}
