using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSkills
{
    private static float _speed = SaveProgress.Speed;
    private static float _damage = SaveProgress.Damage;
    private static int _castleHp = SaveProgress.CastleHp;

    public static float Speed => _speed;
    public static float Damage => _damage;
    public static float CastleHp => _castleHp;

    public static void AddSpeed(float value)
    {
        _speed += value;
        SaveProgress.Speed = _speed;
    }

    public static void AddDamage(float value)
    {
        _damage += value;
        SaveProgress.Damage = _damage;
    }

    public static void AddCastleHp(int value)
    {
        _castleHp += value;
        SaveProgress.CastleHp = _castleHp;
    }
}
