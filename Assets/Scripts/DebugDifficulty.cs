using TMPro;
using UnityEngine;

public class DebugDifficulty : MonoBehaviour
{
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _castleHp;
    [SerializeField] private TMP_Text _spawnCount;
    [SerializeField] private TMP_Text _spawnTime;

    private void Start()
    {
        _damage.text += EnemyDifficulty.Damage;
        _castleHp.text += EnemyDifficulty.CastleHp;
        _spawnCount.text += EnemyDifficulty.SpawnCount;
        _spawnTime.text += EnemyDifficulty.SpawnTime;
    }

    public void ChangeVisible()
    {
        if(gameObject.activeSelf == false)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
