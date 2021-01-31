using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Chest : MonoBehaviour
    {

    private GameObject chest;
    bool sanity = Player.getSanity();

        private void Update()
        {
            if (sanity == false)
            {
                this.chest.SetActive(false);
            }
        }
    }