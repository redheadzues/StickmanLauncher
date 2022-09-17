using UnityEngine;

public class UISkin : MonoBehaviour
{
    [SerializeField] private Sprite _spriteIcon;
    [SerializeField] private int _price;
    [SerializeField] private bool isBuyed = false;
    [SerializeField] private bool isEquiped = false;

    private static int _ids;

    public Sprite Icon => _spriteIcon;
    public bool IsBuyed => isBuyed;
    public bool IsEquiped => isEquiped;

    public int Price => _price; 

    public int Id = ++_ids;

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
