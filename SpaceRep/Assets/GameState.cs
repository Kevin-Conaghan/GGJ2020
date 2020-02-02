using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject blackimage;
    public float shipHealth = 1000;
    public bool playing = true;
    public GameObject[] repairables;
    public GameObject playerObject;
    public GameObject[] lights;
    public bool antiGravity = false;
    public int multiplier = 10;

    public Color workingColor;
    public Color brokenColor;
    public Color panicColor;

    public Slider health;


    // Start is called before the first frame update

    void Start()
    {
        antiGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(shipHealth == 0)
        {
            SceneManager.LoadScene("GameOver",LoadSceneMode.Single);
            //blackimage.SetActive(true);
        }
        
        health.value = (shipHealth / 1000.0f);


        for (int i = 0; i < repairables.Length; i++)
        {
            if (repairables[i].GetComponent<StatusScript>().working)
            {
                shipHealth += Time.deltaTime * multiplier;
            }
            else
            {
                shipHealth -= Time.deltaTime * multiplier;
            }
        }

        //Check if game is over
        if (shipHealth < 0 )
        {
            playing = false;
            shipHealth = 0;
        }
        else if (shipHealth > 1000)
        {
            shipHealth = 1000;
        }


        if(shipHealth < 500)
        {
            AlarmLights();
        }
        else
        {
            NormalLights();
        }

        CheckForGravity();
    }

    private void AlarmLights()
    {

        if (lights[0].GetComponent<Light>().color != panicColor)
        {
            for (int i = 0; i < lights.Length; i++)
            {

                lights[i].GetComponent<Light>().intensity = 0.7f;
                lights[i].GetComponent<Light>().range = 20.0f;
                lights[i].GetComponent<Light>().color = panicColor;

            }
        Debug.Log("Switching Lights to Alarm Lights");
        }

    }

    private void NormalLights()
    {

        if (lights[0].GetComponent<Light>().color != workingColor)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Light>().intensity = 0.7f;
                lights[i].GetComponent<Light>().range = 20.0f;
                lights[i].GetComponent<Light>().color = workingColor;
            }
        Debug.Log("Switching Lights to Normal Lights");
        }

    }

    private void CheckForGravity()
    {
        int rng = (int)Random.Range(0f, 1000f);

    }
}
