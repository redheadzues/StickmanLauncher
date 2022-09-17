using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UISkinShop : MonoBehaviour
{
    [SerializeField] private List<UISkin> _skins;
    [SerializeField] private UISkinView _viewTemplate;
    [SerializeField] private GameObject _container;
    [SerializeField] private PlayerWallet _playerWallet;

    protected List<UISkinView> _views;

    private void Start()
    {
        AddAllSkins();
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
            view.Buyed += OnSkinBuyed;
    }

    private void OnSkinBuyed(UISkinView view, UISkin skin)
    {
        view.Buyed -= OnSkinBuyed;
        _playerWallet.SpendMoney(skin.Price);
    }
}
