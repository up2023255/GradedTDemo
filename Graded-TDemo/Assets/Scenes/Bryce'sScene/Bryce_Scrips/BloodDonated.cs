using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodDonated : MonoBehaviour
{
    int Blood;
    public Text bloodText;
    // Player player;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Accesses the player script and links the health variable.
        Blood = player.GetComponent<Player>().maxHealth;

        //Takes the saved data and displayes it on the screen for the player.
        bloodText.text = PlayerPrefs.GetInt("Blood Donated").ToString() + Blood;
        //bloodText.text = "Blood Donated: ";
    }

    // Update is called once per frame
    void Update()
    {
        //Takes the players current health/blood and stores it on the system to allow it to remain over many runs.
        PlayerPrefs.SetInt("Blood Donated", Blood);

    }
}
