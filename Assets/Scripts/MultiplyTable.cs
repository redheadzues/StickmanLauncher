using System;
using UnityEngine;

public class MultiplyTable : MonoBehaviour
{
    [SerializeField] private AlliedSpawner _spawner;
    [SerializeField] private ParticleSystem _particleSystem;

    private StickmanFlightOperator _lastDuplicate;
    private float _DuplicateOffsetX = 2.5f;
    private float _rightBoardX = 9.5f;

    public event Action Duplicated;

    private void OnValidate()
    {
        _spawner = FindObjectOfType<AlliedSpawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out StickmanFlightOperator flyOperator))
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
            if(stickman.gameObject.TryGetComponent(out StickmanFlightOperator flyOperator))
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
        if (point.x + _DuplicateOffsetX > _rightBoardX)
            return new Vector3(point.x - _DuplicateOffsetX, point.y, point.z);

        return new Vector3(point.x + _DuplicateOffsetX, point.y, point.z);
    }
}
