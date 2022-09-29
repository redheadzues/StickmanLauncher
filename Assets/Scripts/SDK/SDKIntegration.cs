using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.VKGames;
using System;

public class SDKIntegration : MonoBehaviour
{
    public event Action Initialized;
    public event Action Rewarded;
    public event Action VideoOpened;
    public event Action VideoClosed;


    private IEnumerator Start()
    {

#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

#if YANDEX_GAMES
        yield return YandexGamesSdk.Initialize();
#endif

#if VK_GAMES
        yield return VKGamesSdk.Initialize();
#endif
    }

    public void ShowInterstitialAd(
        Action onOpenCallback = null, 
        Action<bool> onCloseCallback = null,
        Action<string> onErrorCallback = null, 
        Action onOfflineCallback = null)
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        onCloseCallback?.Invoke(true);
       return;
#endif

#if YANDEX_GAMES
        InterstitialAd.Show(onOpenCallback, onCloseCallback, onErrorCallback, onOfflineCallback);
#endif
    }

    public void ShowRewardVideo()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        OnRewardedCallback();
        return;
#endif

#if YANDEX_GAMES
        Agava.YandexGames.VideoAd.Show(OnVideoOpenCallback, OnRewardedCallback, OnVideoCloseCallback, OnVideoErrorCallback);
#endif
    }

    private void OnInitialized()
    {
        Initialized?.Invoke();
    }

    private void OnAdOpened()
    {
        AudioListener.pause = true;
    }

    private void OnVideoOpenCallback()
    {
        VideoOpened?.Invoke();
    }

    private void OnVideoCloseCallback()
    {
        VideoClosed?.Invoke();
    }

    private void OnRewardedCallback()
    {
        Rewarded?.Invoke();
        print("Invoked");
    }

    private void OnVideoErrorCallback(string message)
    {
        Debug.LogError(message);
    }
}
