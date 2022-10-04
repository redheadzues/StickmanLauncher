using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;
    [SerializeField] private SpawnersContainer _spawnersContainer;
    [SerializeField] private CongratulationParticleContainer _particles;
    [SerializeField] private UIBar[] _sliders;
    

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
        DeactivateSliders();
    }

    private void OnWon()
    {
        DeactivateSpawners();
        DeactivateSliders();
        _particles.gameObject.SetActive(true);
    }

    private void DeactivateSliders()
    {
        for (int i = 1; i < _sliders.Length; i++)
            _sliders[i].gameObject.SetActive(true);
    }

    private void DeactivateSpawners()
    {
        _spawnersContainer.gameObject.SetActive(false);
    }
}
