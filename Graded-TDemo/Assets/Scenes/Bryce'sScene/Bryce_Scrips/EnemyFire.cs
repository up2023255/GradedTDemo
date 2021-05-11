using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

     float rateOfFire;
     float fireNext;

     void Start()
     {
        rateOfFire = 1f;
        fireNext = Time.time;
     }

    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > fireNext)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            fireNext = Time.time + rateOfFire;
        }
    }
}
