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
    [SerializeField] private PlayerWallet _playerWallet;

    private const string c_Win = "Win";
    private const string c_Defeat = "Defeat";

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
    }

    private void OnEnable()
    {
        _buttonReward.onClick.AddListener(OnButtonRewardClick);
        _buttonRetry.onClick.AddListener(OnButtonRetryClick);
        _buttonWithoutAd.onClick.AddListener(OButtonWithoutAdClick);
        _eventer.Defeated += OnDefeat;
        _eventer.Won += OnWon;
        _playerWallet = FindObjectOfType<PlayerWallet>();
    }

    private void OnDisable()
    {
        _buttonReward.onClick.RemoveListener(OnButtonRewardClick);
        _buttonRetry.onClick.RemoveListener(OnButtonRetryClick);
        _buttonWithoutAd.onClick.RemoveListener(OButtonWithoutAdClick);
    }

    public void OnWon()
    {
        _imageResult.sprite = _spritePlayerWin;
        _textResult.text = c_Win;
        _textReward.text = _winReward.ToString();
        _buttonReward.gameObject.SetActive(true);
        _buttonRetry.gameObject.SetActive(false);
        _playerWallet.AddMoney(_winReward);

    }

    public void OnDefeat()
    {
        _imageResult.sprite = _spritePlayerDefeat;
        _textResult.text = c_Defeat;
        _textReward.text = _defeatReward.ToString();
        _buttonRetry.gameObject.SetActive(true);
        _buttonReward.gameObject.SetActive(false);
        _playerWallet.AddMoney(_defeatReward);
    }

    private void OnButtonRewardClick()
    {

    }

    private void OButtonWithoutAdClick()
    {
        SceneLoader.LoadNextScene();
        gameObject.SetActive(false);
    }

    private void OnButtonRetryClick()
    {
        SceneLoader.ReloadScene();
        gameObject.SetActive(false);
    }
}
