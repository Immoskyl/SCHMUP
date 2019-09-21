using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    EnemyAvatar enemyPrefab;

    private readonly Queue<EnemyAvatar> enemyCache = new Queue<EnemyAvatar>();

    public EnemyAvatar GetEnemy(EnemyAvatar.EnemyTypes type)
    {
        EnemyAvatar b;
        switch (type)
        {
            case EnemyAvatar.EnemyTypes.Simple: 
            default:
                if (enemyCache.Count == 0)
                    b = Instantiate(enemyPrefab);
                else
                    b = enemyCache.Dequeue();
                break;
        }
        b.gameObject.SetActive(true);
        return b;
    }

    private void Start()
    {
        for (int i = 0; i != 20; i++) //cache 20 enemies at first
        {
            EnemyAvatar enemy = Instantiate(enemyPrefab);
            enemy.gameObject.SetActive(false);

            enemyCache.Enqueue(enemy);
        }
    }

    public void Release(EnemyAvatar enemy)
    {
        enemy.gameObject.SetActive(false);

        if (enemy.GetEnemyType() == EnemyAvatar.EnemyTypes.Simple)
        {
            enemyCache.Enqueue(enemy);
        } //only one enemy type implemented yet
    }

    public static EnemyFactory Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }
}
