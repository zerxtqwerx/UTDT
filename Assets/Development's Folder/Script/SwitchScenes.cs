using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "PC")
        {
            SceneManager.LoadScene("Mobile");
        }
        else if (SceneManager.GetActiveScene().name == "Mobile")
        {
            SceneManager.LoadScene("PC");
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ChangeScene();
        }
    }
}
