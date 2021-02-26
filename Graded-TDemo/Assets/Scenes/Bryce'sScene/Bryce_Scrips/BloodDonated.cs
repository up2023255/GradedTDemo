using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodDonated : MonoBehaviour
{
    int Blood;
    int Saved;
    public Text bloodText;
    // Player player;
    public GameObject player;


    //Primitive vertion
    int Runtotal;
    int OverallTotal;
    Player player1;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);

        bloodText.text = "Blood donated: " + OverallTotal.ToString();


        //Accesses the player script and links the health variable.
        Blood = player.GetComponent<Player>().currentHealth;



        //Takes the saved data and displayes it on the screen for the player.
        //bloodText.text = "Blood donated: " + Blood + Saved.ToString();

        Saved = PlayerPrefs.GetInt("Blood Donated");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    gameObject.SetActive(true);
        //}

        // Saves the total form all runs and adds each run total.
        OverallTotal = Runtotal += Saved;

        // Constantly checks the players health and sets its current helth as the run total.
        Runtotal = player1.currentHealth;


        //Takes the players current health/blood and stores it on the system to allow it to remain over many runs.
        PlayerPrefs.SetInt("Blood Donated", Saved);

    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Blood Donatoion");
        bloodText.text = "Blood donated: 0";
    }
}
