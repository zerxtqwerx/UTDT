using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(1);
        }
    }
}
