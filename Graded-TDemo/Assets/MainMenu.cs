using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelGenerate;
    public GameObject settingsPanel;

    List<string> scenes = new List<string>();
    public void StartGame()
    {
        //int rand = Random.Range(1, 6);
        //SceneManager.LoadScene(scenes[rand]);

        levelGenerate = Random.Range(1, 6);
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
