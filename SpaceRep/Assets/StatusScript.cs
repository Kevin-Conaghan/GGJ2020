using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public bool working = true;
    public bool invinsible = false;
    public Texture workingTexture;
    public Texture brokenTexture;
    public bool inRange = false;

    //Broken model and texture
    //Working model and texture
    // Start is called before the first frame update
    void Start()
    {
        working = true;
        invinsible = false;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;

    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        if (working && invinsible)
        {
            invinsible = false;
        }
        
    }
}
