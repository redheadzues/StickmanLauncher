public class UISkillHealth : UISkillView
{
    private void Start()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        _skillValuelUpgrade = PlayerSkills.CastleHp;
        _skillMaxValue = PlayerSkills.MaxCastleHp;
    }

    protected override void OnButtonUpgradeClick()
    {
        PlayerSkills.ImproveCastleHp();
        UpdateValues();
        DisplyayView();
    }
}
