using UnityEngine;

public class InterstitialAdLoader : MonoBehaviour
{
    [SerializeField] private SDKIntegration _sdkIntegration;
    
    private static float _lastTimeAdShow;
    private float _delayAd = 120;

    private void OnValidate()
    {
        _sdkIntegration = FindObjectOfType<SDKIntegration>();
    }

    public void TryShowInterstitialAd()
    {
        if((_lastTimeAdShow == 0) || (_lastTimeAdShow + _delayAd < Time.time))
        {
            _sdkIntegration.ShowInterstitialAd(onCloseCallback: OnCloseCallback, onErrorCallback: OnErrorCallback);
            _lastTimeAdShow = Time.time;
        }
        else
            SceneLoader.LoadNextScene();      
    }

    private void OnCloseCallback(bool wasShawn)
    {
        SceneLoader.LoadNextScene();
    }

    private void OnErrorCallback(string error)
    {
        print(error);
        SceneLoader.LoadNextScene();
    }
}
