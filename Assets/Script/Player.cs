﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(10);
        }
    }

    //You can change How to TakeDamge here
    //May have to do in another script
    public void TakeDamage(int Damage){
        CurrentHealth -= Damage;

        healthBar.SetHealth(CurrentHealth);
    }
}
