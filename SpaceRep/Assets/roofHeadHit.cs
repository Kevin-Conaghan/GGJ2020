using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class roofHeadHit : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 currentDir = player.GetComponent<FirstPersonController>().m_MoveDir;
        player.GetComponent<FirstPersonController>().m_MoveDir = new Vector3(currentDir.x, 0.0f, currentDir.z);
    }
}
