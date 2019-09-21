using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar
{
    [SerializeField]
    private EnemyTypes type;
    
    public EnemyTypes GetEnemyType()
    { return type; }
    
    // Start is called before the first frame update
    void Start()
    {
        Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 cameraPos = maincam.transform.position;
        Vector3 enemyPosition = cameraPos + new Vector3(10f, Random.Range(5f, -5f), - cameraPos.z);
        Init(2, enemyPosition);
    }

    public enum EnemyTypes
    {
        Simple
    }

    public override void Die()
    {
        EnemyFactory.Instance.Release(this);
    }
}
