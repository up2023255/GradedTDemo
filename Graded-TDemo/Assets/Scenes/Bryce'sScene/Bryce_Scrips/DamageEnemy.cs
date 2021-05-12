using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour
{
    public float health;
    public float maxHealth;

    //Healthbar
    public GameObject healthBar;
    public Slider healthBarSlider;

    void Start()
    {
        health = maxHealth;
        healthBarSlider.value = health;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealth();
    }

    public void HealCharacter (float heal)
    {
        health += heal;
        CheckOverheal();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private float CalculateHealth()
    {
        return (health / maxHealth);
    }
}
