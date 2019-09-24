using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : BaseAvatar
{
    [SerializeField]
    private int energy;
    
    public int Energy
    {
        get => energy;
        set => energy = value < maxEnergy ?  value : maxEnergy;
    }
    
    [SerializeField]
    private int maxEnergy;

    public int MaxEnergy
    {
        get => maxEnergy;
        set => maxEnergy = value;
    }


    void Start()
    {
        Init(10, new Vector3(-8, 0, 0));
        InvokeRepeating(nameof(recoverEnergy), 0, 2f);
    }

    public override bool HasEnoughEnergyToShoot()
    {
        return energy > 0;
    }

    public override void JustShot()
    {
        energy--;
    }

    private void recoverEnergy()
    {
        if (energy < maxEnergy)
            energy++;
    }

    public override void Die()
    {
        //base.Die();
        Application.Quit();
    }
}
