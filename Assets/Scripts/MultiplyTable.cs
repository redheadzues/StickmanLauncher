using UnityEngine;

public class MultiplyTable : MonoBehaviour
{
    [SerializeField] private AlliedSpawner _spawner;
    [SerializeField] private float _DuplicateOffsetX;
    [SerializeField] private ParticleSystem _particleSystem;

    private StickmanFlightOperator _lastDuplicate;

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
            }                
    }

    private void MultyplierStickman(Vector3 direction, Vector3 point)
    {
        StickmanFlightOperator stickman = _spawner.DoJob();

        if(stickman != null)
        {
            stickman.transform.position = DefineDuplicatePosition(point);
            stickman.transform.SetParent(null);
            stickman.StartFlying(direction);
            _lastDuplicate = stickman;
        }
    }

    private Vector3 DefineDuplicatePosition(Vector3 point)
    {
        return new Vector3(point.x + _DuplicateOffsetX, point.y, point.z);
    }
}
