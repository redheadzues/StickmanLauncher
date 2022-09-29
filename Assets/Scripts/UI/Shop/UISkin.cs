using System;
using UnityEngine;

public class UISkin : MonoBehaviour
{
    [SerializeField] private Sprite _spriteIcon;
    [SerializeField] private int _price;
    
    private bool isBuyed = false;
    private bool isEquiped = false;
    private static int _ids;

    public Sprite Icon => _spriteIcon;
    public bool IsBuyed => isBuyed;
    public bool IsEquiped => isEquiped;

    public int Price => _price;

    public int Id = ++_ids;

    private void Awake()
    {
        isBuyed = Convert.ToBoolean(SetIsBuyed);

        if (Id == SaveProgress.EquipedSkinId)
            isEquiped = true;
    }

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

    private string SetIsBuyed
    {
        get
        {
            if (PlayerPrefs.HasKey(GeneratePrefsKeyBuyed()))
                return PlayerPrefs.GetString(GeneratePrefsKeyBuyed());
            else
                return "false";
        }
        set { PlayerPrefs.SetString(GeneratePrefsKeyBuyed(), value); }
    }

    private string GeneratePrefsKeyBuyed()
    {
        return $"SkinIsBuyed{Id}";
    }
}