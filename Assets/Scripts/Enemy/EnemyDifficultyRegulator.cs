using UnityEngine;

public class EnemyDifficultyRegulator : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;

    private int _looseCountInRow;
    private int _looseCountForDecrese = 2;

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
    }

    private void OnEnable()
    {
        _eventer.Defeated += OnDefeat;
        _eventer.Won += OnWon;
        _looseCountInRow = SaveProgress.LooseInRow;
    }

    private void OnDisable()
    {
        _eventer.Defeated -= OnDefeat;
        _eventer.Won -= OnWon;
    }

    private void OnWon()
    {
        EnemyDifficulty.IncreaseDifficulty();
        _looseCountInRow = 0;
        SaveProgress.LooseInRow = _looseCountInRow;
    }

    private void OnDefeat()
    {
        _looseCountInRow++;

        if (_looseCountInRow >= _looseCountForDecrese)
        {
            EnemyDifficulty.DecreaseDifficulty();
            _looseCountInRow = 0;
        }

        SaveProgress.LooseInRow = _looseCountInRow;
    }
}
