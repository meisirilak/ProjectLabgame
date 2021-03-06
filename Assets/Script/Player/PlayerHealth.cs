﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] enemyObject;
    EnemyHealth enemyHealth;
    public int MaxHealth = 100;

    public int MaxArmor = 100;
    public int CurrentHealth;
    public int CurrentArmor;

    public float TimeisAttack = 0.5f;
    public float CurrentTime;

    public bool isAttack = false;
    public HealthBar healthBar;
    public ArmorBar armorBar;

    public PlayerController playerController;

    private int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        CurrentArmor = MaxArmor;
        armorBar.SetMaxArmor(MaxArmor);

        CurrentTime = TimeisAttack;

        isAttack = true;
        
        currentScene = scene.buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime <= 0){
            CurrentTime = TimeisAttack;
            isAttack = true;
        }else
        CurrentTime -= Time.deltaTime;

        HpandArmorBar(CurrentArmor,CurrentHealth);

        Death(CurrentHealth);
        
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Enemy"){
            if(isAttack){
            other.gameObject.GetComponent<EnemyHealth>().Attack();
            isAttack = false;
            CurrentTime = TimeisAttack;
            }
        }        
    }

    //You can change How to TakeDamge here
    //May have to do in another script
    public void HpandArmorBar(int CurrentArmor,int CurrentHealth){

        healthBar.SetHealth(CurrentHealth);
        armorBar.SetArmor(CurrentArmor);
    }

    void Death(float health){
        if(health<= 0){
            playerController.enabled = false;
            SceneManager.LoadScene(currentScene);
        }
    }
    
}
