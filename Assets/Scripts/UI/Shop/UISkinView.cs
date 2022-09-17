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

    public event Action<UISkinView, UISkin> Buyed;
    public event Action Equiped;

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
        InitializeButton(skin);
    }

    public void Unequip()
    {
        _textButton.text = c_Equip;
    }

    private void InitializeButton(UISkin skin)
    {
        if (skin.IsBuyed == false)
            _textButton.text = skin.Price.ToString();
        else
        {
            if (skin.IsEquiped == false)
                _textButton.text = c_Equip;
            else
                _textButton.text = c_Equiped;
        }
    }

    private void OnGetSkinButtonClick()
    {

    }

    private void SellSkin()
    {
        Buyed?.Invoke(this, _skin);
    }

    private void EquipSkin()
    {
        _textButton.text = c_Equiped;
        Equiped?.Invoke();
    }
}
