using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UICastleDamage : MonoBehaviour
{
    [SerializeField] private TMP_Text _textDamage;
    [SerializeField] private float _flySpeed;
    [SerializeField] private float _resizeSpeed;

    private Rigidbody _rigidbody;

    public void Initialize(float damage)
    {
        _textDamage.text += damage.ToString();
    }

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.up * 12, ForceMode.Impulse);    
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
