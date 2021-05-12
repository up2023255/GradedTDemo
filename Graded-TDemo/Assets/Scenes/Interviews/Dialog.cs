using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    private GameObject playerIcon;
    private GameObject enemyIcon;
    private GameObject playerBox;
    private GameObject enemyBox;

    void Start()
    {
        playerIcon = GameObject.Find("PlayerIcon");
        enemyIcon = GameObject.Find("EnemyIcon");
        playerBox = GameObject.Find("PlayerBox");
        enemyBox = GameObject.Find("EnemyBox");

        StartCoroutine(Type());
        enemyIcon.SetActive(false);
        enemyBox.SetActive(false);
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }

        if(playerIcon.activeSelf)
        {
            playerIcon.SetActive(false);
            enemyIcon.SetActive(true);
            playerBox.SetActive(false);
            enemyBox.SetActive(true);
        }
        else
        {
            playerIcon.SetActive(true);
            enemyIcon.SetActive(false);
            playerBox.SetActive(true);
            enemyBox.SetActive(false);
        }
    }
    
}
