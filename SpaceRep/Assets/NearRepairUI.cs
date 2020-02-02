using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearRepairUI : MonoBehaviour
{
    public float rndNumber = 0f;

    public GameObject[] breakables;
    private StatusScript localStatusScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdatObjectStatus();
    }

    private void UpdatObjectStatus()
    {
        for(int i = 0; i < breakables.Length; i++)
        {
            
            localStatusScript = breakables[i].GetComponent<StatusScript>();
            if (localStatusScript.working && !localStatusScript.invinsible)
            {
                rndNumber = generateRandomNumber();
                if (rndNumber > 995f)
                {
                    switch (breakables[i].name)
                    {
                        case "Generator":
                            breakables[i].GetComponent<StatusScript>().working = false;
                            breakables[i].GetComponent<MeshRenderer>().material.mainTexture = breakables[i].GetComponent<StatusScript>().brokenTexture;
                            break;

                    }
                    breakables[i].GetComponent<StatusScript>();
                }
                rndNumber = 0;
            }
        }
    }
    

    private float generateRandomNumber()
    {
        return Random.Range(0f, 1000f);
    }
}
