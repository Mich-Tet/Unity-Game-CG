using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioClip moveSound;
    public GameObject Door;
    private float doorPos;
    public bool doorIsOpening;
    public bool doorIsClosing;
    public bool playSound;
    public float closeDelay = 2.7f;
    AudioSource audioSource;

    void Start()
    {
        doorPos = Door.transform.position.y;
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        if(doorIsOpening == true)
        {
            if (playSound == true)
            {
                PlaySound();
            }
            Door.transform.Translate(Vector3.up * Time.deltaTime * 2);
            if (Door.transform.position.y >= 10.0f)
            {
                
                doorIsOpening = false;
                playSound = true;
                StartCoroutine(CloseDoor());
            }

        }
        if (doorIsClosing == true)
        {
            if (playSound == true)
            {
                PlaySound();
            }
            Door.transform.Translate(Vector3.down * Time.deltaTime * 2);
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
            playSound = true;
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
    void PlaySound()
    {
        audioSource.PlayOneShot(moveSound);
        playSound = false;

    }
    IEnumerator CloseDoor()
    {

        yield return new WaitForSeconds(closeDelay);

        doorIsClosing = true;
    }
}
