using UnityEngine;

public class UIEnemyBar : UIBar
{
    [SerializeField] private EnemyCastleBreaker _castle;

    private void OnValidate()
    {
        _castle = FindObjectOfType<EnemyCastleBreaker>();
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