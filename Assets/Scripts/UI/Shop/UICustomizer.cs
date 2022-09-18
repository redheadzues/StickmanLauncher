using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomizer : UISkinShop
{
    private void OnEnable()
    {
        Debug.Log(_views == null);

        if (_views != null)
            for (int i = 0; i < _views.Count; i++)
                _views[i].Equiped += OnEquiped;
    }

    private void OnDisable()
    {
        if (_views != null)
            for (int i = 0; i < _views.Count; i++)
                _views[i].Equiped -= OnEquiped;
    }

    private void OnEquiped(UISkinView view)
    {
        Debug.Log("here");

        for (int i = 0; i < _views.Count; i++)
            _views[i].Skin.Unequip();

        view.Skin.Equip();
        SaveProgress.SkinId = view.Skin.Id;
        Debug.Log(SaveProgress.SkinId);

        for (int i = 0; i < _views.Count; i++)
            _views[i].DisplayButton();
    }


}
