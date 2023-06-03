
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class keypad : MonoBehaviour
{
    [Header("Objects to Hide/Show")]

    public GameObject objectToEnable;
    public GameObject Door;

    // *** Breakdown of header(public) variables *** \\
    // curPassword : Pasword to set. Ive set the password in the project. Note it can be any length and letters or numbers or sysmbols
    // input: What is currently entered
    // displayText : Text area on keypad the password entered gets displayed too.
    // audioData : Play this sound when user enters in password incorrectly too many times

    [Header("Keypad Settings")]
    public string curPassword = "7482";
    private string input;
    public Text displayText;
    public AudioSource audioData;
    public AudioSource correctSound;
    private float doorPosy;
    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;
    public bool open;
    public UnityEvent OnEntryAllowed;
    // Start is called before the first frame update
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
        doorPosy = Door.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //audioSource.PlayOneShot(correctSound);

                OnEntryAllowed.Invoke();
                open = true;

                // LOG message that password is correct
                Debug.Log("Correct Password!");
                input = ""; //Clear Password
                btnClicked = 0;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                correctSound.Play();
            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }

    }

    void OnGUI()
    {
        // Action for clicking keypad( GameObject ) on screen
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;
                if (selection.CompareTag("keypad")) // Tag on the gameobject - Note the gameobject also needs a box collider
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {

                        keypadScreen = true;
                    }
                }

            }
        }

        // Disable sections when keypadScreen is set to true
        if (keypadScreen)
        {
            objectToEnable.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }

}
