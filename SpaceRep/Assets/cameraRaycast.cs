using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRaycast : MonoBehaviour
{
	private Camera camera;
	private RaycastHit hit;
	private string debug;
    public bool lookingAtBreakable;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "BrokenObject")
                {
                    lookingAtBreakable = true;
                }
                else
                {
                    lookingAtBreakable = false;
                }
                debug = hit.collider.name;
            }
        }
    }
}
