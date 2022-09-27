using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDuplicate : AudioSourceScript
{
    private MultiplyTable[] _multiply;

    private void OnEnable()
    {
        _multiply = FindObjectsOfType<MultiplyTable>();

        for (int i = 0; i < _multiply.Length; i++)
        {
            _multiply[i].Duplicated += PlaySound;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _multiply.Length; i++)
        {
            _multiply[i].Duplicated -= PlaySound;
        }
    }
}
