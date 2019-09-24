using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    
    [SerializeField]
    private Slider energySlider;

    private GameController gameController;
    private void OnEnable()
    {
        BaseAvatar.OnAvatarDeath += AvatarDies;
    }

    private void OnDisable()
    {
        BaseAvatar.OnAvatarDeath -= AvatarDies;
    }
    void Start()
    {
        gameController = GetComponent<GameController>();
        healthSlider.maxValue = gameController.player.MaxHealth;
        energySlider.maxValue = gameController.player.MaxEnergy;
    }

    void Update()
    {
        healthSlider.value = gameController.player.Health;
        energySlider.value = gameController.player.Energy;
    }

    void AvatarDies(Vector3 pos)
    {    
        gameController.player.Health += 1;
        gameController.player.Energy += 1;
    }

}    
