using UnityEngine; 

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private string _animationAttackName;
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;

    private float _lastAttackTime;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(_animationAttackName);
        Target.ApplyDamage(_damage);
    }
}
