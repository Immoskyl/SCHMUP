using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet1 : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-3f, 0, 0) * Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BulletFactory.Instance.Release(this);
            other.GetComponent<BaseAvatar>().TakeDamage(damage);
        }
    }
}