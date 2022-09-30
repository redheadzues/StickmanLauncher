using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIReload : MonoBehaviour
{
    [SerializeField] private ElasticTensioner _tensioner;
    [SerializeField] private TMP_Text _textTimer;
    [SerializeField] private Image _imageTimer;
    [SerializeField] private float _targetAlpha;

    private void OnValidate()
    {
        _tensioner = FindObjectOfType<ElasticTensioner>();
    }

    private void Awake()
    {
        _textTimer = GetComponentInChildren<TMP_Text>();
        _imageTimer = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _tensioner.ReloadTimeChanged += OnReload;
    }

    private void OnDisable()
    {
        _tensioner.ReloadTimeChanged -= OnReload;
    }

    private void OnReload()
    {
        Color color = _imageTimer.color;
        color.a = _targetAlpha;
        _imageTimer.color = color;

    }
}
