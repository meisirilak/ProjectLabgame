﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponObject : ScriptableObject{
    public string weaponName = "Weapon Name";
    public int cost = 0;
    public string description;
    public Sprite sprite;

    public float fireRate = .0f;
    public int damage = 0;
    public float range = 0;
    public int currentAmmo = 0;
    public int maxAmmo = 0;
    public float TimetoReload = 0;
    
}

