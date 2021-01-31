using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Chest : MonoBehaviour
    {

    bool sanity;

    void Start()
    {
        GameObject player = GameObject.Find("Player") as GameObject;
        player.GetComponent <Player>();
    }

        private void Update()
        {
        sanity = Player.sane;
            if (sanity == false)
            {
                this.gameObject.SetActive(true);
            }
        else
        {
            this.gameObject.SetActive(false);
        }
        }
    }