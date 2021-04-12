using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevelLoader : MonoBehaviour
{
    public int levelGenerate;

    public void LoadTheLevel()
    {
        levelGenerate = Random.Range(1, 5);
        SceneManager.LoadScene(levelGenerate);
    }
}
