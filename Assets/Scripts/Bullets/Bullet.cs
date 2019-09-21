using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float damage;
    
    protected Vector2 speed;

    protected Vector2 position;
    
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public Vector2 Speed
    {
        get => speed;
        set => speed = value;
    }

    public Vector2 Position
    {
        get => position;
        set => position = value;
    }
    
    public enum BulletTypes
    {
        Horizontal,
        Diagonal,
        Enemy
    }
    
    [SerializeField]
    BulletTypes type;


    public BulletTypes GetBulletType()
    { return type; }

    public virtual void Init(float damage, Vector2 position, Vector2 speed)
     {
        this.damage = damage;
        this.position = position; 
        this.speed = speed;
        UpdatePosition();
     }

     public virtual void UpdatePosition()
     {
         transform.position = new Vector3(position.x /* + 1.8f */, position.y, 0);
     }
     
     void OnBecameInvisible()
     { BulletFactory.Instance.Release(this); }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy"))
        {
            BulletFactory.Instance.Release(this);
            other.GetComponent<BaseAvatar>().TakeDamage(damage);
        }
    }
}


