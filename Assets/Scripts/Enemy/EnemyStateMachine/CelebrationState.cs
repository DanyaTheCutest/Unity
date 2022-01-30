using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    [SerializeField] private string _animationCelebrationName;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_animationCelebrationName);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

}
