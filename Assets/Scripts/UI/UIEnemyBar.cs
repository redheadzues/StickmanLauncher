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
        _castle.PartBreacked_getData += FillSlider;
    }

    private void OnDisable()
    {
        _castle.PartBreacked_getData -= FillSlider;
    }
}