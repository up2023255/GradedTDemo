using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodDonated : MonoBehaviour
{
    public Text bloodText;
    Player bloodDonate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bloodText.text = "Blood Donated:" + bloodDonate.maxHealth;
    }
}
