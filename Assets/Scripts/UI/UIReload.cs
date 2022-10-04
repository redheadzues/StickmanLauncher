using System;
using System.Collections;
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
    [SerializeField] private int _cyclesBlincking;
    [SerializeField] private Color _blinkColor;

    private float _coroutineDelay = 0.1f;
    private float _percent = 100;
    private Coroutine _coroutine;

    private void OnValidate()
    {
        _tensioner = FindObjectOfType<ElasticTensioner>();
    }

    private void Awake()
    {
        _textTimer = GetComponentInChildren<TMP_Text>();
        _imageTimer = GetComponent<Image>();
        _textTimer.color = _imageTimer.color;
    }

    private void OnEnable()
    {
        _tensioner.ReloadStarted += OnReload;
        _tensioner.LaunchFailed += OnLaunchFailed;
        _imageTimer.fillAmount = 0;
        SetAlphaColorImageTimer(0);
        _textTimer.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _tensioner.ReloadStarted -= OnReload;
        _tensioner.LaunchFailed -= OnLaunchFailed;
    }

    private void OnLaunchFailed()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnFailedDisplay());
    }

    private void OnReload(float reloadTime)
    {
        _textTimer.gameObject.SetActive(true);
        _imageTimer.fillAmount = 1;
        SetAlphaColorImageTimer(_targetAlpha);
        StartCoroutine(OnReloadDisplay(reloadTime));
    }

    private void SetAlphaColorImageTimer(float value)
    {
        Color color = _imageTimer.color;
        color.a = value;
        _imageTimer.color = color;
    }

    private IEnumerator OnFailedDisplay()
    {
        Color _baseColor = _imageTimer.color;

        for(int i = 0; i < _cyclesBlincking*2; i++)
        {
            if (_imageTimer.color == _blinkColor)
            {
                _imageTimer.color = _baseColor;
                _textTimer.color = _baseColor;
            }
            else
            {
                _imageTimer.color = _blinkColor;
                _textTimer.color = _blinkColor;
            }

            yield return new WaitForSeconds(0.1f);
        }        
    }

    private IEnumerator OnReloadDisplay(float reloadTime)
    {
        float stepFillAmount = (reloadTime * _coroutineDelay)/_percent;
        float displayReload = reloadTime;

        while(displayReload > 0)
        {
            displayReload -= _coroutineDelay;
            _textTimer.text = Math.Round(displayReload, 2).ToString();
            _imageTimer.fillAmount -= stepFillAmount;

            yield return new WaitForSeconds(_coroutineDelay);
        }

        SetAlphaColorImageTimer(0);

        _textTimer.gameObject.SetActive(false);
    }
}
