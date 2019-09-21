using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public EnemyAvatar enemy;
    public PlayerAvatar player;


    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += Random.Range(1f, 3f);
            CreateSimpleEnemy();
        }
    }

    void CreateSimpleEnemy()
    {
        EnemyFactory.Instance.GetEnemy(EnemyAvatar.EnemyTypes.Simple);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(this.player);
    }
}