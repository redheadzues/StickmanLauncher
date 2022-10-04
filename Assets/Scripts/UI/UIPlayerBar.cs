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
        _castle.HpChanged += FillSlider;
    }

    private void OnDisable()
    {
        _castle.HpChanged -= FillSlider;
    }
}
