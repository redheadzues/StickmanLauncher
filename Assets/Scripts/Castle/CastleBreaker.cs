using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastleBreaker : MonoBehaviour
{
    [SerializeField] private List<CastlePartBreaker> _parts;
    [SerializeField] private SpawnerExplosion _explosion;

    protected float CastleHp;

    private int _currentPartIndex;
    private float _currentCastleHp;

    public float PercentHp => (_currentCastleHp * 100 / CastleHp) ;
    private float _percentBreaked => (_currentPartIndex * 100 / _parts.Count) ;
    
    public event Action<float, float> HpChanged;
    public event Action PartBreacked;
    public event Action CastleBreacked;

    private void Start()
    {
        _currentCastleHp = CastleHp;
        HpChanged?.Invoke(_currentCastleHp, CastleHp);
    }

    private void OnValidate()
    {
        _explosion = FindObjectOfType<SpawnerExplosion>();
    }

    protected void ApplyDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentCastleHp -= damage;

        TryDestroyPart();
    }

    private void TryDestroyPart()
    {
        if (_currentPartIndex > _parts.Count - 1)
            return;

        if (_percentBreaked < (100 - PercentHp))
        {
            Destroy();
            TryDestroyPart();
        }
    }

    protected void Destroy()
    {
        _parts[_currentPartIndex].Activate();

        if(_explosion != null)
            _explosion.SetParticle(_parts[_currentPartIndex].transform.position);

        _currentPartIndex++;
        HpChanged?.Invoke(_currentCastleHp, CastleHp);
        PartBreacked?.Invoke();



        TryCompleteLevel();
    }

    private void TryCompleteLevel()
    {
        if (_currentPartIndex == _parts.Count)
            CastleBreacked?.Invoke();
    }
}
