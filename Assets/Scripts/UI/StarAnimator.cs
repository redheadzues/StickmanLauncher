using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StarAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string c_AppearStar = "AppearStar";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(c_AppearStar);
    }
}
