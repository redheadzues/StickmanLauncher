using UnityEngine;

public class EnemyDifficultyRegulator : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;

    private static int _looseCountInRow;
    private static int _DifficultyNumber;

    private int _looseCountForDecrese = 2;

    private float _increaseDamageStep = 0.1f;
    private int _increaseCastleHpStep = 1;
    private int _increaseSpawnCountStep = 1;
    private float _increaseSpawnTineStep = 0.1f;

    private void OnEnable()
    {
        _eventer.Defeated += OnDefeat;
        _eventer.Won += OnWon;
    }

    private void OnDisable()
    {
        _eventer.Defeated -= OnDefeat;
        _eventer.Won -= OnWon;
    }

    private void OnWon()
    {
        _DifficultyNumber = GetRandomNumberOfDifficult();

        switch (_DifficultyNumber)
        {
            case 1:
                EnemyDifficulty.IncreaseDamage(_increaseDamageStep);
                break;

            case 2:
                EnemyDifficulty.IncreaseCastleHp(_increaseCastleHpStep);
                break;

            case 3:
                EnemyDifficulty.IncreaseSpawnCount(_increaseSpawnCountStep);
                break;

            case 4:
                EnemyDifficulty.IncreaseSpawnTime(_increaseSpawnTineStep);
                break;
        }
    }

    private void OnDefeat()
    {
        _looseCountInRow++;

        if (_looseCountInRow >= _looseCountForDecrese)
            DecreaseDifficulty();
    }

    private void DecreaseDifficulty()
    {
        switch (_DifficultyNumber)
        {
            case 1:
                EnemyDifficulty.DecreaseDamage(_increaseDamageStep);
                break;

            case 2:
                EnemyDifficulty.DecreaseCastleHp(_increaseCastleHpStep);
                break;

            case 3:
                EnemyDifficulty.DecreaseSpawnCount(_increaseSpawnCountStep);
                break;

            case 4:
                EnemyDifficulty.DecreaseSpawnTime(_increaseSpawnTineStep);
                break;
        }

        _DifficultyNumber = GetRandomNumberOfDifficult();
    }

    private int GetRandomNumberOfDifficult()
    {
        return UnityEngine.Random.Range(1, 5);
    }
}
