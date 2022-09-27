using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioElasticShot : AudioSourceScript
{
    private StickmanLauncher _launcher;

    private void OnEnable()
    {
        _launcher = FindObjectOfType<StickmanLauncher>();
        _launcher.Successfully += PlaySound;
    }

    private void OnDisable()
    {
        _launcher.Successfully -= PlaySound;
    }
}
