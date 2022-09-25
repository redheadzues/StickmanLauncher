using Agava.WebUtility;
using System;
using UnityEngine;

public class BackgroundMuteTracker : MonoBehaviour
{
    [SerializeField] private SDKIntegration _sdkIntegration;

    private void OnValidate()
    {
        _sdkIntegration = FindObjectOfType<SDKIntegration>();
    }

    private void OnEnable()
    {
        _sdkIntegration.VideoOpened += OnVideoOpened;
        _sdkIntegration.VideoClosed += OnVideoClosed;
        WebApplication.InBackgroundChangeEvent += OnBackgroundChange;
    }

    private void OnDisable()
    {
        _sdkIntegration.VideoOpened -= OnVideoOpened;
        _sdkIntegration.VideoClosed -= OnVideoClosed;
        WebApplication.InBackgroundChangeEvent -= OnBackgroundChange;
    }

    private void OnVideoOpened()
    {
        OnBackgroundChange(true);
    }

    private void OnVideoClosed()
    {
        OnBackgroundChange(false);
    }

    private void OnBackgroundChange(bool isBackground)
    {
        AudioListener.pause = isBackground;
    }
}
