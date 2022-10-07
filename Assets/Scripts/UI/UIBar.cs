using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _textHp;

    protected void FillSlider(float value, float maxValue)
    {
        _slider.value = value/maxValue;
        _textHp.text = $"{Math.Round(value,2)} / {maxValue}";
    }
}
