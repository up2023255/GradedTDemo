using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Player : MonoBehaviour
    {

        public int maxHealth;
        public int currentHealth;
        public static bool sane;
        public StatsScreen statScreen;
    bool isDead;
    Player()
    {
        maxHealth = 100;
        sane = true;
    }

        void Start()
        {
            currentHealth = maxHealth;

            isDead = false;
        }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            sane = false;
            Debug.Log(sane);
        }
        if (Input.GetMouseButtonDown(2))
        {
            sane = true;
            Debug.Log(sane);
        }
    }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
            //sanityCheck();
        }

        void Die()
        {
            Debug.Log("Dead");
            Destroy(this.gameObject);
            isDead = true;
        //statScreen.Stats();
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
