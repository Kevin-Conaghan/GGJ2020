using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameState m_gameState;
    public AudioClip[] calmDialogue;
    public AudioClip[] panicDialogue;
    public AudioSource m_audioSource;
    private float m_shipHealth;
    private int lastNum;
    private bool m_isPlaying;

    public GameObject gameState;
    private float m_triggerTimer;


    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_triggerTimer += Time.deltaTime;
        float shipHealth = gameState.GetComponent<GameState>().shipHealth;

        if (shipHealth < 500)
        {
            //panic stations
            if (m_triggerTimer > 20.0f && m_audioSource.isPlaying == false)
            {
                int random = Random.Range(0, 5);

                if(random!= lastNum)
                {
                    m_audioSource.PlayOneShot(panicDialogue[random]);
                    // m_audioSource.PlayOneShot(calmDialogue[random]);

                    m_triggerTimer = 0;
                }
                lastNum = random;
            } 
        }
        else
        {
            //panic stations
            if (m_triggerTimer > 20.0f && m_audioSource.isPlaying == false)
            {
           
                int random = Random.Range(0, 11);
                if(random != lastNum)
                {
                    //  m_audioSource.PlayOneShot(panicDialogue[random]);
                    m_audioSource.PlayOneShot(calmDialogue[random]);

                    m_triggerTimer = 0;
                }
                lastNum = random;
            }
        }
    }
}
