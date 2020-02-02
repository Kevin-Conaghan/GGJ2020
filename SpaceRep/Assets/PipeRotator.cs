using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotator : MonoBehaviour
{
    private MeshRenderer[] cubes;
    private int currentSelection;
    private int lastSelection;
    private int xRotation;
    // Start is called before the first frame update
    void Start()
    {
        cubes = new MeshRenderer[25];
        currentSelection = 12;
        cubes[0] = GameObject.Find("Pipe1").GetComponent<MeshRenderer>();
        cubes[1] = GameObject.Find("Pipe2").GetComponent<MeshRenderer>();
        cubes[2] = GameObject.Find("Pipe3").GetComponent<MeshRenderer>();
        cubes[3] = GameObject.Find("Pipe4").GetComponent<MeshRenderer>();
        cubes[4] = GameObject.Find("Pipe5").GetComponent<MeshRenderer>();
        cubes[5] = GameObject.Find("Pipe6").GetComponent<MeshRenderer>();
        cubes[6] = GameObject.Find("Pipe7").GetComponent<MeshRenderer>();
        cubes[7] = GameObject.Find("Pipe8").GetComponent<MeshRenderer>();
        cubes[8] = GameObject.Find("Pipe9").GetComponent<MeshRenderer>();
        cubes[9] = GameObject.Find("Pipe10").GetComponent<MeshRenderer>();
        cubes[10] = GameObject.Find("Pipe11").GetComponent<MeshRenderer>();
        cubes[11] = GameObject.Find("Pipe12").GetComponent<MeshRenderer>();
        cubes[12] = GameObject.Find("Pipe13").GetComponent<MeshRenderer>();
        cubes[13] = GameObject.Find("Pipe14").GetComponent<MeshRenderer>();
        cubes[14] = GameObject.Find("Pipe15").GetComponent<MeshRenderer>();
        cubes[15] = GameObject.Find("Pipe16").GetComponent<MeshRenderer>();
        cubes[16] = GameObject.Find("Pipe17").GetComponent<MeshRenderer>();
        cubes[17] = GameObject.Find("Pipe18").GetComponent<MeshRenderer>();
        cubes[18] = GameObject.Find("Pipe19").GetComponent<MeshRenderer>();
        cubes[19] = GameObject.Find("Pipe20").GetComponent<MeshRenderer>();
        cubes[20] = GameObject.Find("Pipe21").GetComponent<MeshRenderer>();
        cubes[21] = GameObject.Find("Pipe22").GetComponent<MeshRenderer>();
        cubes[22] = GameObject.Find("Pipe23").GetComponent<MeshRenderer>();
        cubes[23] = GameObject.Find("Pipe24").GetComponent<MeshRenderer>();
        cubes[24] = GameObject.Find("Pipe25").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSelection >= 0 && currentSelection < 25)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentSelection += 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentSelection -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentSelection += 5;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentSelection -= 5;
            }
            if (currentSelection < 0)
            {
                currentSelection = 0;
            }
            else if (currentSelection > 24)
            {
                currentSelection = 24;
            }
            if (lastSelection != null)
            {
                cubes[lastSelection].material.color = new Color(255.0f, 255.0f, 255.0f, 1.0f);
            }
            cubes[currentSelection].material.color = new Color(255.0f, 0.0f, 0.0f, 0.5f);
            lastSelection = currentSelection;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            xRotation = (int)(cubes[currentSelection].transform.localRotation.x + 90.0f);
            cubes[currentSelection].transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            // PipeLogic();
        }
    }

    //private void PipeLogic()
    //{
    //    switch (currentSelection)
    //    {
    //        case 5:

    //            break;
    //    }
    //}
}
