using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{

    public Camera cam;

    public float rotSpeed = 0.5f;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;

    // Start is called before the first frame update
    void Start()
    {
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;

    }

    // Update is called once per frame
    void Update()
    {
        //rotx = Joystick.  
       
    }
}
