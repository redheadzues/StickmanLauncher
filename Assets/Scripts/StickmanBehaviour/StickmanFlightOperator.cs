using System.Collections;
using UnityEngine;

public class StickmanFlightOperator : StickmanAnimator
{
    [SerializeField] private float _coroutineDelay;
    [SerializeField] private SpawnerDeathParticle _deathParticle;
    
    private float _speed;
    private float _rotationSpeed = 10;
    private Coroutine _coroutine;
    private float _positionY = 1.5f;
    public Vector3 Direction { get; private set; }

    private void OnEnable()
    {
        _deathParticle = FindObjectOfType<SpawnerDeathParticle>();
        _speed = PlayerSkills.Speed;
    }

    public void StartFlying(Vector3 direction)
    {
        SetDirection(direction);

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnFlying(direction));
    }

    public void Die(Vector3 point)
    {
        if(_deathParticle != null)
            _deathParticle.SetParticle(point);

        gameObject.SetActive(false);
    }

    private void SetDirection(Vector3 direction)
    {
        Direction = direction; 
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void Fly(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
        transform.position = ClampPositionY(transform.position);
    }

    private void RotateOnDirection(Vector3 direction)
    {
        //Quaternion lookDirection = Quaternion.LookRotation(Vector3.down, direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, _rotationSpeed *  Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.down, direction);
    }

    private void PrepareForFlight(Vector3 direction)
    {
        PlayFly();
        RotateOnDirection(direction);
    }

    private Vector3 ClampPositionY(Vector3 position)
    {
        return new Vector3(position.x, _positionY, position.z);
    }

    private IEnumerator OnFlying(Vector3 direction)
    {
        var waitingTime = new WaitForSeconds(_coroutineDelay);

        PrepareForFlight(direction);

        while (gameObject.activeSelf == true)
        {
            Fly(direction);
            yield return waitingTime;
        }
    }
}
