using Assets.Script.PunPinYin;
using Assets.Scripts.Pub;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using EventTrigger = UnityEngine.EventSystems.EventTrigger;

public class ScalePic : MonoBehaviour
{
    //public Text myText;


    private bool boolean = false;
    void Start()
    {

        //boolean = true;

        scale();


    }

    public void reset()
    {
        boolean = false;
        scale();
    }

    public void onClick()
    {
        Debug.Log("EventTriggerTest OnClick");
        boolean = !boolean;
        scale();

    }



    void scale() {
        if (boolean == false)
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(100f, 360f);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400f, 200f);
        }
        else {
            gameObject.GetComponent<RectTransform>().position = new Vector2(640f, 360f);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(2260f, 640f);
        }
       
    }

    // Use this for initialization



}