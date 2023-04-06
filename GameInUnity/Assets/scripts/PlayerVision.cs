using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] float minViewDistance = 50f;

    public float mSens = 100f;

    [SerializeField] Transform playerBody;

    float xRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //VISION
        float mouseX = Input.GetAxisRaw("Mouse X") * mSens * 5f * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mSens * 5f * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, minViewDistance);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
