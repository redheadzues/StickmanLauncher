using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public event Action Bounced;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out StickmanFlightOperator flyOperator))
            Bounced?.Invoke();  

    }
}
