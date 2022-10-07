using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StickmanCharger))]
public class StickmanLauncher : DirectionFinder
{
    [SerializeField] private ElasticTensioner _elasticTensioner;
    [SerializeField] private float _launchPoint;
    [SerializeField] private Collider _notLaunchZone;
    

    private StickmanFlightOperator _lastCharged;
    private StickmanCharger _charger;
    private bool _isLauchEnable = false;

    public event UnityAction Successfully;

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
        if (TryLaunch() == true)
            Successfully?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _notLaunchZone)
            _isLauchEnable = false;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _notLaunchZone)
            _isLauchEnable = true;
    }

    private bool TryLaunch()
    {
       if(_isLauchEnable == true)
       {
            _lastCharged.transform.SetParent(null);
            var direction = GetNormalizedVector();
            _lastCharged.StartFlying(direction);
       }

        return _isLauchEnable;
    }
}
