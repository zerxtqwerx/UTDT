using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 acceleration;
    private Vector2 rotation;
    private Vector2 velocity;

    private Vector2 GetInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
        );

        return input; 
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 wantedVelocity = GetInput() * sensitivity;

            velocity = new Vector2(
                Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
                Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)
            );

            rotation += velocity * Time.deltaTime;

            transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
        }
    }
}
