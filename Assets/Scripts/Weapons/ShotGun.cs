using UnityEngine;

public class ShotGun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullets[CurrentBulletNumber], shootPoint.position, Quaternion.identity);
    }
}
