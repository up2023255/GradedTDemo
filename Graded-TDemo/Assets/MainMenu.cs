using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelGenerate;
    public GameObject settingsPanel;
    public void StartGame()
    {
        levelGenerate = Random.Range(2, 6);
        SceneManager.LoadScene(levelGenerate);
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Return()
    {
        settingsPanel.SetActive(false);
    }
}
