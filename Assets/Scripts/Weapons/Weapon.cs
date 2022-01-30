using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected List<Bullet> Bullets;
    protected int CurrentBulletNumber = 0;

    public abstract void Shoot(Transform shootPoint);

    public void AddBullet(Bullet bullet)
    {
        Bullets.Add(bullet);
    }

    public void NextBullet()
    {
        if (CurrentBulletNumber == Bullets.Count - 1)
            CurrentBulletNumber = 0;
        else
            ++CurrentBulletNumber;
    }

    public void PrevBullet()
    {
        if (CurrentBulletNumber == 0)
            CurrentBulletNumber = Bullets.Count - 1;
        else
            --CurrentBulletNumber;
    }

    public void ChangeWeapon(int number)
    {
        CurrentBulletNumber = number;
    }
}
