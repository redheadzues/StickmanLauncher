using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _money;

    public int Money => _money;

    private void Start()
    {
        _money = SaveProgress.Money;
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
    }
}
