using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(StickmanCharger))]
public class StickmanLauncher : DirectionFinder
{
    [SerializeField] private ElasticTensioner _elasticTensioner;
    [SerializeField] private float _launchPoint;

    private StickmanFlightOperator _lastCharged;
    private StickmanCharger _charger;

    public event Action Successfully;

    private void Awake()
    {
        _charger = GetComponent<StickmanCharger>();
    }

    private void OnEnable()
    {
        _elasticTensioner.DragFinished += OnDragFinished;
        _charger.Charged += OnCharged;
    }

    private void Start()
    {

        Successfully?.Invoke();
    }


    private void OnDisable()
    {
        _elasticTensioner.DragFinished -= OnDragFinished;
        _charger.Charged -= OnCharged;
    }

    private void OnCharged(GameObject stickman)
    {
        if(stickman.TryGetComponent(out StickmanFlightOperator flyOperator))
            _lastCharged = flyOperator;

        if (stickman.TryGetComponent(out StickmanAppearer appear))
            appear.IsCharged = true;

    }

    private void OnDragFinished()
    {
        if (TryLaunch())
            Successfully?.Invoke();
    }

    private bool TryLaunch()
    {
       if(transform.position.z < _launchPoint)
       {
            _lastCharged.transform.SetParent(null);
            var direction = GetNormalizedVector();
            _lastCharged.StartFlying(direction);
       }

        return transform.position.z < _launchPoint;
    }
}
