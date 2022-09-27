using UnityEngine;

public class UIPlayerBar : UIBar
{
    [SerializeField] private AlliedCastleBreacker _castle;

    private void OnValidate()
    {
        _castle = FindObjectOfType<AlliedCastleBreacker>();
    }

    private void OnEnable()
    {
        _castle.PartBreacked_getData += FillSlider;
    }

    private void OnDisable()
    {
        _castle.PartBreacked_getData -= FillSlider;
    }
}
