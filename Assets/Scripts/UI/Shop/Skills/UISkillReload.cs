
public class UISkillReload : UISkillView
{
    private void Awake()
    {
        UpdateValues();        
    }

    private void UpdateValues()
    {
        _skillValuelUpgrade = PlayerSkills.Reload;
        _skillMaxValue = PlayerSkills.MaxReload;
        _baseValue = PlayerSkills.BaseReload;
    }

    protected override void OnButtonUpgradeClick()
    {
        if(TryBuySkill() == true)
        {
            PlayerSkills.ImproveReload();
            UpdateValues();
            DisplyayView();
        }
    }
}
