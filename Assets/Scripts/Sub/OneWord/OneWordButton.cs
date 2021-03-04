using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OneWordButton : Assets.Scripts.PunPinYin.pubButton
{





    void Start()
    {
        int intFisrtTop = 100;
        int intStep = 70;

        myButtonSelctList = new ButtonSelect[4];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Exit", left = 18, top = 479 };
        myButtonSelctList[1] = new ButtonSelect { buttonName = "PlaySound", left = 906, top = intFisrtTop, width = 100, playSound = false };
        myButtonSelctList[2] = new ButtonSelect { buttonName = "Pre", left = 906, top = intFisrtTop + intStep * 1, width = 100, playSound = false };
        myButtonSelctList[3] = new ButtonSelect { buttonName = "Next", left = 906, top = intFisrtTop + intStep * 2, width = 100, playSound = false };
        //myButtonSelctList[4] = new ButtonSelect { buttonName = "Record", left = 906, top = intFisrtTop + intStep * 3, width = 77, playSound = false, boolReapeatButton = true, ReapeatButtonStartAction= "RecordStart", ReapeatButtonStopAction = "RecordStop" };
        //myButtonSelctList[5] = new ButtonSelect { buttonName = "RecordStop", left = 906, top = intFisrtTop + intStep * 4, width = 77, playSound = false };
       // myButtonSelctList[4] = new ButtonSelect { buttonName = "RecordPlaySound", left = 906, top = intFisrtTop + intStep * 5, width = 77, playSound = false };

    }

    override
    public void MainSelect(string strWhich)
    {
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Exit":
                GameObject myCameraresetMicrophone = GameObject.Find("Main Camera"); myCameraresetMicrophone.SendMessage("resetMicrophone");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Select");
                break;
            case "PlaySound":
            case "Pre":
            case "Next":
            //case "RecordStart":
            //case "RecordStop":
            //case "RecordPlaySound":
                GameObject myCamera = GameObject.Find("Main Camera");

                myCamera.SendMessage("ButtonAction", strWhich);
                break;

                // GameObject myCamera = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

                // UnityEngine.SceneManagement.SceneManager.LoadScene("Select");
                //break;
        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }

    // Update is called once per frame
    void Update()
    {

    }









}
