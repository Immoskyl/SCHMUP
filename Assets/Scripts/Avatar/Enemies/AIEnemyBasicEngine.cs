using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{

    private EnemyAvatar enemy;
    void Start()
    {
        enemy = GetComponent<EnemyAvatar>();
        InvokeRepeating(nameof(FireAtRandomTimes), 1f, 2f);

    }

    void Update()
    {
        enemy.Engines.Speed = new Vector2(-0.5f, 0);
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void FireAtRandomTimes()
    {
        enemy.GetComponent<BulletGun>().Fire();
    }
}
