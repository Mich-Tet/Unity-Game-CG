using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    private float doorPos;
    public bool doorIsOpening;
    public bool doorIsClosing;
    public float openDelay = 1.0f;
    public float closeDelay = 1.0f;
    void Start()
    {
        doorPos = Door.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if(doorIsOpening == true)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
            if (Door.transform.position.y >= 10.0f)
            {
                doorIsOpening = false;
                StartCoroutine(CloseDoor());
            }
        }
        if (doorIsClosing == true)
        {
            Door.transform.Translate(Vector3.down * Time.deltaTime * 5);
            if (Door.transform.position.y <= doorPos)
            {
                doorIsClosing = false;
            }
        }
    }
    void OnMouseDown()
    {
        if (doorIsOpening == false && doorIsClosing == false)
        {
            doorIsOpening = true;
        }
        else if (doorIsOpening == false && doorIsClosing == true)
        {

            doorIsClosing = false;
            doorIsOpening = true;

        }
        else if (doorIsOpening == true && doorIsClosing == false)
        {
            doorIsOpening = false;
            doorIsClosing = true;
        }

    }
    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(closeDelay);

        doorIsClosing = true;
    }
}
