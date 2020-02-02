using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ButtonMasher : MonoBehaviour
{
    public int health=1000;
    public int decrease_rate = 2;
    private StatusScript localStatus;

    public float properGravity = -9.8f;
    public float reducedGravity = -7.0f;
    private AudioSource m_audioSource;
    public AudioClip clunkSound;
    public GameObject progressSlider;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 0;
        localStatus = GetComponent<StatusScript>();
        this.GetComponentInChildren<Light>().color = GetComponentInParent<GameState>().workingColor;
        m_audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!localStatus.working)
        {
            
            // If the light color isn't broken, then change it
            if(this.GetComponentInChildren<Light>().color != GetComponentInParent<GameState>().brokenColor)
            {
               this.GetComponentInChildren<Light>().color = GetComponentInParent<GameState>().brokenColor;
            }

            // If Particles aren't firing, then fire them
            if (!this.GetComponentInChildren<ParticleSystem>().isPlaying)
            {
                this.GetComponentInChildren<ParticleSystem>().Play();
            }


            // If the gravity isnt janky, make it janky
            if (Physics.gravity.y == properGravity)
            {
                // Bounce the player into the air
                //Vector3 currentDir = player.GetComponent<FirstPersonController>().m_MoveDir;
                //player.GetComponent<FirstPersonController>().m_MoveDir = new Vector3(currentDir.x, 40.0f, currentDir.z);
                
                //Decrease the gravity
                Debug.Log("Decreasing the Gravity");
                Physics.gravity = new Vector3(0.0f, reducedGravity, 0.0f);
            }

            if (localStatus.inRange && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraRaycast>().lookingAtBreakable)
            {
                 progressSlider.GetComponent<Slider>().value = (health / 1000.0f);
                if (Input.GetKeyDown(KeyCode.E ))
                {
                     int rnd = Random.Range(0, 10);
                    rnd = rnd /10;
                    m_audioSource.pitch = rnd;
                    m_audioSource.PlayOneShot(clunkSound);
                    IncreaseHealthTick();
                }
                else
                { 
                     DecreaseHealthTick();
                }
            
                if(health > 1001)
                {
                    progressSlider.SetActive(false);
                    this.GetComponentInParent<MeshRenderer>().material.mainTexture = localStatus.workingTexture;


                    if (this.GetComponentInChildren<Light>().color != GetComponentInParent<GameState>().workingColor)
                        this.GetComponentInChildren<Light>().color = GetComponentInParent<GameState>().workingColor;

                    if (Physics.gravity.y == reducedGravity)
                    {
                        Debug.Log("Increasing the Gravity");
                        Physics.gravity = new Vector3(0.0f, properGravity, 0.0f);
                    }

                    localStatus.invinsible = true;
                    localStatus.working = true;
                    health = 1000;
                }
            }
           
        }
        else
        {
            if (this.GetComponentInChildren<ParticleSystem>().isPlaying)
            {
                this.GetComponentInChildren<ParticleSystem>().Stop();
            }

        }

    }

    void DecreaseHealthTick()
    {
        if(health > 0)
        {   
            health -= decrease_rate;
        }
    }

    void IncreaseHealthTick()
    {
        health = health + (decrease_rate * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        health = 0;
        progressSlider.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {

        progressSlider.SetActive(false);
    }

}
