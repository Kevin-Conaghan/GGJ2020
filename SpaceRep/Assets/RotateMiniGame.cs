using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class RotateMiniGame : MonoBehaviour
{
    private RawImage[] cubes; 
    private int currentSelection;
    private int lastSelection;
    private float zRotation;
    public Material correctStraightMat;
    public Material straightMat;
    public Material correctCornerMat;
    public Material cornerMat;
    private float[] rndNumber = { 0.0f, 90.0f, 180.0f, 270.0f};
    public bool solved = false;
    public int currentPuzzle;
    public GameObject fuseWrapperObject;
    public GameObject playerMovementObject;

    // Start is called before the first frame update
    void Start()
    {
        // Status script for checking if the generator is broken
        fuseWrapperObject.GetComponentInChildren<Light>().color = fuseWrapperObject.GetComponentInParent<GameState>().workingColor;
        playerMovementObject = GameObject.FindGameObjectWithTag("Player");

        //Degrees
        rndNumber = new float[4];
        rndNumber[0] = 0.0f;
        rndNumber[1] = 90.0f;
        rndNumber[2] = 180.0f;
        rndNumber[3] = 270.0f;

        cubes = new RawImage[25];
        currentSelection = 12;
        cubes[0] = GameObject.Find("Pipe1").GetComponent<RawImage>();
        cubes[1] = GameObject.Find("Pipe2").GetComponent<RawImage>();
        cubes[2] = GameObject.Find("Pipe3").GetComponent<RawImage>();
        cubes[3] = GameObject.Find("Pipe4").GetComponent<RawImage>();
        cubes[4] = GameObject.Find("Pipe5").GetComponent<RawImage>();
        cubes[5] = GameObject.Find("Pipe6").GetComponent<RawImage>();
        cubes[6] = GameObject.Find("Pipe7").GetComponent<RawImage>();
        cubes[7] = GameObject.Find("Pipe8").GetComponent<RawImage>();
        cubes[8] = GameObject.Find("Pipe9").GetComponent<RawImage>();
        cubes[9] = GameObject.Find("Pipe10").GetComponent<RawImage>();
        cubes[10] = GameObject.Find("Pipe11").GetComponent<RawImage>();
        cubes[11] = GameObject.Find("Pipe12").GetComponent<RawImage>();
        cubes[12] = GameObject.Find("Pipe13").GetComponent<RawImage>();
        cubes[13] = GameObject.Find("Pipe14").GetComponent<RawImage>();
        cubes[14] = GameObject.Find("Pipe15").GetComponent<RawImage>();
        cubes[15] = GameObject.Find("Pipe16").GetComponent<RawImage>();
        cubes[16] = GameObject.Find("Pipe17").GetComponent<RawImage>();
        cubes[17] = GameObject.Find("Pipe18").GetComponent<RawImage>();
        cubes[18] = GameObject.Find("Pipe19").GetComponent<RawImage>();
        cubes[19] = GameObject.Find("Pipe20").GetComponent<RawImage>();
        cubes[20] = GameObject.Find("Pipe21").GetComponent<RawImage>();
        cubes[21] = GameObject.Find("Pipe22").GetComponent<RawImage>();
        cubes[22] = GameObject.Find("Pipe23").GetComponent<RawImage>();
        cubes[23] = GameObject.Find("Pipe24").GetComponent<RawImage>();
        cubes[24] = GameObject.Find("Pipe25").GetComponent<RawImage>();

        PipeLogic2();
    }

    // Update is called once per frame
    void Update()
    {
        MovementSelectionLogic();
        playerMovementObject.GetComponent<FirstPersonController>().m_MoveDir = new Vector3(0.0f, 0.0f, 0.0f);


        if (Input.GetKeyDown(KeyCode.E))
        {
            zRotation += 90; //(int)((cubes[currentSelection].transform.localRotation.x * Mathf.Rad2Deg) + 90.0f);
            cubes[currentSelection].transform.localRotation = Quaternion.Euler(0.0f, 90.0f, zRotation);
            Debug.Log(cubes[currentSelection].transform.localEulerAngles.z);

            if(currentPuzzle ==0)
            {
                PipeLogic2();
            }
            else if(currentPuzzle == 1)
            {
                PipeLogic2();
            }
        }
    }

    public void StartPuzzle(int puzzleNumber)
    {
        Debug.Log("Starting Puzzle"); 
        RandomiseRotations();
        currentPuzzle = puzzleNumber;
    }

    private void MovementSelectionLogic()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentSelection += 1;
            ChangeLast();
            ChangeCurrent();
            lastSelection = currentSelection;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentSelection -= 1;
            ChangeLast();
            ChangeCurrent();
            lastSelection = currentSelection;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentSelection += 5;
            ChangeLast();
            ChangeCurrent();
            lastSelection = currentSelection;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentSelection -= 5;
            ChangeLast();
            ChangeCurrent();
            lastSelection = currentSelection;
        }
        if (currentSelection <= 0)
        {
            currentSelection = 0;
        }
        else if (currentSelection >= 24)
        {
            currentSelection = 24;
        }

        //Debug.Log(currentSelection);
        
    }
    private void ChangeLast()
    {
        cubes[lastSelection].color = Color.white;
    }

    private void ChangeCurrent()
    {
        cubes[currentSelection].color = Color.red;
    }

    private void PipeLogic1()
    {
        if (cubes[2].transform.localEulerAngles.z > -1.0f && cubes[2].transform.localEulerAngles.z < 1.0f)
        {
            cubes[2].material = correctCornerMat;
        }
        else
        {
            cubes[2].material = cornerMat;
        }
        if (cubes[3].transform.localEulerAngles.z < 271.0f && cubes[3].transform.localEulerAngles.z > 269.0f)
        {
            cubes[3].material = correctCornerMat;
        }
        else
        {
            cubes[3].material = cornerMat;
        }
        if (cubes[4].transform.localEulerAngles.z > -1.0f && cubes[4].transform.localEulerAngles.z < 1.0f)
        {
            cubes[4].material = correctCornerMat;
        }
        else
        {
            cubes[4].material = cornerMat;
        }
        if (cubes[7].transform.localEulerAngles.z > 89.0f && cubes[7].transform.localEulerAngles.z < 91.0f || cubes[7].transform.localEulerAngles.z > 269 && cubes[7].transform.localEulerAngles.z < 271.0f)
        {
            cubes[7].material = correctStraightMat;
        }
        else
        {
            cubes[7].material = straightMat;
        }
        if (cubes[8].transform.localEulerAngles.z > 89.0f && cubes[8].transform.localEulerAngles.z < 91.0f || cubes[8].transform.localEulerAngles.z > 269 && cubes[8].transform.localEulerAngles.z < 271.0f)
        {
            cubes[8].material = correctStraightMat;
        }
        else
        {
            cubes[8].material = straightMat;
        }
        if (cubes[9].transform.localEulerAngles.z > 89.0f && cubes[9].transform.localEulerAngles.z < 91.0f || cubes[9].transform.localEulerAngles.z > 269 && cubes[9].transform.localEulerAngles.z < 271.0f)
        {
            cubes[9].material = correctStraightMat;
        }
        else
        {
            cubes[9].material = straightMat;
        }
        if (cubes[12].transform.localEulerAngles.z > 89.0f && cubes[12].transform.localEulerAngles.z < 91.0f || cubes[12].transform.localEulerAngles.z > 269 && cubes[12].transform.localEulerAngles.z < 271.0f)
        {
            cubes[12].material = correctStraightMat;
        }
        else
        {
            cubes[12].material = straightMat;
        }
        if (cubes[13].transform.localEulerAngles.z > 89.0f && cubes[13].transform.localEulerAngles.z < 91.0f)
        {
            cubes[13].material = correctCornerMat;
        }
        else
        {
            cubes[13].material = cornerMat;
        }
        if (cubes[14].transform.localEulerAngles.z > 179.0f && cubes[14].transform.localEulerAngles.z < 181.0f)
        {
            cubes[14].material = correctCornerMat;
        }
        else
        {
            cubes[14].material = cornerMat;
        }
        if (cubes[15].transform.localEulerAngles.z > -1.0f && cubes[15].transform.localEulerAngles.z < 1.0f)
        {
            cubes[15].material = correctCornerMat;
        }
        else
        {
            cubes[15].material = cornerMat;
        }
        if (cubes[16].transform.localEulerAngles.z < 271.0f && cubes[16].transform.localEulerAngles.z > 269.0f)
        {
            cubes[16].material = correctCornerMat;
        }
        else
        {
            cubes[16].material = cornerMat;
        }
        if (cubes[17].transform.localEulerAngles.z > 89.0f && cubes[17].transform.localEulerAngles.z < 91.0f)
        {
            cubes[17].material = correctCornerMat;
        }
        else
        {
            cubes[17].material = cornerMat;
        }
        if (cubes[18].transform.localEulerAngles.z < 271.0f && cubes[18].transform.localEulerAngles.z > 269.0f)
        {
            cubes[18].material = correctCornerMat;
        }
        else
        {
            cubes[18].material = cornerMat;
        }
        if (cubes[20].transform.localEulerAngles.z > 179.0f && cubes[20].transform.localEulerAngles.z < 181.0f)
        {
            cubes[20].material = correctCornerMat;
        }
        else
        {
            cubes[20].material = cornerMat;
        }
        if (cubes[21].transform.localEulerAngles.z > 89.0f && cubes[21].transform.localEulerAngles.z < 91.0f)
        {
            cubes[21].material = correctCornerMat;
        }
        else
        {
            cubes[21].material = cornerMat;
        }
        if (cubes[22].transform.localEulerAngles.z > -1.0f && cubes[22].transform.localEulerAngles.z < 1.0f)
        {
            cubes[22].material = correctStraightMat;
        }
        else
        {
            cubes[22].material = straightMat;
        }
        if (cubes[23].transform.localEulerAngles.z > 179.0f && cubes[23].transform.localEulerAngles.z < 181.0f)
        {
            cubes[23].material = correctCornerMat;
        }
        else
        {
            cubes[23].material = cornerMat;
        }
        if (cubes[2].material == correctCornerMat
           && cubes[3].material == correctCornerMat
           && cubes[4].material == correctCornerMat
           && cubes[7].material == correctStraightMat
           && cubes[8].material == correctStraightMat
           && cubes[9].material == correctStraightMat
           && cubes[12].material == correctStraightMat
           && cubes[13].material == correctCornerMat
           && cubes[14].material == correctCornerMat
           && cubes[15].material == correctCornerMat
           && cubes[16].material == correctCornerMat
           && cubes[17].material == correctCornerMat
           && cubes[18].material == correctCornerMat
           && cubes[20].material == correctCornerMat
           && cubes[21].material == correctCornerMat
           && cubes[22].material == correctStraightMat
           && cubes[23].material == correctCornerMat)
        {
            solved = true;
        }
    }

    private void PipeLogic2()
    {
        if (cubes[4].transform.localEulerAngles.z > 89.0f && cubes[4].transform.localEulerAngles.z < 91.0f || cubes[4].transform.localEulerAngles.z > 269 && cubes[4].transform.localEulerAngles.z < 271.0f)
        {
            cubes[4].material = correctStraightMat;
        }
        else
        {
            cubes[4].material = straightMat;
        }
        if (cubes[7].transform.localEulerAngles.z > -1.0f && cubes[7].transform.localEulerAngles.z < 1.0f)
        {
            cubes[7].material = correctCornerMat;
        }
        else
        {
            cubes[7].material = cornerMat;
        }
        if (cubes[8].transform.localEulerAngles.z > -1.0f && cubes[8].transform.localEulerAngles.z < 1.0f)
        {
            cubes[8].material = correctStraightMat;
        }
        else
        {
            cubes[8].material = straightMat;
        }
        if (cubes[9].transform.localEulerAngles.z > 179.0f && cubes[9].transform.localEulerAngles.z < 181.0f)
        {
            cubes[9].material = correctCornerMat;
        }
        else
        {
            cubes[9].material = cornerMat;
        }
        if (cubes[10].transform.localEulerAngles.z > -1.0f && cubes[10].transform.localEulerAngles.z < 1.0f)
        {
            cubes[10].material = correctCornerMat;
        }
        else
        {
            cubes[10].material = cornerMat;
        }
        if (cubes[11].transform.localEulerAngles.z > 269.0f && cubes[11].transform.localEulerAngles.z < 271.0f)
        {
            cubes[11].material = correctCornerMat;
        }
        else
        {
            cubes[11].material = cornerMat;
        }
        if (cubes[12].transform.localEulerAngles.z > 89.0f && cubes[12].transform.localEulerAngles.z < 91.0f || cubes[12].transform.localEulerAngles.z > 269 && cubes[12].transform.localEulerAngles.z < 271.0f)
        {
            cubes[12].material = correctStraightMat;
        }
        else
        {
            cubes[12].material = straightMat;
        }
        if (cubes[15].transform.localEulerAngles.z > 89.0f && cubes[15].transform.localEulerAngles.z < 91.0f || cubes[15].transform.localEulerAngles.z > 269 && cubes[15].transform.localEulerAngles.z < 271.0f)
        {
            cubes[15].material = correctStraightMat;
        }
        else
        {
            cubes[15].material = straightMat;
        }
        if (cubes[16].transform.localEulerAngles.z > 89.0f && cubes[16].transform.localEulerAngles.z < 91.0f || cubes[16].transform.localEulerAngles.z > 269 && cubes[16].transform.localEulerAngles.z < 271.0f)
        {
            cubes[16].material = correctStraightMat;
        }
        else
        {
            cubes[16].material = straightMat;
        }
        if (cubes[17].transform.localEulerAngles.z > 89.0f && cubes[17].transform.localEulerAngles.z < 91.0f || cubes[17].transform.localEulerAngles.z > 269 && cubes[17].transform.localEulerAngles.z < 271.0f)
        {
            cubes[17].material = correctStraightMat;
        }
        else
        {
            cubes[17].material = straightMat;
        }
        if (cubes[20].transform.localEulerAngles.z > 89.0f && cubes[20].transform.localEulerAngles.z < 91.0f || cubes[20].transform.localEulerAngles.z > 269 && cubes[20].transform.localEulerAngles.z < 271.0f)
        {
            cubes[20].material = correctStraightMat;
        }
        else
        {
            cubes[20].material = straightMat;
        }
        if (cubes[21].transform.localEulerAngles.z > 89.0f && cubes[21].transform.localEulerAngles.z < 91.0f)
        {
            cubes[21].material = correctCornerMat;
        }
        else
        {
            cubes[21].material = cornerMat;
        }
        if (cubes[22].transform.localEulerAngles.z > 179.0f && cubes[22].transform.localEulerAngles.z < 181.0f)
        {
            cubes[22].material = correctCornerMat;
        }
        else
        {
            cubes[22].material = cornerMat;
        }
        if (cubes[4].material == correctStraightMat
            && cubes[7].material == correctCornerMat
            && cubes[8].material == correctStraightMat
            && cubes[9].material == correctCornerMat
            && cubes[10].material == correctCornerMat
            && cubes[11].material == correctCornerMat 
            && cubes[12].material == correctStraightMat
            && cubes[15].material == correctStraightMat
            && cubes[16].material == correctStraightMat
            && cubes[17].material == correctStraightMat
            && cubes[20].material == correctStraightMat
            && cubes[21].material == correctCornerMat
            && cubes[22].material == correctCornerMat)
        {
            solved = true;
        }
    }

    private void RandomiseRotations()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.localRotation = Quaternion.Euler(0.0f, 90.0f, rndNumber[Random.Range(0, 3)]);
        }
        PipeLogic2();
    }
}