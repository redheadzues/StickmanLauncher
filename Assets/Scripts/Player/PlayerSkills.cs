public static class PlayerSkills
{
    private static float _speed = SaveProgress.Speed;
    private static float _damage = SaveProgress.Damage;
    private static int _castleHp = SaveProgress.CastleHp;
    private static float _reload = SaveProgress.Reload;

    public static float Speed => _speed;
    public static float Damage => _damage;
    public static float CastleHp => _castleHp;
    public static float Reload => _reload;  

    public static void ImproveSpeed(float value)
    {
        if(value < 0)
            return;

        _speed += value;
        SaveProgress.Speed = _speed;
    }

    public static void ImproveDamage(float value)
    {
        if (value < 0)
            return;

        _damage += value;
        SaveProgress.Damage = _damage;
    }

    public static void ImproveCastleHp(int value)
    {
        if (value < 0)
            return;

        _castleHp += value;
        SaveProgress.CastleHp = _castleHp;
    }

    public static void ImproveReload(float value)
    {
        if (value < 0)
            return;

        _reload += value;
        SaveProgress.Reload = _reload;
    }
}
