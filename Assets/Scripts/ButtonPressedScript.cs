using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonPressedScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public SpeechToText speechTo;

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Pressed");
        speechTo.StartRecording();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Not Pressed");
       // speechTo.StopRecording();

    }

}
