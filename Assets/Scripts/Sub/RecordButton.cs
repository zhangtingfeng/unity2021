using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecordButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject myCamera;


    void Start()
    {
        myCamera = GameObject.Find("Main Camera");
    }
    // Use this for initialization
    public void StartClick()
    {
        Debug.Log("StartClick！！！！");
        Debug_Log.Call_WriteLog("StartClick！！！！", "UnityStartClick");
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("按下！！！！");
        Debug_Log.Call_WriteLog("按下！！！！", "Unity按下");
        myCamera.SendMessage("ButtonAction", "RecordStart");

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug_Log.Call_WriteLog("抬起！！！！", "Unity抬起");
        myCamera.SendMessage("ButtonAction", "RecordStop");

        Debug.Log("抬起！！！！");
    }

}
