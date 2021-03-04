using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordPlayButton : MonoBehaviour 
{
    public Button RecordPlay;


    // Use this for initialization
    public void ClickRecordPlay()
    {
        GameObject myCamera = GameObject.Find("Main Camera");
        myCamera.SendMessage("ButtonAction", "RecordPlaySound");
       
    }

   
    public void SetRecordPlayStatus(bool boolEnable)
    {
        if (boolEnable)
        {
            RecordPlay.interactable = true;
        }
        else
        {
            RecordPlay.interactable = false;
        }
    }


}
