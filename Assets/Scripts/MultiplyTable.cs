using System;
using UnityEngine;

public class MultiplyTable : MonoBehaviour
{
    [SerializeField] private AlliedSpawner _spawner;
    [SerializeField] private float _DuplicateOffsetX;
    [SerializeField] private ParticleSystem _particleSystem;

    private StickmanFlightOperator _lastDuplicate;

    public event Action Duplicated;

    private void OnValidate()
    {
        _spawner = FindObjectOfType<AlliedSpawner>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<StickmanFlightOperator>(out StickmanFlightOperator flyOperator))
            if (flyOperator != _lastDuplicate)
            {
                Vector3 collisionPoint = collision.contacts[0].point;
                MultyplierStickman(flyOperator.Direction, collisionPoint);
                _particleSystem.transform.position = collisionPoint;
                _particleSystem.Play();
                Duplicated?.Invoke();
            }                
    }

    private void MultyplierStickman(Vector3 direction, Vector3 point)
    {
        GameObject stickman = _spawner.GetTemplate();

        if(stickman != null)
        {
            if(stickman.gameObject.TryGetComponent<StickmanFlightOperator>(out StickmanFlightOperator flyOperator))
            {
                flyOperator.gameObject.SetActive(true);
                flyOperator.transform.position = DefineDuplicatePosition(point);
                flyOperator.transform.SetParent(null);
                flyOperator.StartFlying(direction);
                _lastDuplicate = flyOperator;
            }
        }
    }

    private Vector3 DefineDuplicatePosition(Vector3 point)
    {
        return new Vector3(point.x + _DuplicateOffsetX, point.y, point.z);
    }
}
