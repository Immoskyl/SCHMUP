using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    BaseAvatar avatar;

    [SerializeField]
    private Bullet.BulletTypes type;

    public Bullet.BulletTypes Type
    {
        get => type;
        set => type = value;
    }

    private void Start()
    {
        //changeBulletType(Bullet.BulletTypes.Diagonal); todo test later
        avatar = GetComponent<BaseAvatar>();
    }

    public void Fire()
    {
        if (! avatar.HasEnoughEnergyToShoot())
            return;

        Bullet bullet = BulletFactory.Instance.GetBullet(type);
        bullet.Init(1, transform.position, avatar.Engines.Speed);
        avatar.JustShot();
    }
}
