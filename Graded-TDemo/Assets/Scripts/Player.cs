using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public bool sanity = true;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 25)
        {
            sanity = false;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() {
        Debug.Log("Dead");
    }
}