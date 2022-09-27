using UnityEngine;

public class InterstitialAdLoader : MonoBehaviour
{
    [SerializeField] private SDKIntegration _sdkIntegration;
    [SerializeField] private EnemyCastleBreaker _enemyCastleBreaker;
    
    private static float _lastTimeAdShow;
    private float _delayAd = 120;

    private void OnValidate()
    {
        _sdkIntegration = FindObjectOfType<SDKIntegration>();
        _enemyCastleBreaker = FindObjectOfType<EnemyCastleBreaker>();
    }

    private void OnEnable()
    {
        _enemyCastleBreaker.CastleBreacked += TryShowInterstitialAd;
    }

    private void OnDisable()
    {
        _enemyCastleBreaker.CastleBreacked -= TryShowInterstitialAd;
    }

    public void TryShowInterstitialAd()
    {
        if((_lastTimeAdShow == 0) || (_lastTimeAdShow + _delayAd < Time.time))
        {
            _sdkIntegration.ShowInterstitialAd();
            _lastTimeAdShow = Time.time;
        }    
    }
}
