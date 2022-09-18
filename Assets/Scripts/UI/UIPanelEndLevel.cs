using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelEndLevel : MonoBehaviour
{
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
    [SerializeField] private UICustomizer _customizer;

    private const string c_Win = "Win";
    private const string c_Defeat = "Defeat";



    private void OnEnable()
    {
        _buttonReward.onClick.AddListener(OnButtonRewardClick);
        _buttonRetry.onClick.AddListener(OnButtonRetryClick);
        _buttonWithoutAd.onClick.AddListener(OButtonWithoutAdClick);
        _customizer.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _buttonReward.onClick.RemoveListener(OnButtonRewardClick);
        _buttonRetry.onClick.RemoveListener(OnButtonRetryClick);
        _buttonWithoutAd.onClick.RemoveListener(OButtonWithoutAdClick);
    }

    public void OnPlayerWin()
    {
        _imageResult.sprite = _spritePlayerWin;
        _textResult.text = c_Win;
        _textReward.text = _winReward.ToString();
        _buttonReward.gameObject.SetActive(true);
        _buttonRetry.gameObject.SetActive(false);

    }

    public void OnPlayerDefeat()
    {
        _imageResult.sprite = _spritePlayerDefeat;
        _textResult.text = c_Defeat;
        _textReward.text = _defeatReward.ToString();
        _buttonRetry.gameObject.SetActive(true);
        _buttonReward.gameObject.SetActive(false);
    }

    private void OnButtonRewardClick()
    {

    }

    private void OButtonWithoutAdClick()
    {
        SceneLoader.LoadNextScene();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void OnButtonRetryClick()
    {
        SceneLoader.ReloadScene();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
