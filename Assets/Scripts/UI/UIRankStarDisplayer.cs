using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRankStarDisplayer : MonoBehaviour
{
    [SerializeField] private LevelEvent _eventer;
    [SerializeField] private UIStarAnimator[] _starAnimators;
    [SerializeField] private AlliedCastleBreacker _alliedCastleBreaker;
    [SerializeField] private float _valueToGetThreeStarPercent;
    [SerializeField] private float _valueToGetTwoStarPercent;
    [SerializeField] private float _valueToGetOneStarPercent;

    private int _displayStarsCount;

    private void OnValidate()
    {
        _eventer = FindObjectOfType<LevelEvent>();
        _alliedCastleBreaker = FindObjectOfType<AlliedCastleBreacker>();
        _starAnimators = GetComponentsInChildren<UIStarAnimator>();

        if(_valueToGetThreeStarPercent <= _valueToGetTwoStarPercent)
            _valueToGetThreeStarPercent = _valueToGetTwoStarPercent + 1;

        if(_valueToGetTwoStarPercent <= _valueToGetOneStarPercent)
            _valueToGetTwoStarPercent = _valueToGetOneStarPercent + 1;

        if(_valueToGetOneStarPercent <= 0)
            _valueToGetOneStarPercent = 1;
    }

    private void OnEnable()
    {
        _eventer.Won += OnWon;

        for(int i = 0; i < _starAnimators.Length; i++)
            _starAnimators[i].gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _eventer.Won -= OnWon;
    }

    private void OnWon()
    {
        CalculateCountDisplayStars();
        StartCoroutine(DisplayStars());        
    }

    private void CalculateCountDisplayStars()
    {
        if (_alliedCastleBreaker.PercentBreaked > _valueToGetThreeStarPercent)
            _displayStarsCount++;

        if (_alliedCastleBreaker.PercentBreaked > _valueToGetTwoStarPercent)
            _displayStarsCount++;

        if (_alliedCastleBreaker.PercentBreaked > _valueToGetOneStarPercent)
            _displayStarsCount++;
    }

    private IEnumerator DisplayStars()
    {
        for(int i = 0; i < _displayStarsCount; i++)
        {
            _starAnimators[i].gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
        }
    }
}
