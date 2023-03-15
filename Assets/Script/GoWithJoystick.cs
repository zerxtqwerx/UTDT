using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoWithJoystick : MonoBehaviour
{
    public GameObject character;
    PlayerController pc;

    void Start()
    {
        pc = character.GetComponent<PlayerController>();
    }

    void Update()
    {
        pc.ApplyMovement();
    }
}
