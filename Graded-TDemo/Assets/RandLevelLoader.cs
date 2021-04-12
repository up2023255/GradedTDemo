using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandLevelLoader : MonoBehaviour
{
        public int levelGenerate;

    public void LoadTheLevel()
    {
        levelGenerate = Random.Range(1, 5);
        SceneManager.LoadScene(levelGenerate);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
