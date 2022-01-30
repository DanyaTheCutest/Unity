using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPos;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }
    public bool IsAlive { get; private set; } = true;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction Shooting;
    public event UnityAction Died;

    private void Start()
    {
        _currentWeapon = _weapons[_currentWeaponNumber];
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAlive && Input.GetMouseButtonDown(0))
        {
            Shooting?.Invoke();
            _currentWeapon.Shoot(_shootPos);
            _animator.Play("Shoot");
        }
    }

    public void ApplyDamage(int damage)
    {
        if (IsAlive)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
            {
                IsAlive = false;
                _animator.Play("Death");
                Died?.Invoke();
            }
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyBullet(Bullet _bullet)
    {
        Money -= _bullet.Price;
        _weapons[_currentWeaponNumber].AddBullet(_bullet);
        _weapons[_currentWeaponNumber].NextBullet();
    }
}
