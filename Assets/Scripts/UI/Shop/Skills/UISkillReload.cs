
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
    }

    protected override void OnButtonUpgradeClick()
    {
        PlayerSkills.ImproveReload();
        UpdateValues();
        DisplyayView();
    }
}
