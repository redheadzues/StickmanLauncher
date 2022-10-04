using UnityEngine;

public class AlliedCastleBreacker : CastleBreaker
{
    private void Awake()
    {
        CastleHp = PlayerSkills.CastleHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out StickmanPathFollower follower))
        {
            ApplyDamage(EnemyDifficulty.Damage);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            Destroy();
    }
}
