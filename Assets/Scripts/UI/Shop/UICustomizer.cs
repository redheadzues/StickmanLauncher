using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomizer : UISkinShop
{
    private void OnEnable()
    {
        for (int i = 0; i < _views.Count; i++)
            _views[i].Equiped += OnEquiped;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _views.Count; i++)
            _views[i].Equiped -= OnEquiped;
    }

    private void OnEquiped(UISkinView view)
    {
        for (int i = 0; i < _views.Count; i++)
            _views[i].Skin.Unequip();

        view.Skin.Equip();
        SaveProgress.SkinId = view.Skin.Id;

        for (int i = 0; i < _views.Count; i++)
            _views[i].DisplayButton();
    }


}
