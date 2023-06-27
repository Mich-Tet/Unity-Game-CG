using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public bool on;
    public bool off;

    // Start is called before the first frame update
    void Start()
    {
        off = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(off && Input.GetButtonDown("f")){
            flashlight.SetActive(true);
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("f")){
            flashlight.SetActive(false);
            off = true;
            on = false;
        }
    }
}
