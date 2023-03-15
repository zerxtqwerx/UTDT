using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour
{
    private static float speedUpdate = 0.5f;
    private static float curSpeed = 0.0f;

    public Text text_fps;
    public static float fps_;

    void Update()
    {
        curSpeed += Time.deltaTime;

        if (curSpeed > speedUpdate)
        {
            curSpeed = 0.0f;

            fps_ = 1.0f / Time.deltaTime;

            text_fps.text = "FPS: " + (int)fps_;
        }
    }
}
