using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterstitialAdLoader : MonoBehaviour
{
    [SerializeField] private SDKIntegration _sdkIntegration;

    private void OnValidate()
    {
        _sdkIntegration = FindObjectOfType<SDKIntegration>();
    }

    public void TryShowInterstitialAd()
    {
        print("im trying)");
        _sdkIntegration.ShowInterstitialAd(onCloseCallback: OnCloseCallback);

    }

    private void OnCloseCallback(bool wasShawn)
    {
        SceneLoader.LoadNextScene();
    }
}
