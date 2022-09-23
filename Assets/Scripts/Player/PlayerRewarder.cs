using System;
using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
public class PlayerRewarder : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;
    [SerializeField] private SDKIntegration _sdkIntegration;

    private PlayerWallet _playerWallet;
    private int _winReward = 100;
    private int _defeatReward = 25;
    private int _rewardMultiply = 4;

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
        _sdkIntegration = FindObjectOfType<SDKIntegration>();
    }

    private void Awake()
    {
        _playerWallet = GetComponent<PlayerWallet>();
    }

    private void OnEnable()
    {
        _eventer.Won += OnWon;
        _eventer.Defeated += OnDefeated;
        _sdkIntegration.Rewarded += OnRewarded;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
            print(_sdkIntegration);
    }

    private void OnDisable()
    {
        _eventer.Won -= OnWon;
        _eventer.Defeated -= OnDefeated;
        _sdkIntegration.Rewarded -= OnRewarded;
    }

    private void OnWon()
    {
        _playerWallet.AddMoney(_winReward);
    }

    private void OnDefeated()
    {
        _playerWallet.AddMoney(_defeatReward);
    }

    private void OnRewarded()
    {
        print("Rewarding");
        _playerWallet.AddMoney(_winReward * _rewardMultiply);
        print("Rewarded");
    }
}
