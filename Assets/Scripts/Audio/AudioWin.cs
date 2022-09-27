using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWin : AudioSourceScript
{
    private EnemyCastleBreaker _castle;

    private void OnEnable()
    {
        _castle = FindObjectOfType<EnemyCastleBreaker>();
        _castle.CastleBreacked += PlaySound;
        _castle.CastleBreacked += OnCastleBreaked;
    }

    private void OnDisable()
    {
        _castle.CastleBreacked -= PlaySound;
        _castle.CastleBreacked -= OnCastleBreaked;
    }

    private void OnCastleBreaked()
    {
        IncreaseVolume();
    }

}
