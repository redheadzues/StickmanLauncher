using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;
    [SerializeField] private SpawnersContainer _spawnersContainer;
    [SerializeField] private CongratulationParticleContainer _particles;
    

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
        _spawnersContainer = FindObjectOfType<SpawnersContainer>();
        _particles = FindObjectOfType<CongratulationParticleContainer>();
    }

    private void OnEnable()
    {
        _eventer.Defeated += OnDefeat;
        _eventer.Won += OnWon;
        _particles.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _eventer.Defeated -= OnDefeat;
        _eventer.Won -= OnWon;
    }

    private void OnDefeat()
    {
        DeactivateSpawners();
    }

    private void OnWon()
    {
        DeactivateSpawners();
        _particles.gameObject.SetActive(true);
    }

    private void DeactivateSpawners()
    {
        _spawnersContainer.gameObject.SetActive(false);
    }
}
