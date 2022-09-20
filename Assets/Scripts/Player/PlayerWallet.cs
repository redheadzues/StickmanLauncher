using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _money;

    public int Money => _money;

    public event Action<int> MoneyChanged;

    private void Start()
    {
        _money = SaveProgress.Money;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
            AddMoney(1000);
        if (Input.GetKeyUp(KeyCode.KeypadMinus))
            SpendMoney(1000);
    }

    public void AddMoney(int value)
    {
        SetMoney(_money + value);
    }

    public void SpendMoney(int value)
    {
        SetMoney(_money - value);
    }

    private void SetMoney(int value)
    {
        _money = value;
        SaveProgress.Money = _money;
        MoneyChanged?.Invoke(_money);
    }
}
