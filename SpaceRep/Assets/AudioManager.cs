using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameState m_gameState;
    public AudioClip[] calmDialogue;
    public AudioClip[] panicDialogue;
    private AudioSource m_audioSource;
    private int m_shipHealth;
    private bool m_isPlaying;

    private float m_triggerTimer;


    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = this.GetComponent<AudioSource>();
        m_gameState = this.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        m_shipHealth = m_gameState.shipHealth;
        m_triggerTimer += Time.deltaTime;

        //panic stations
        if (m_shipHealth < 500)
        {
        }



    }






}
