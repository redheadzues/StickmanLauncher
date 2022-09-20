using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;
    [SerializeField] private SpawnersContainer _spawnersContainer;
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
        _spawnersContainer = FindObjectOfType<SpawnersContainer>();
        _playerWallet = FindObjectOfType<PlayerWallet>();
    }

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

    private void OnDefeat()
    {
        
    }

    private void OnWon()
    {
        
    }
}
