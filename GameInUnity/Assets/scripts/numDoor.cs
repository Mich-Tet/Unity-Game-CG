using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numDoor : MonoBehaviour
{
    public GameObject Door;
    private Vector3 doorPosy;
    private float myTime;
    public NumPad NP;
    public float closeDelay = 2.7f;
    // Start is called before the first frame update

    public void Update()
    {
        myTime = Time.deltaTime;
        MoveDoor(Door);
    }
    // Update is called once per frame
    public void MoveDoor(GameObject Door)
    {
            if (NP.open == true)
            {
                Door.transform.Translate(Vector3.up *2* myTime);
                StartCoroutine(StopDoor());
            }
    }
    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(closeDelay);
        NP.open = false;
    }
}
