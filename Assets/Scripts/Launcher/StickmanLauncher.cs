using UnityEngine;

[RequireComponent(typeof(StickmanCharger))]
public class StickmanLauncher : DirectionFinder
{
    [SerializeField] private ElasticTensioner _elasticTensioner;
    [SerializeField] private float _launchPoint;
    [SerializeField] private IDoJob _charger;

    private StickmanFlightOperator _lastCharged;

    private void Awake()
    {
        _charger = GetComponent<IDoJob>();
    }

    private void OnEnable()
    {
        _elasticTensioner.DragFinished += OnDragFinished;
    }

    private void Start()
    {
        Charging(_charger.DoJob());
    }

    private void OnDisable()
    {
        _elasticTensioner.DragFinished -= OnDragFinished;
    }

    private void Charging(StickmanFlightOperator stickman)
    {
        if (stickman.TryGetComponent(out StickmanAppearer appear))
            appear.IsCharged = true;

        _lastCharged = stickman;
    }

    private void OnDragFinished()
    {
        if (TryLaunch())
            Charging(_charger.DoJob());

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
