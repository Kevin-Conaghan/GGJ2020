using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameState : MonoBehaviour
{
    public int shipHealth = 1000;
    public bool playing = true;
    public GameObject[] repairables;
    public GameObject playerObject;
    public GameObject[] lights;
    public bool antiGravity = false;

    public Color workingColor;
    public Color brokenColor;
    public Color panicColor;



    // Start is called before the first frame update

    void Start()
        {
        antiGravity = false;
           //for(int i = 0; i < this.transform.childCount; i++)
           // {
           //     if(this.transform.GetChild(i).tag == "BrokenObject")
           //     {
           //         repairables[i] = this.transform.GetChild(i).gameObject;
           //     }
           // }
    }

    // Update is called once per frame
    void Update()
    {

     
        for (int i = 0; i < repairables.Length; i++)
        {
            if (repairables[i].GetComponent<StatusScript>().working)
            {
                shipHealth++;
            }
            else
            {
                shipHealth--;
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
