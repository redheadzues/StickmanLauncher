using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExplosion : AudioSourceScript
{
    private CastleBreaker[] _breakers;

    private void OnEnable()
    {
        _breakers = FindObjectsOfType<CastleBreaker>();

        for (int i = 0; i < _breakers.Length; i++)
        {
            _breakers[i].PartBreacked += PlaySound;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _breakers.Length; i++)
        {
            _breakers[i].PartBreacked -= PlaySound;
        }
    }
}
