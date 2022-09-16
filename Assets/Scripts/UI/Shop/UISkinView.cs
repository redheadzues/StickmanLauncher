using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkinView : MonoBehaviour
{
    [SerializeField] private Image _imageTemplate;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _textButton;

    private const string c_Equip = "Одеть";
    private const string c_Equiped = "Одето";

    public void InitializeView(UISkin skin)
    {
        _imageTemplate.sprite = skin.Icon;
        InitializeButton(skin);
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
}
