using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public abstract class UISkinShop : MonoBehaviour
{
    [SerializeField] private List<UISkin> _skins;
    [SerializeField] private UISkinView _viewTemplate;
    [SerializeField] private GameObject _container;
    [SerializeField] private PlayerWallet _playerWallet;

    protected List<UISkinView> _views = new List<UISkinView>();
    protected event Action<UISkinView> SkinBuyed;

    private void OnValidate()
    {
        _playerWallet = FindObjectOfType<PlayerWallet>();
    }

    private void Awake()
    {
        SortByPrice();
        AddAllSkins();
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

    private void SortByPrice()
    {
        _skins = (_skins.OrderBy(skin => skin.Price).ToList());
    }

    private void AddAllSkins()
    {
        for (int i = 0; i < _skins.Count; i++)
            AddSkin(_skins[i]);
    }

    private void AddSkin(UISkin skin)
    {
        UISkinView view = Instantiate(_viewTemplate, _container.transform);
        view.Initialize(skin);

        _views.Add(view);

        if (skin.IsBuyed == false)
            view.BuyButtonClicked += OnSkinBuyed;
    }

    private void OnSkinBuyed(UISkinView view)
    {
        if (TrySellSkin(view.Skin) == true)
        {
            view.BuyButtonClicked -= OnSkinBuyed;
            view.Skin.Buy();
            SkinBuyed?.Invoke(view);
            //RefreshViewButton();
        }
    }

    private bool TrySellSkin(UISkin skin)
    {
        bool enoughMoney = _playerWallet.Money >= skin.Price;

        if (enoughMoney == true)
            _playerWallet.SpendMoney(skin.Price);

        return enoughMoney;
    }

    private void RefreshViewButton()
    {
        for (int i = 0; i < _views.Count; i++)
            _views[i].DisplayButton();
    }
}