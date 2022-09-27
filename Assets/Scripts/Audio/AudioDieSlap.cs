using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDieSlap : AudioSourceScript
{
    private SpawnerDeathParticle _death;

    private void OnEnable()
    {
        _death = FindObjectOfType<SpawnerDeathParticle>();

        _death.ParticleSetted += PlaySound;
    }

    private void OnDisable()
    {
        _death.ParticleSetted -= PlaySound;
    }
}
