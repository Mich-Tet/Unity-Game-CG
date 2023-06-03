using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorDoor : MonoBehaviour
{
    public GameObject Door;
    private Vector3 doorPosy;
    private float myTime;
    public ColorPad CP;
    public float closeDelay = 3.0f;
    // Start is called before the first frame update

    public void Update()
    {
        myTime = Time.deltaTime;
        MoveDoor(Door);
    }
    // Update is called once per frame
    public void MoveDoor(GameObject Door)
    {
            if (CP.open == true)
            {
                Door.transform.Translate(Vector3.up *2* myTime);
                StartCoroutine(StopDoor());
            }
    }
    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(closeDelay);
        CP.open = false;
    }
}
