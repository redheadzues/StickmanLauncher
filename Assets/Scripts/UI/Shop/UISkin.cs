using UnityEngine;

public class UISkin : MonoBehaviour
{
    [SerializeField] private Sprite _spriteIcon;
    [SerializeField] private int _price;

    private bool isBuyed = false;
    private bool isEquiped = false;

    public void Buy()
    {
        isBuyed = true;
    }

    public void Equip()
    {
        isEquiped = true;
    }

    public void Unequip()
    {
        isEquiped = false;
    }
}
