using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UISkillView : MonoBehaviour
{
    [SerializeField] protected PlayerWallet _playerWallet;
    [SerializeField] protected int _increasePriceStep;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Image _imageProgress;
    [SerializeField] private Button _buttonUpgrade;
    [SerializeField] private int _startPrice;
    [SerializeField] private float _fillingSpeed;

    protected float _skillValuelUpgrade;
    protected float _skillMaxValue;
    protected float _baseValue;

    private Coroutine _coroutine;
    
    protected int _currentPrice => (int)(_startPrice + _skillValuelUpgrade * _increasePriceStep);

    private void OnValidate()
    {
        _playerWallet = FindObjectOfType<PlayerWallet>();
    }

    private void OnEnable()
    {
        _buttonUpgrade.onClick.AddListener(OnButtonUpgradeClick);
        _imageProgress.fillAmount = (_skillValuelUpgrade - _baseValue) / (_skillMaxValue - _baseValue);
        DisplyayView();
    }

    private void OnDisable()
    {
        _buttonUpgrade.onClick.RemoveListener(OnButtonUpgradeClick);
    }

    protected abstract void OnButtonUpgradeClick();

    protected void DisplyayView()
    {
        StartFilling();
        _textPrice.text = _currentPrice.ToString();
    }

    protected bool TryBuySkill()
    {
        bool isEnough = _playerWallet.Money > _currentPrice;

        if (isEnough == true)
            _playerWallet.SpendMoney(_currentPrice);

        return isEnough;
    }

    private void StartFilling()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnFilling());
    }

    private IEnumerator OnFilling()
    {
        while(_imageProgress.fillAmount != (_skillValuelUpgrade - _baseValue) / (_skillMaxValue - _baseValue))
        {
            _imageProgress.fillAmount = Mathf.Lerp(_imageProgress.fillAmount, (_skillValuelUpgrade - _baseValue) / (_skillMaxValue - _baseValue), _fillingSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
