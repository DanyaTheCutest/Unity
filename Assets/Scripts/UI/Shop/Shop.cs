using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private Player _player;
    [SerializeField] private BulletView _template;
    [SerializeField] private Transform _container;

    private void Start()
    {
        for (int i = 0; i < _bullets.Count; i++)
            AddBullet(_bullets[i]);
    }
    private void AddBullet(Bullet bullet)
    {
        var template = Instantiate(_template, _container);
        template.SellButtonClick += OnSellButtonClick;
        template.Render(bullet);
    }

    private void OnSellButtonClick(Bullet bullet, BulletView bulletView)
    {
        TrySellWeapon(bullet, bulletView);
    }

    private void TrySellWeapon(Bullet bullet, BulletView bulletView)
    {
        if (_player.Money >= bullet.Price)
        {
            _player.BuyBullet(bullet);
            bullet.Buy();
            bulletView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
