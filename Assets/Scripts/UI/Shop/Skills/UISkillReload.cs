
public class UISkillReload : UISkillView
{
    protected new int _currentPrice => (int)(5 - _skillValuelUpgrade * _increasePriceStep);

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
