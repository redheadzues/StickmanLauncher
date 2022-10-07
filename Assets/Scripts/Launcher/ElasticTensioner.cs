using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ElasticTensioner : MonoBehaviour
{
    private float _reloadTime;

    private float _minPointX = -4;
    private float _maxPointX = 3;
    private float _minPointZ = -27;
    private float _maxPointZ = -20;

    private Rigidbody _rigidbody;
    private Vector3 _startDragPoint;
    private float _distance;
    private Vector3 _offset;
    private Vector3 _basePosition;
    private float _lastTimeShot;
    private StickmanLauncher _launcher;

    public event Action DragStarted;
    public event Action DragFinished;
    public event Action<float> ReloadStarted;
    public event Action LaunchFailed;


    private void OnValidate()
    {
        _launcher = FindObjectOfType<StickmanLauncher>();
    }

    private void OnEnable()
    {
        _launcher.Successfully += OnSuccessfully;
        _reloadTime = PlayerSkills.RealyMaxReload - PlayerSkills.Reload;
    }

    private void OnDisable()
    {
        _launcher.Successfully -= OnSuccessfully;
    }


    private void Start()
    {
        _lastTimeShot = -_reloadTime;
        _rigidbody = GetComponent<Rigidbody>();
        _basePosition = transform.position;
    }
    private void OnSuccessfully()
    {
        if(Time.timeSinceLevelLoad > 0)
        {
            _lastTimeShot = Time.time;
            ReloadStarted?.Invoke(_reloadTime);
        }
    }

    private void OnMouseDown()
    {
        _rigidbody.isKinematic = true;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _startDragPoint = GetRayPoint();
        DragStarted?.Invoke();
    }

    private void OnMouseDrag()
    {
        _offset = GetRayPoint() - _startDragPoint;
        transform.position = ClampPosition(_basePosition + _offset);
    }

    private Vector3 GetRayPoint()
    {
        _distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(_distance);

        return rayPoint;
    }

    private Vector3 ClampPosition(Vector3 point)
    {
        float pointX = Mathf.Clamp(point.x, _minPointX, _maxPointX);
        float pointZ = Mathf.Clamp(point.z, _minPointZ, _maxPointZ);

        return new Vector3(pointX, transform.position.y, pointZ);
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;

        if (Time.time > _lastTimeShot + _reloadTime)
            DragFinished?.Invoke();
        else
            LaunchFailed?.Invoke();
    }
}
