using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBounce : AudioSourceScript
{
    private Wall[] _walls;

    private void OnEnable()
    {
        _walls = FindObjectsOfType<Wall>();
        for (int i = 0; i < _walls.Length; i++)
            _walls[i].Bounced += PlaySound;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _walls.Length; i++)
            _walls[i].Bounced -= PlaySound;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            PlaySound();
    }
}
