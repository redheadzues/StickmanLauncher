using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillAttack : UISkillView
{
    private void Awake()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        _skillValuelUpgrade = PlayerSkills.Damage;
        _skillMaxValue = PlayerSkills.MaxDamage;
    }

    protected override void OnButtonUpgradeClick()
    {
        PlayerSkills.ImproveDamage();
        UpdateValues();
        DisplyayView();
    }
}
