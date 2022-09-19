using System;
using TMPro;
using UnityEngine;

public class UIShopMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnValidate()
    {
        _playerWallet = FindObjectOfType<PlayerWallet>();
    }

    private void OnEnable()
    {
        _textMoney.text = SaveProgress.Money.ToString();
        _playerWallet.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _playerWallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _textMoney.text = money.ToString();
    }
}
