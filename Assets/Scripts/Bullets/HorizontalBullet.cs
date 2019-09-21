using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBullet : Bullet
{
    void Update()
    {
        transform.position += new Vector3(Speed.x + 10f, Speed.y, 0) * Time.deltaTime;
    }
    
    public override void Init(float damage, Vector2 position, Vector2 speed)
    {
        speed = new Vector2(speed.x, 0);
        base.Init(damage, position, speed);
    }
    
}
