using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkinView : MonoBehaviour
{
    [SerializeField] private Image _imageTemplate;
    [SerializeField] private Button _buttonGetSkin;
    [SerializeField] private TMP_Text _textButton;

    private const string c_Equip = "Одеть";
    private const string c_Equiped = "Одето";
    private UISkin _skin;

    public event Action<UISkinView> BuyButtonClicked;
    public event Action<UISkinView> Equiped;

    public UISkin Skin => _skin;

    private void OnEnable()
    {
        _buttonGetSkin.onClick.AddListener(OnGetSkinButtonClick);
    }

    private void OnDisable()
    {
        _buttonGetSkin.onClick.RemoveListener(OnGetSkinButtonClick);
    }

    public void Initialize(UISkin skin)
    {
        _skin = skin;
        _imageTemplate.sprite = skin.Icon;
        DisplayButton();
    }

    public void DisplayButton()
    {
        if (_skin.IsBuyed == false)
            _textButton.text = _skin.Price.ToString();
        else
        {
            if (_skin.IsEquiped == false)
                _textButton.text = c_Equip;
            else
                _textButton.text = c_Equiped;
        }
    }

    private void OnGetSkinButtonClick()
    {
        if (_skin.IsBuyed == false)
            TrySellSkin();
        else
        {
            if (_skin.IsEquiped == false)
                EquipSkin();
        }
    }

    private void TrySellSkin()
    {
        BuyButtonClicked?.Invoke(this);
    }

    private void EquipSkin()
    {
        _textButton.text = c_Equiped;
        Equiped?.Invoke(this);
    }
}
