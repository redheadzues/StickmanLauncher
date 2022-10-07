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
    private Coroutine _coroutineFailed;
    private Color _baseColor;


    private void OnValidate()
    {
        _tensioner = FindObjectOfType<ElasticTensioner>();
    }

    private void Awake()
    {
        _textTimer = GetComponentInChildren<TMP_Text>();
        _imageTimer = GetComponent<Image>();
        _baseColor = _imageTimer.color;
    }

    private void OnEnable()
    {
        _tensioner.ReloadStarted += OnReloadStarted;
        _tensioner.LaunchFailed += OnLaunchFailed;
        _imageTimer.fillAmount = 0;
        SetAlphaColorImageTimer(0);
        _textTimer.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _tensioner.ReloadStarted -= OnReloadStarted;
        _tensioner.LaunchFailed -= OnLaunchFailed;
    }

    private void OnLaunchFailed()
    {
        if (_coroutineFailed != null)
            StopCoroutine(_coroutineFailed);

        _coroutineFailed = StartCoroutine(OnFailedDisplay());
    }

    private void OnReloadStarted(float reloadTime)
    {
        _textTimer.gameObject.SetActive(true);
        _imageTimer.fillAmount = 1;
        _imageTimer.color = _baseColor;
        _textTimer.color = _baseColor;
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
        float stepFillAmount = _coroutineDelay/reloadTime;
        float displayReload = reloadTime;

        while(displayReload > 0)
        {
            displayReload -= _coroutineDelay;
            _textTimer.text = Math.Round(displayReload, 2).ToString();
            _imageTimer.fillAmount -= stepFillAmount;

            yield return new WaitForSeconds(_coroutineDelay);
        }

        _textTimer.gameObject.SetActive(false);
        SetAlphaColorImageTimer(0);

        if(_coroutineFailed != null)
            StopCoroutine(_coroutineFailed);
    }
}
