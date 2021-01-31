﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Player : MonoBehaviour
    {

    public int maxHealth;
    public int currentHealth;
    public static bool sane;
    Player()
    {
        maxHealth = 100;
        sane = true;
    }

        void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Debug.Log("Dead");
        }

        public bool sanityCheck()
    {
        while (currentHealth <= 25)
        {
            sane = false;
        }
        return sane;
    }

    public static bool getSanity()
        {
            return sane;
        }
    }