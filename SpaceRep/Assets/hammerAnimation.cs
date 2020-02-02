using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAnimation();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopAnimation();
        }
    }
    public void PlayAnimation()
    {
        if (null != anim)
        {
            // play Bounce but start at a quarter of the way though
            anim.Play("HammerAnimation");
            //anim.enabled = true;
        }
    }
    public void StopAnimation()
    {
        if (null != anim)
        {
            // play Bounce but start at a quarter of the way though
            anim.enabled = false;
        }
    }
}
