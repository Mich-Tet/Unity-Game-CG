using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumPad : MonoBehaviour
{
    public string password = "7482";
    private string userInput = "";

    public AudioClip clickSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    AudioSource audioSource;

    public bool open;

    public UnityEvent OnEntryAllowed;

    private void Start()
    {
        userInput = "";
        audioSource = GetComponent<AudioSource>();
        open = false;
    }
    public void NumberClicked(string number)
    {
        audioSource.PlayOneShot(clickSound);
        userInput += number;

        if (userInput.Length >= 4)
        {
            if(userInput == password)
            { 
                audioSource.PlayOneShot(correctSound);
                OnEntryAllowed.Invoke();
                open = true;

            }
            else
            {
                audioSource.PlayOneShot(incorrectSound);
                userInput = "";

            }
        }
    }

}
