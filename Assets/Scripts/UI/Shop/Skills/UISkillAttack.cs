using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillAttack : UISkillView
{
    private void Awake()
    {
        UpdateValues();
        print(PlayerSkills.Damage);
    }

    private void UpdateValues()
    {
        _skillValuelUpgrade = PlayerSkills.Damage;
        _skillMaxValue = PlayerSkills.MaxDamage;
        _baseValue = PlayerSkills.BaseDamage;
    }

    protected override void OnButtonUpgradeClick()
    {
        if(TryBuySkill() == true)
        {
            PlayerSkills.ImproveDamage();
            UpdateValues();
            DisplyayView();
            print(PlayerSkills.Damage);
        }
    }
}
