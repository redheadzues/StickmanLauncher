using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkinView : MonoBehaviour
{
    [SerializeField] private Image _imageTemplate;
    [SerializeField] private Button _buttonGetSkin;
    [SerializeField] private TMP_Text _textButton;
    [SerializeField] private Image _imageCoin;

    private const string c_Equip = "Надеть";
    private const string c_Equiped = "Надето";
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
            _imageCoin.gameObject.SetActive(false);

            if (_skin.IsEquiped == false)
            {
                _textButton.text = c_Equip;
                ChangeButtonColor(Color.white);
            }
            else
            {
                _textButton.text = c_Equiped;
                ChangeButtonColor(Color.yellow);
            }
        }
    }

    private void ChangeButtonColor(Color color)
    {
        _buttonGetSkin.image.color = color;
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
        Equiped?.Invoke(this);
    }
}