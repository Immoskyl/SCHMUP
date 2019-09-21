using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAvatar : MonoBehaviour
{
    [SerializeField]
    protected float maxSpeed;
    public float MaxSpeed
    {
        get
        {
            return this.maxSpeed;
        }
        set
        {
            this.maxSpeed = value;
        }
    }

    [SerializeField]
    protected Engines engines;
    public Engines Engines 
    {
        get
        {
            return this.engines;
        }
        set
        {
            this.engines = value;
        }
    }

    [SerializeField]
    protected float health;
    
    public float Health
    {
        get => health;
        set => health = value;
    }

    [SerializeField]
    protected float maxHealth;

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public delegate void AvatarDeath(Vector3 pos);

    public static event AvatarDeath OnAvatarDeath;
    
    
    public virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
            Die();
        if (OnAvatarDeath != null)
            OnAvatarDeath(transform.position);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void Init(float startSpeed, Vector3 position, float startHealth = 0)
    {
        Engines = GetComponent<Engines>();
        maxSpeed = startSpeed;
        transform.position = position;
        if (startHealth > 0)  // if not told by Unity
        {
            maxHealth = startHealth;
            health = maxHealth; 
        }
    }

    public virtual bool HasEnoughEnergyToShoot()
    {
        return true;
    }

    public virtual void JustShot()
    {
        return;
    }

}
