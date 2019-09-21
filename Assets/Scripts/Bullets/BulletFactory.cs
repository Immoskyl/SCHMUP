using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    Bullet enemyBulletPrefab;

    [SerializeField]
    Bullet playerBulletPrefab;

    private readonly Queue<Bullet> playerBulletCache = new Queue<Bullet>();
    private readonly Queue<Bullet> enemyBulletCache = new Queue<Bullet>();

    public Bullet GetBullet(Bullet.BulletTypes type)
    {
        Bullet b;
        switch (type)
        {
            case Bullet.BulletTypes.Enemy:
                if (enemyBulletCache.Count == 0)
                    b = Instantiate(enemyBulletPrefab);
                else
                    b = enemyBulletCache.Dequeue();
                break;
            
            case Bullet.BulletTypes.Diagonal:
                if (playerBulletCache.Count == 0)
                    b = Instantiate(playerBulletPrefab); //todo diagonal shot not implemented yet
                else
                    b = playerBulletCache.Dequeue();
                break;
            
            case Bullet.BulletTypes.Horizontal:
            default:
                if (playerBulletCache.Count == 0)
                    b = Instantiate(playerBulletPrefab); //todo diagonal shot not implemented yet
                else
                    b = playerBulletCache.Dequeue();
                break;
        }
        b.gameObject.SetActive(true);
        return b;
    }

    private void Start()
    {
        for (int i = 0; i != 100; i++) //cache 100 bullets of each type at first
        {
            Bullet enemyBullet = Instantiate(enemyBulletPrefab);
            enemyBullet.gameObject.SetActive(false);

            enemyBulletCache.Enqueue(enemyBullet);
            
            Bullet playerBullet = Instantiate(playerBulletPrefab);
            playerBullet.gameObject.SetActive(false);

            playerBulletCache.Enqueue(playerBullet);
        }
    }

    public void Release(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);

        if (bullet.GetBulletType() == Bullet.BulletTypes.Enemy)
        {
            enemyBulletCache.Enqueue(bullet);
        } else
        {
            playerBulletCache.Enqueue(bullet);
        }
    }

    public static BulletFactory Instance
    {
        get;
        private set;
    }

    private void Awake()
    { Instance = this; }
}
