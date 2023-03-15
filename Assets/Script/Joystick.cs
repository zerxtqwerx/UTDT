using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler //, IPointerDownHandler, IPointerUpHandler
{
    private Image imgJoystickBg;
    private Image imgJoystick;
    private Vector2 posInput;

    void Start()
    {
        imgJoystickBg = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoystickBg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posInput))
        {
            posInput.x = posInput.x / (imgJoystick.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (imgJoystick.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());

            //normilize
            if(posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }
            //joystick move
            imgJoystick.rectTransform.anchoredPosition = new Vector2(
                posInput.x * (imgJoystickBg.rectTransform.sizeDelta.x / 4),
                posInput.y * (imgJoystickBg.rectTransform.sizeDelta.y / 4));
        }
    }

}