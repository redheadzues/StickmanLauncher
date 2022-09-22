using UnityEngine;

[RequireComponent(typeof(StickmanLauncher))]
public class StickmanCharger : MonoBehaviour, IDoJob
{    
    [SerializeField] private AlliedSpawner _spawner;
    [SerializeField] private Vector3 _localPointToSetPosition;

    private StickmanFlightOperator _lastSpawned;
    private StickmanFlightOperator _waitingForCharge;
    private Transform _launcher;

    private void Awake()
    {
        _launcher = GetComponent<StickmanLauncher>().transform;
        _lastSpawned = _spawner.DoJob();
    }

    public StickmanFlightOperator DoJob()
    {
        _waitingForCharge = _lastSpawned;

        _waitingForCharge.transform.SetParent(_launcher);
        _waitingForCharge.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _waitingForCharge.transform.localPosition = _localPointToSetPosition;

        _lastSpawned = _spawner.DoJob();

        return _waitingForCharge;
    }
}
