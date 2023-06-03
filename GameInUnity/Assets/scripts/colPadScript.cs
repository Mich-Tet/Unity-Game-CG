using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class colPadScript : MonoBehaviour
{

    public UnityEvent ColorpadClicked;


    private void OnMouseDown()
    {
        ColorpadClicked.Invoke();
    }

}
