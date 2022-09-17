using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomizer : UISkinShop
{
    private void OnEnable()
    {
        if (_views != null)
            for (int i = 0; i < _views.Count; i++)
                _views[i].Equiped += OnEquiped;
    }

    private void OnEquiped()
    {
        throw new NotImplementedException();
    }
}
