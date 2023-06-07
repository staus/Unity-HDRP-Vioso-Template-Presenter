using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirstPerson : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y + mouseX, 0f);
    }
}
