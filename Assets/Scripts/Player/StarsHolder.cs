using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHolder : MonoBehaviour
{
    private int _stars;

    private void Start()
    {
        _stars = SaveProgress.Stars;
    }

    public void AddStars(int value)
    {
        SetStars(_stars + value);
    }

    private void SetStars(int value)
    {
        _stars = value;
        SaveProgress.Stars = _stars;
    }
}
