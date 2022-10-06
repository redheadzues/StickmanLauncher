using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillSpeed : UISkillView
{
    private void Awake()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        _skillValuelUpgrade = PlayerSkills.Speed;
        _skillMaxValue = PlayerSkills.MaxSpeed;
        _baseValue = PlayerSkills.BaseSpeed;
    }

    protected override void OnButtonUpgradeClick()
    {
        PlayerSkills.ImproveSpeed();
        UpdateValues();
        DisplyayView();
    }
}
