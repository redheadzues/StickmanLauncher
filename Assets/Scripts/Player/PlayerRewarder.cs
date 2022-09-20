using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
public class PlayerRewarder : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;

    private PlayerWallet _playerWallet;
    private int _winReward = 100;
    private int _defeatReward = 25;

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
    }

    private void Awake()
    {
        _playerWallet = GetComponent<PlayerWallet>();
    }

    private void OnEnable()
    {
        _eventer.Won += OnWon;
        _eventer.Defeated += OnDefeated;
    }
    private void OnDisable()
    {
        _eventer.Won -= OnWon;
        _eventer.Defeated -= OnDefeated;
    }

    private void OnWon()
    {
        _playerWallet.AddMoney(_winReward);
    }

    private void OnDefeated()
    {
        _playerWallet.AddMoney(_defeatReward);
    }
}
