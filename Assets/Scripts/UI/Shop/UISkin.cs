using System;
using UnityEngine;

public class UISkin : MonoBehaviour
{
    [SerializeField] private Sprite _spriteIcon;
    [SerializeField] private int _price;
    [SerializeField] private bool isEquiped;
    [SerializeField] private bool isBuyed;
    
    private static int _ids;
    private string _skinName;

    public Sprite Icon => _spriteIcon;
    public bool IsBuyed => isBuyed;
    public bool IsEquiped => isEquiped;

    public int Price => _price;

    public int Id = ++_ids;

    private string SetIsBuyed
    {
        get
        {
            if (PlayerPrefs.HasKey(_skinName))
                return PlayerPrefs.GetString(_skinName);
            else
                return "false";
        }
        set { PlayerPrefs.SetString(_skinName, value); }
    }

    private void Awake()
    {
        _skinName = GeneratePrefsKey();

        if(Id == 0)
            SetIsBuyed = Convert.ToString(true);

        isBuyed = Convert.ToBoolean(SetIsBuyed);

        if (Id == SaveProgress.EquipedSkinId)
            isEquiped = true;
    }

    public void Buy()
    {
        isBuyed = true;
        SetIsBuyed = Convert.ToString(isBuyed);
    }

    public void Equip()
    {
        isEquiped = true;
    }

    public void Unequip()
    {
        isEquiped = false;
    }

    private string GeneratePrefsKey()
    {
        return $"SkinIsBuyed{Id}";
    }
}