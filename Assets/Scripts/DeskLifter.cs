using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLifter : MonoBehaviour
{
    [SerializeField] private float _coroutineDelay;
    [SerializeField] private float _positionVerticalStayClosed;
    [SerializeField] private float _positionVerticalStayOpened;
    [SerializeField] private float _freezePositionTime;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isOpenedOnStart;

    private Vector3 _targetPosition;

    private void Awake()
    {
        if (_isOpenedOnStart == true)
            transform.position = GetTargetPosition(_positionVerticalStayOpened);
        else
            transform.position = GetTargetPosition(_positionVerticalStayClosed);


        StartCoroutine(OnMove());
    }

    private Vector3 GetTargetPosition(float positionVertical)
    {
        return new Vector3(transform.position.x, positionVertical, transform.position.z);
    }

    private void SetTargetPosition()
    {
        if (transform.position.y == _positionVerticalStayOpened)
            _targetPosition = GetTargetPosition(_positionVerticalStayClosed);
        else 
            _targetPosition = GetTargetPosition(_positionVerticalStayOpened);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private IEnumerator OnMove()
    {
        SetTargetPosition();

        while (true)
        {
            Move();

            if (transform.position == _targetPosition)
            {
                yield return new WaitForSeconds(_freezePositionTime);
                SetTargetPosition();
            }

            yield return new WaitForSeconds(_coroutineDelay);

        }
    }
}
