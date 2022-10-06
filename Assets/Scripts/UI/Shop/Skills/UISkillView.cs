using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UISkillView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Image _imageProgress;
    [SerializeField] private Button _buttonUpgrade;
    [SerializeField] private int _startPrice;
    [SerializeField] private int _increasePriceStep;
    [SerializeField] private float _fillingSpeed;

    protected float _skillValuelUpgrade;
    protected float _skillMaxValue;

    private Coroutine _coroutine;
    
    protected int _currentPrice => (int)(_skillValuelUpgrade * _increasePriceStep);

    private void OnEnable()
    {
        _buttonUpgrade.onClick.AddListener(OnButtonUpgradeClick);
        _imageProgress.fillAmount = _skillValuelUpgrade / _skillMaxValue;
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

    private void StartFilling()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnFilling());
    }

    private IEnumerator OnFilling()
    {
        while(_imageProgress.fillAmount != (_skillValuelUpgrade / _skillMaxValue))
        {
            _imageProgress.fillAmount = Mathf.Lerp(_imageProgress.fillAmount, _skillValuelUpgrade / _skillMaxValue, _fillingSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
