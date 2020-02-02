using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class loadmaingame : MonoBehaviour
{
    private Scene currScene;
    private float timer;

    void Start()
    {
        currScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (currScene.name == "StartScene")
        {
            if (Input.anyKey)
            {
             SceneManager.GetActiveScene();
             SceneManager.LoadScene("Main",LoadSceneMode.Single);
            }
        }
        else if (currScene.name == "GameOver")
        {
            timer += Time.deltaTime;

            if (timer >= 5.0f)
            {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }

        }
        
    }
}
