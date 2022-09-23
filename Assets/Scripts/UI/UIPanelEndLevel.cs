using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelEndLevel : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;
    [SerializeField] private Image _imageResult;
    [SerializeField] private Sprite _spritePlayerWin;
    [SerializeField] private Sprite _spritePlayerDefeat;
    [SerializeField] private TMP_Text _textResult;
    [SerializeField] private TMP_Text _textReward;
    [SerializeField] private Button _buttonReward;
    [SerializeField] private Button _buttonRetry;
    [SerializeField] private Button _buttonWithoutAd;
    [SerializeField] private int _winReward;
    [SerializeField] private int _defeatReward;
    [SerializeField] private SDKIntegration _sdkIntegration;
    [SerializeField] private InterstitialAdLoader _interstitialAdLoader;

    private const string c_Win = "Win";
    private const string c_Defeat = "Defeat";

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
        _interstitialAdLoader = FindObjectOfType<InterstitialAdLoader>();
    }

    private void OnEnable()
    {
        _buttonReward.onClick.AddListener(OnButtonRewardClick);
        _buttonRetry.onClick.AddListener(OnButtonRetryClick);
        _buttonWithoutAd.onClick.AddListener(OnButtonWithoutAdClick);
        _sdkIntegration = FindObjectOfType<SDKIntegration>();
        _eventer.Defeated += OnDefeat;
        _eventer.Won += OnWon;
    }

    private void OnDisable()
    {
        _buttonReward.onClick.RemoveListener(OnButtonRewardClick);
        _buttonRetry.onClick.RemoveListener(OnButtonRetryClick);
        _buttonWithoutAd.onClick.RemoveListener(OnButtonWithoutAdClick);
    }

    public void OnWon()
    {
        _imageResult.sprite = _spritePlayerWin;
        _textResult.text = c_Win;
        _textReward.text = _winReward.ToString();
        _buttonReward.gameObject.SetActive(true);
        _buttonRetry.gameObject.SetActive(false);
    }

    public void OnDefeat()
    {
        _imageResult.sprite = _spritePlayerDefeat;
        _textResult.text = c_Defeat;
        _textReward.text = _defeatReward.ToString();
        _buttonRetry.gameObject.SetActive(true);
        _buttonReward.gameObject.SetActive(false);
    }

    private void OnButtonRewardClick()
    {
        _sdkIntegration.ShowRewardVideo();
    }

    private void OnButtonWithoutAdClick()
    {
        _interstitialAdLoader.TryShowInterstitialAd();
        gameObject.SetActive(false);
    }

    private void OnButtonRetryClick()
    {
        SceneLoader.ReloadScene();
        gameObject.SetActive(false);
    }
}
