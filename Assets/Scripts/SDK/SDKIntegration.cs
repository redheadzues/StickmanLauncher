using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.VKGames;
using System;

public class SDKIntegration : MonoBehaviour
{
    public static SDKIntegration Instance = null;

    public bool IsInitialized { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

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
}
