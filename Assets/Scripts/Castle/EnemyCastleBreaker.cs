using UnityEngine;

public class EnemyCastleBreaker : CastleBreaker
{
    private void Awake()
    {
        CastleHp = EnemyDifficulty.CastleHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out StickmanFlightOperator flyOperator))
        {
            ApplyDamage(PlayerSkills.Damage);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Destroy();
    }
}
