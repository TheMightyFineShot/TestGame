﻿using UnityEngine.Networking;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SyncVar]
    private int currentHealth;


    private void Awake()
    {
        SetDefaults();
    }

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        Debug.Log(transform.name + " now has " + currentHealth + " health.");
             
    }

}
