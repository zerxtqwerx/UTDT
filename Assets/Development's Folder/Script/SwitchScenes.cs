using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PC"))
        {
            SceneManager.LoadScene(1);
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mobile"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
