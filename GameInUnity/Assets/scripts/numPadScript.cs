using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class numPadScript : MonoBehaviour
{

    public UnityEvent NumpadClicked;


    private void OnMouseDown()
    {
        NumpadClicked.Invoke();
    }

}
