using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMobile : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public GameObject joystick;

    float xRotation;
    float yRotation;

    bool joystickTrigger;

    private void Start()
    {
        joystickTrigger = false;
   
    }

    private void Update()
    {
        

        if (Input.GetKey(KeyCode.Mouse0) && joystickTrigger == false)
        {
            //get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate can and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    public void JoystickTriggerDrag()
    {
        joystickTrigger = true;
    }

    public void JoystickTriggerUp()
    {
        joystickTrigger = false;
    }
}
