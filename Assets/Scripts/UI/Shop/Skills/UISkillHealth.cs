public class UISkillHealth : UISkillView
{
    private void Awake()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        _skillValuelUpgrade = PlayerSkills.CastleHp;
        _skillMaxValue = PlayerSkills.MaxCastleHp;
        _baseValue = PlayerSkills.BaseCastleHp;
    }

    protected override void OnButtonUpgradeClick()
    {
        if(TryBuySkill() == true)
        {
            PlayerSkills.ImproveCastleHp();
            UpdateValues();
            DisplyayView();
        }
    }
}
