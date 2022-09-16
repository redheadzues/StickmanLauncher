using TMPro;
using UnityEngine;

public class UIShopMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;

    private void OnEnable()
    {
        _textMoney.text = SaveProgress.Money.ToString();
    }
}
