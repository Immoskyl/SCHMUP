using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalBullet : Bullet
{
    private bool isShotInverted = false;
    public GameObject go;

    void Start()
    {
        if (isShotInverted)
            return;
        /* todo test later
        // todo help here
        GameObject bullet = Instantiate(go);
        DiagonalBullet diagonalBullet= bullet.GetComponent<DiagonalBullet>();
        float baseHorizontalSpeed = GetComponent<BaseAvatar>().Engines.Speed.x;
        diagonalBullet.Init(1, transform.position, new Vector2(baseHorizontalSpeed, 0));
        diagonalBullet.InvertShot(true);
        */
    }
    
    void Update()
    {
        transform.position += new Vector3(Speed.x + 10f, 
                                          isShotInverted ? - Speed.y : Speed.y, 
                                          0) * Time.deltaTime;
    }
    
    public void InvertShot (bool invert)
    {
        isShotInverted = invert;
    }
}
