using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatConcept : MonoBehaviour {

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

        void Attack(){
            anim.SetTrigger("Attack");
        }
}